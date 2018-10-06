
--  exec sp_carga_laboral 'admin','2018-09-30'

CREATE PROCEDURE [dbo].[sp_carga_laboral]
	@IdUsuario varchar(50) ,
	@Fecha date
AS
BEGIN
	
	select (
	SELECT   COUNT(Tarea_det.Secuancial) As NumTareaDia   
FROM            dbo.Tarea INNER JOIN
                         dbo.Tarea_det ON dbo.Tarea.IdTarea = dbo.Tarea_det.IdTarea
						 where Tarea.AprobadoEncargado=1
						 and AprobadoSolicitado=1
						 and Tarea.Estado=1
						 and Tarea_det.FechaInicio=@Fecha
						 and Tarea_det.IdUsuario=@IdUsuario
						 and Tarea_det.IdEstado=8
						 )NumTareaDia,

						( 	SELECT   COUNT(Tarea_det.Secuancial) As NumTareaVencidas   
FROM            dbo.Tarea INNER JOIN
                         dbo.Tarea_det ON dbo.Tarea.IdTarea = dbo.Tarea_det.IdTarea
						 where Tarea.AprobadoEncargado=1
						 and AprobadoSolicitado=1
						 and Tarea.Estado=1
						 and Tarea_det.FechaInicio<@Fecha
						 and Tarea_det.IdUsuario=@IdUsuario
						 and Tarea_det.IdEstado=8)
						 NumTareaVencidas,

(SELECT   COUNT(Tarea_det.Secuancial) As TotalTareaResueltas
FROM            dbo.Tarea INNER JOIN
                         dbo.Tarea_det ON dbo.Tarea.IdTarea = dbo.Tarea_det.IdTarea
						 where Tarea.AprobadoEncargado=1
						 and AprobadoSolicitado=1
						 and Tarea.Estado=1
						 and Tarea_det.FechaInicio=@Fecha
						 and Tarea_det.IdUsuario=@IdUsuario
						 and Tarea_det.IdEstado=7)
						 TotalTareaResueltas,

(SELECT   COUNT(Tarea_det.Secuancial)  TotalTareaPendiente   
FROM            dbo.Tarea INNER JOIN
                         dbo.Tarea_det ON dbo.Tarea.IdTarea = dbo.Tarea_det.IdTarea
						 where Tarea.AprobadoEncargado=1
						 and AprobadoSolicitado=1
						 and Tarea.Estado=1
						 and Tarea_det.FechaInicio<@Fecha
						 and Tarea_det.IdUsuario=@IdUsuario
						 and Tarea_det.IdEstado=8
						 )TotalTareaPendiente
 END