
CREATE PROCEDURE [dbo].[AprobacionTareaAutomatico]
AS
DECLARE @IdTarea numeric
DECLARE @SecuencialHistorico int

SELECT top 1 @IdTarea = IdTarea  FROM Tarea  where AprobadoEncargado=0
and DATEDIFF(DAY, FechaTransaccion, GETDATE())>1
IF(@IdTarea > 0)
BEGIN
	UPDATE Tarea SET AprobadoEncargado=1, FechaCierreEncargado=GETDATE() where IdTarea = @IdTarea	
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

	
END