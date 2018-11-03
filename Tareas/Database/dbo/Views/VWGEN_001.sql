
CREATE view VWGEN_001 as
SELECT        dbo.Tarea.IdTarea, dbo.Tarea.IdGrupo, dbo.Tarea.IdUsuarioSolicitante, dbo.Tarea.IdUsuarioAsignado, dbo.Tarea.FechaEntrega AS FechaFinSubtarea, 
                         dbo.Tarea.FechaCierreEncargado, dbo.Grupo.Descripcion AS NombreGrupo, dbo.Tarea.EstadoActual,  dbo.Tarea.FechaEntrega AS FechaFinTarea, dbo.Tarea.AsuntoTarea, 
                         dbo.Usuario.Nombre, CASE WHEN CAST(Tarea.FechaCierreEncargado AS date) <= CAST(Tarea.FechaEntrega AS date) AND Tarea.EstadoActual = 7 THEN 'CUMPLIDA' WHEN CAST(Tarea.FechaCierreEncargado AS date) 
                         >= CAST(Tarea.FechaEntrega AS date) AND Tarea.EstadoActual = 7 THEN 'INCUMPLIDA' WHEN Tarea.FechaCierreEncargado IS NULL AND Tarea.EstadoActual = 8 THEN 'ENPROCESO' END AS eSTADO
FROM            dbo.Tarea INNER JOIN
                         dbo.Usuario ON dbo.Tarea.IdUsuarioAsignado = dbo.Usuario.IdUsuario INNER JOIN
                         dbo.Grupo ON dbo.Tarea.IdGrupo = dbo.Grupo.IdGrupo
