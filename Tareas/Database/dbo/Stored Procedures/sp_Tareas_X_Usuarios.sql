
CREATE PROCEDURE [dbo].[sp_Tareas_X_Usuarios]
	@IdUsuario varchar(50) 
AS
BEGIN
	

	SELECT        dbo.Tarea.IdTarea, dbo.Tarea.IdUsuarioSolicitante, dbo.Tarea.IdGrupo, dbo.Tarea.IdUsuarioAsignado, dbo.Tarea.EstadoActual,  dbo.Tarea.FechaEntrega, dbo.Tarea.AsuntoTarea, dbo.Tarea.DescripcionTarea, 
                         dbo.Tarea.IdEstadoPrioridad, dbo.Tarea.TareaConcurrente, dbo.Tarea.AprobadoSolicitado, dbo.Tarea.AprobadoEncargado, dbo.Tarea.Estado, dbo.Tarea.IdUsuarioAsignado
FROM            dbo.Tarea 
						 where Tarea.IdUsuarioAsignado=@IdUsuario
						 and Tarea.Estado=1
						 and Tarea.AprobadoEncargado=1
						 and Tarea.AprobadoSolicitado=1
						 AND Tarea.EstadoActual=1

						 group by 
						  dbo.Tarea.IdTarea, dbo.Tarea.IdUsuarioSolicitante, dbo.Tarea.IdGrupo, dbo.Tarea.IdUsuarioAsignado, dbo.Tarea.EstadoActual,  dbo.Tarea.FechaEntrega,  dbo.Tarea.AsuntoTarea, dbo.Tarea.DescripcionTarea, 
                         dbo.Tarea.IdEstadoPrioridad, dbo.Tarea.TareaConcurrente, dbo.Tarea.AprobadoSolicitado, dbo.Tarea.AprobadoEncargado, dbo.Tarea.Estado, dbo.Tarea.IdUsuarioAsignado
END