CREATE view VWGEN_001 AS 
SELECT        dbo.Tarea.IdTarea, dbo.Tarea_det.Secuancial, dbo.Tarea.IdGrupo, dbo.Tarea.IdUsuarioSolicitante, dbo.Tarea.IdUsuarioAsignado, dbo.Tarea_det.IdUsuario, dbo.Tarea_det.Descripcion, dbo.Tarea_det.FechaInicio FechaInicioSubtarea, 
                         dbo.Tarea_det.FechaFin FechaFinSubtarea, dbo.Tarea_det.NumHoras, dbo.Tarea_det.NumHorasReales, dbo.Tarea_det.FechaTerminoTarea, dbo.Grupo.Descripcion AS NombreGrupo, dbo.Tarea.EstadoActual, dbo.Tarea.FechaInicio AS FechaInicioTarea, 
                         dbo.Tarea.FechaCulmina FechaFinTarea, dbo.Tarea.Observacion, dbo.Usuario.Nombre,
						 case when cast( Tarea_det.FechaTerminoTarea as date)<=CAST( Tarea_det.FechaFin as date) THEN 'CUMPIDA' else  'INCUMPLIDA' end eSTADO
FROM            dbo.Tarea_det INNER JOIN
                         dbo.Usuario ON dbo.Tarea_det.IdUsuario = dbo.Usuario.IdUsuario INNER JOIN
                         dbo.Tarea ON dbo.Tarea_det.IdTarea = dbo.Tarea.IdTarea INNER JOIN
                         dbo.Grupo ON dbo.Tarea.IdGrupo = dbo.Grupo.IdGrupo