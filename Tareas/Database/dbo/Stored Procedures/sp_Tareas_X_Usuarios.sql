
CREATE PROCEDURE [dbo].[sp_Tareas_X_Usuarios]
	@IdUsuario varchar(50) 
AS
BEGIN
	

	SELECT        dbo.Tarea.IdTarea, dbo.Tarea.IdUsuarioSolicitante, dbo.Tarea.IdGrupo, dbo.Tarea.IdUsuarioAsignado, dbo.Tarea.EstadoActual, dbo.Tarea.FechaInicio, dbo.Tarea.FechaCulmina, dbo.Tarea.Observacion, 
                         dbo.Tarea.IdEstadoPrioridad, dbo.Tarea.TareaConcurrente, dbo.Tarea.AprobadoSolicitado, dbo.Tarea.AprobadoEncargado, dbo.Tarea.Estado, dbo.Tarea_det.IdUsuario
FROM            dbo.Tarea INNER JOIN
                         dbo.Tarea_det ON dbo.Tarea.IdTarea = dbo.Tarea_det.IdTarea
						 where Tarea_det.IdUsuario=@IdUsuario
						 and Tarea.Estado=1
						 and Tarea.AprobadoEncargado=1
						 and Tarea.AprobadoSolicitado=1

						 group by 
						  dbo.Tarea.IdTarea, dbo.Tarea.IdUsuarioSolicitante, dbo.Tarea.IdGrupo, dbo.Tarea.IdUsuarioAsignado, dbo.Tarea.EstadoActual, dbo.Tarea.FechaInicio, dbo.Tarea.FechaCulmina, dbo.Tarea.Observacion, 
                         dbo.Tarea.IdEstadoPrioridad, dbo.Tarea.TareaConcurrente, dbo.Tarea.AprobadoSolicitado, dbo.Tarea.AprobadoEncargado, dbo.Tarea.Estado, dbo.Tarea_det.IdUsuario
END