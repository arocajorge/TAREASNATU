CREATE PROCEDURE CierreTareaAutomatico
AS
DECLARE @IdTarea numeric
DECLARE @SecuencialHistorico int
DECLARE @EsRecursivo bit

SELECT top 1 @IdTarea = IdTarea  FROM Tarea WHERE FechaCierreEncargado >= dateadd(day,3,FechaCierreEncargado) and FechaCierreSolicitante is null
IF(@IdTarea > 0)
BEGIN
	UPDATE Tarea SET FechaCierreSolicitante = FechaCierreEncargado where IdTarea = @IdTarea
	
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
           ,3
           ,'admin'
           ,getdate()
           ,'CERRADO AUTOMATICO')

	 SELECT @EsRecursivo = TareaConcurrente FROM Tarea where IdTarea = @IdTarea
	 IF(@EsRecursivo = 1)
		BEGIN
			exec sp_crear_tarea_concurrente @IdTarea
		END
END