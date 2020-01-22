
--EXEC [dbo].[CierreTareaAutomatico]
CREATE PROCEDURE [dbo].[CierreTareaAutomatico]
AS

DECLARE @IdTarea numeric
DECLARE @SecuencialHistorico int
DECLARE @EsRecursivo bit
DECLARE @Minutos int
DECLARE @MinutosApro int

DECLARE @EstadoVencida int, @EstadoCerrada int, @EstadoAprobada int, @UtilizarFechaEntrega varchar(50)

SELECT @Minutos = IntervaloEjecucionMin, 
@EstadoVencida = IdEstadoTareaVencida, 
@EstadoCerrada = IdEstadoCierreSolicitante,
@MinutosApro = IntervaloEjecucionMinApro,
@EstadoAprobada = IdEstadoAprobarTarea,
@UtilizarFechaEntrega = UtilizarFechaAutoApro
from parametro

SELECT top 1 @IdTarea =  IdTarea  FROM Tarea WHERE datediff(minute,FechaCierreEncargado,GetDate()) > @minutos and FechaCierreSolicitante is null
ORDER BY IdTarea desc

select @idtarea

IF(@IdTarea > 0)
BEGIN
	UPDATE Tarea SET FechaCierreSolicitante = FechaCierreEncargado,
	EstadoActual = case when cast(FechaCierreEncargado as date) <= cast(FechaEntrega as date) then @EstadoCerrada else @EstadoVencida end
	where IdTarea = @IdTarea
	
	SELECT @EstadoCerrada = EstadoActual FROM TAREA WHERE IDTAREA = @IDTAREA

	SELECT @SecuencialHistorico = (ISNULL(MAX(Secuancial),0)+1)
	FROM TareaEstado	
	WHERE IdTarea = @IdTarea
	group by IdTarea

	INSERT INTO [dbo].[TareaEstado]
           ([IdTarea]
           ,[Secuancial]
           ,[IdEstado]
           ,[IdUsuario]
           ,[FechaModificacion]
           ,[Observacion])
     VALUES
		   (@IdTarea
           ,@SecuencialHistorico
           ,@EstadoCerrada
           ,'admin'
           ,getdate()
           ,'CERRADO AUTOMATICO')

	 SELECT @EsRecursivo = TareaConcurrente FROM Tarea where IdTarea = @IdTarea
	 IF(@EsRecursivo = 1)
		BEGIN
			exec sp_crear_tarea_concurrente @IdTarea
		END

		
END

set @MinutosApro = isnull(@MinutosApro,0)
if(@MinutosApro > 0)
BEGIN
--APROBACION ENCARGADO AUTOMATICA
		SELECT top 1 @IdTarea = IdTarea 
		FROM Tarea WHERE datediff(minute,CAST(FechaTransaccion AS DATE),CAST(GetDate() AS DATE)) > @minutosApro 
		and isnull(AprobadoEncargado,cast(0 as bit)) = 0 and estado = 1
		ORDER BY IdTarea desc

		IF(@IdTArea > 0)
		BEGIN
			UPDATE Tarea set AprobadoEncargado = 1, 
			FechaAprobacion = GETDATE(),
			FechaEntrega = CASE 
			WHEN @UtilizarFechaEntrega = 'FECHA' THEN FechaEntrega
			WHEN @UtilizarFechaEntrega = 'INTERVALO' THEN DATEADD(DAY, DATEDIFF(DAY,CAST(FechaTransaccion AS DATE),FechaEntrega),FechaEntrega)
			WHEN @UtilizarFechaEntrega = 'ACTUAL' THEN CAST(GETDATE() AS DATE)
			WHEN @UtilizarFechaEntrega = '1DIA' THEN DATEADD(DAY,1,FechaEntrega)
			WHEN @UtilizarFechaEntrega = '2DIA' THEN DATEADD(DAY,2,FechaEntrega)
			WHEN @UtilizarFechaEntrega = '3DIA' THEN DATEADD(DAY,3,FechaEntrega)
			END
			where IdTarea = @IdTarea

			SELECT @SecuencialHistorico = (ISNULL(MAX(Secuancial),0)+1)
			FROM TareaEstado	
			WHERE IdTarea = @IdTarea
			group by IdTarea

			INSERT INTO [dbo].[TareaEstado]
				([IdTarea]
				,[Secuancial]
				,[IdEstado]
				,[IdUsuario]
				,[FechaModificacion]
				,[Observacion])
			VALUES
				(@IdTarea
				,@SecuencialHistorico
				,@EstadoAprobada
				,'admin'
				,getdate()
				,'APROBADO AUTOMATICO')
		END
		
END