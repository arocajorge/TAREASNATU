CREATE PROCEDURE [dbo].[sp_tareas_por_aprobar]
	@IdUsuario varchar(50) 
AS
SELECT        dbo.Tarea.IdTarea, dbo.Tarea.IdUsuarioSolicitante, dbo.Tarea.IdGrupo, dbo.Tarea.IdUsuarioAsignado, dbo.Tarea.EstadoActual, dbo.Tarea.FechaEntrega, dbo.Tarea.AsuntoTarea, dbo.Tarea.DescripcionTarea, 
                         dbo.Tarea.IdEstadoPrioridad, dbo.Tarea.TareaConcurrente, dbo.Tarea.AprobadoSolicitado, dbo.Tarea.AprobadoEncargado, Usuario_1.Nombre AS solicitante, dbo.Usuario.Nombre AS Asignado, Estado_1.Descripcion AS Prioridad,
                          dbo.Estado.Descripcion AS EstadoTarea, dbo.Grupo.Descripcion AS NombreGrupo, dbo.Tarea.Estado, dbo.Tarea.FechaAprobacion, dbo.Tarea.FechaFinConcurrencia, dbo.Tarea.DiasIntervaloProximaTarea, 
                         dbo.Tarea.FechaCierreSolicitante, dbo.Tarea.FechaCierreEncargado, dbo.Tarea.IdTareaPadre,
                             (SELECT        COUNT(IdTarea) AS CantidadSubtareas
                               FROM            dbo.Tarea AS t
                               WHERE        (IdTareaPadre = dbo.Tarea.IdTarea)) AS NumSubtarea,
                             (SELECT        COUNT(IdTarea) AS CantidadSubtareas
                               FROM            dbo.Tarea AS t
                               WHERE        (IdTareaPadre = dbo.Tarea.IdTarea) AND (FechaCierreEncargado IS NULL) AND (FechaCierreSolicitante IS NULL) AND (FechaAprobacion IS NULL)) AS NumSubtareasAbiertas, 
                         CASE WHEN CAST(Tarea.FechaCierreEncargado AS date) <= CAST(Tarea.FechaEntrega AS date) THEN 'CUMPLIDA' WHEN CAST(Tarea.FechaCierreEncargado AS date) >= CAST(Tarea.FechaEntrega AS date) 
                         THEN 'INCUMPLIDA' WHEN Tarea.FechaCierreEncargado IS NULL THEN 'ENPROCESO' END AS EstadoCumplimiento,
						 'ASIGNADA' Buzon
FROM            dbo.Tarea INNER JOIN
                         dbo.Grupo ON dbo.Tarea.IdGrupo = dbo.Grupo.IdGrupo INNER JOIN
                         dbo.Usuario ON dbo.Tarea.IdUsuarioAsignado = dbo.Usuario.IdUsuario INNER JOIN
                         dbo.Usuario AS Usuario_1 ON dbo.Tarea.IdUsuarioSolicitante = Usuario_1.IdUsuario INNER JOIN
                         dbo.Estado ON dbo.Tarea.EstadoActual = dbo.Estado.IdEstado INNER JOIN
                         dbo.Estado AS Estado_1 ON dbo.Tarea.IdEstadoPrioridad = Estado_1.IdEstado
						 where Tarea.AprobadoEncargado=0
						-- and Tarea.FechaCierreEncargado is null
						 and Tarea.IdUsuarioAsignado=@IdUsuario

						 union

						 SELECT        dbo.Tarea.IdTarea, dbo.Tarea.IdUsuarioSolicitante, dbo.Tarea.IdGrupo, dbo.Tarea.IdUsuarioAsignado, dbo.Tarea.EstadoActual, dbo.Tarea.FechaEntrega, dbo.Tarea.AsuntoTarea, dbo.Tarea.DescripcionTarea, 
                         dbo.Tarea.IdEstadoPrioridad, dbo.Tarea.TareaConcurrente, dbo.Tarea.AprobadoSolicitado, dbo.Tarea.AprobadoEncargado, Usuario_1.Nombre AS solicitante, dbo.Usuario.Nombre AS Asignado, Estado_1.Descripcion AS Prioridad,
                          dbo.Estado.Descripcion AS EstadoTarea, dbo.Grupo.Descripcion AS NombreGrupo, dbo.Tarea.Estado, dbo.Tarea.FechaAprobacion, dbo.Tarea.FechaFinConcurrencia, dbo.Tarea.DiasIntervaloProximaTarea, 
                         dbo.Tarea.FechaCierreSolicitante, dbo.Tarea.FechaCierreEncargado, dbo.Tarea.IdTareaPadre,
                             (SELECT        COUNT(IdTarea) AS CantidadSubtareas
                               FROM            dbo.Tarea AS t
                               WHERE        (IdTareaPadre = dbo.Tarea.IdTarea)) AS NumSubtarea,
                             (SELECT        COUNT(IdTarea) AS CantidadSubtareas
                               FROM            dbo.Tarea AS t
                               WHERE        (IdTareaPadre = dbo.Tarea.IdTarea) AND (FechaCierreEncargado IS NULL) AND (FechaCierreSolicitante IS NULL) AND (FechaAprobacion IS NULL)) AS NumSubtareasAbiertas, 
                         CASE WHEN CAST(Tarea.FechaCierreEncargado AS date) <= CAST(Tarea.FechaEntrega AS date) THEN 'CUMPLIDA' WHEN CAST(Tarea.FechaCierreEncargado AS date) >= CAST(Tarea.FechaEntrega AS date) 
                         THEN 'INCUMPLIDA' WHEN Tarea.FechaCierreEncargado IS NULL THEN 'ENPROCESO' END AS EstadoCumplimiento,
						  'ENVIADA' Buzon
FROM            dbo.Tarea INNER JOIN
                         dbo.Grupo ON dbo.Tarea.IdGrupo = dbo.Grupo.IdGrupo INNER JOIN
                         dbo.Usuario ON dbo.Tarea.IdUsuarioAsignado = dbo.Usuario.IdUsuario INNER JOIN
                         dbo.Usuario AS Usuario_1 ON dbo.Tarea.IdUsuarioSolicitante = Usuario_1.IdUsuario INNER JOIN
                         dbo.Estado ON dbo.Tarea.EstadoActual = dbo.Estado.IdEstado INNER JOIN
                         dbo.Estado AS Estado_1 ON dbo.Tarea.IdEstadoPrioridad = Estado_1.IdEstado
						 where Tarea.AprobadoEncargado=1and Tarea.FechaCierreEncargado is not null
						 and Tarea.FechaCierreSolicitante is null	
						 AND Tarea.AprobadoSolicitado=1
						 AND Tarea.AprobadoEncargado=1
						 and Tarea.FechaCierreEncargado is not null					 
						 and Tarea.IdUsuarioSolicitante=@IdUsuario