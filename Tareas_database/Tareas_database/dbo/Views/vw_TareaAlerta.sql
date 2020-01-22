CREATE VIEW [dbo].[vw_TareaAlerta]
AS
SELECT t.IdUsuarioAsignado, t.IdTarea, DATEDIFF(minute, GETDATE(), CAST(DATEADD(day, 1, t.FechaEntrega) AS date)) AS MinutosCaducar, t.AsuntoTarea, u.Correo, 
ISNULL(DATEDIFF(minute, a.FechaUltimaAlerta, GETDATE()), p.IntervaloRepetirAlarma) AS MinutosUltimaAlarma, t.FechaEntrega, p.IntervaloRepetirAlarma
FROM     dbo.Tarea AS t cross join
                  dbo.Parametro AS p LEFT OUTER JOIN
                  dbo.AlertaUsuario AS a ON t.IdUsuarioAsignado = a.IdUsuario INNER JOIN
                  dbo.Usuario AS u ON t.IdUsuarioAsignado = u.IdUsuario 
WHERE  (t.FechaCierreSolicitante IS NULL) AND (t.AprobadoEncargado = 1) AND (t.Estado = 1) AND (t.FechaCierreEncargado IS NULL) AND (DATEDIFF(minute, GETDATE(), CAST(DATEADD(day, 1, t.FechaEntrega) AS date)) > 0)
and DATEDIFF(minute, GETDATE(), CAST(DATEADD(day, 1, t.FechaEntrega) AS date)) <= p.IntervaloAlertaMin