CREATE VIEW [dbo].[vw_UsuarioAlerta]
AS
SELECT IdUsuarioAsignado, COUNT(*) AS Cont, MAX(MinutosUltimaAlarma) AS MinutosUltimaAlarma, Correo
FROM     dbo.vw_TareaAlerta
GROUP BY IdUsuarioAsignado, Correo,IntervaloRepetirAlarma
HAVING MAX(MinutosUltimaAlarma) >= IntervaloRepetirAlarma