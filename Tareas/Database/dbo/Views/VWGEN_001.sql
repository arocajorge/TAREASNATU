--delete Tarea_det
--delete TareaArchivoAdjunto
--delete TareaEstado
--delete Tarea
--select * from Tarea
--select * from Estado where IdEstado=3
--select * from VWGEN_001

CREATE view VWGEN_001 as
SELECT        dbo.Tarea.IdTarea, dbo.Tarea_det.Secuancial, dbo.Tarea.IdGrupo, dbo.Tarea.IdUsuarioSolicitante, dbo.Tarea.IdUsuarioAsignado, dbo.Tarea_det.IdUsuario, dbo.Tarea_det.Descripcion, 
                         dbo.Tarea_det.FechaInicio AS FechaInicioSubtarea, dbo.Tarea_det.FechaFin AS FechaFinSubtarea, dbo.Tarea_det.NumHoras, dbo.Tarea_det.NumHorasReales, dbo.Tarea_det.FechaTerminoTarea, 
                         dbo.Grupo.Descripcion AS NombreGrupo, dbo.Tarea.EstadoActual, dbo.Tarea.FechaInicio AS FechaInicioTarea, dbo.Tarea.FechaCulmina AS FechaFinTarea, dbo.Tarea.AsuntoTarea, dbo.Usuario.Nombre, 
                         CASE WHEN CAST(Tarea_det.FechaTerminoTarea AS date) <= CAST(Tarea_det.FechaFin AS date) and Tarea_det.IdEstado=7
						 THEN 'CUMPLIDA' 
						 when  CAST( Tarea_det.FechaTerminoTarea  AS date) >= CAST(Tarea_det.FechaFin AS date) and Tarea_det.IdEstado=7
						 then  'INCUMPLIDA' 
						 when  Tarea_det.FechaTerminoTarea is null and Tarea_det.IdEstado=8 
						 then 'ENPROCESO'  END AS eSTADO
FROM            dbo.Tarea_det INNER JOIN
                         dbo.Usuario ON dbo.Tarea_det.IdUsuario = dbo.Usuario.IdUsuario INNER JOIN
                         dbo.Tarea ON dbo.Tarea_det.IdTarea = dbo.Tarea.IdTarea INNER JOIN
                         dbo.Grupo ON dbo.Tarea.IdGrupo = dbo.Grupo.IdGrupo
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'VWGEN_001';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'nd
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'VWGEN_001';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[39] 4[5] 2[50] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Tarea_det"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 232
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Usuario"
            Begin Extent = 
               Top = 40
               Left = 491
               Bottom = 170
               Right = 681
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Tarea"
            Begin Extent = 
               Top = 190
               Left = 58
               Bottom = 320
               Right = 287
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Grupo"
            Begin Extent = 
               Top = 213
               Left = 493
               Bottom = 343
               Right = 683
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   E', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'VWGEN_001';

