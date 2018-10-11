
-- exec sp_crear_tarea_concurrente 5
CREATE PROCEDURE [dbo].[sp_tareas_culminadas_sin_cerrar] 
  
AS
BEGIN
	
SELECT        dbo.Tarea.IdTarea, dbo.Tarea.IdUsuarioSolicitante, dbo.Tarea.IdGrupo, dbo.Tarea.IdUsuarioAsignado, dbo.Tarea.EstadoActual, dbo.Tarea.FechaInicio, dbo.Tarea.FechaCulmina, dbo.Tarea.AsuntoTarea,dbo.Tarea.DescripcionTarea, 
                         dbo.Tarea.IdEstadoPrioridad, dbo.Tarea.TareaConcurrente, dbo.Tarea.AprobadoSolicitado, dbo.Tarea.AprobadoEncargado, dbo.Tarea.FechaFinConcurrencia, dbo.Tarea.FechaAprobacion, dbo.Tarea.DiasIntervaloProximaTarea, 
                         dbo.Tarea.FechaCierreEncargado,dbo.Tarea.FechaCierreSolicitante, dbo.Usuario.Correo, dbo.Usuario.Nombre
FROM            dbo.Usuario INNER JOIN
                         dbo.Tarea ON dbo.Usuario.IdUsuario = dbo.Tarea.IdUsuarioAsignado CROSS JOIN
                         dbo.Parametro
WHERE        (dbo.Tarea.EstadoActual <>
                             (SELECT        IdEstadoCierreTarea
                               FROM            dbo.Parametro AS Parametro_1)) AND (NOT EXISTS
                             (SELECT        IdTarea, Secuancial, Descripcion, FechaInicio, FechaFin, NumHoras, IdUsuario, IdEstado, FechaUltimaModif, Observacion, NumHorasReales, FechaTerminoTarea
                               FROM            dbo.Tarea_det AS det
                               WHERE        (IdTarea = dbo.Tarea.IdTarea) AND (IdEstado = 8))) AND (dbo.Tarea.AprobadoEncargado = 1) AND (dbo.Tarea.AprobadoSolicitado = 1)

END