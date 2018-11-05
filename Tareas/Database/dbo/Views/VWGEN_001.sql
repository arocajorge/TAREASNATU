CREATE view VWGEN_001 as
SELECT        dbo.Tarea.IdTarea, dbo.Tarea.IdGrupo, dbo.Tarea.IdUsuarioAsignado, dbo.Tarea.FechaEntrega, CAST(dbo.Tarea.FechaCierreEncargado AS date) AS FechaCierreEncargado, CAST(dbo.Tarea.FechaCierreSolicitante AS date) 
                         AS FechaCierreSolicitante, dbo.Grupo.Descripcion AS NombreGrupo, dbo.Tarea.EstadoActual, dbo.Tarea.AsuntoTarea, UsuarioEncargado.Nombre AS Encargado, dbo.Tarea.AsuntoTarea AS Asunto, 
                         CASE WHEN CAST(Tarea.FechaCierreEncargado AS date) <= CAST(Tarea.FechaEntrega AS date) THEN 'CUMPLIDA' WHEN CAST(Tarea.FechaCierreEncargado AS date) >= CAST(Tarea.FechaEntrega AS date) 
                         THEN 'INCUMPLIDA' WHEN Tarea.FechaCierreEncargado IS NULL THEN 'ENPROCESO' END AS Estado, UsuarioSolicitante.Nombre AS Solicitante
FROM            dbo.Tarea INNER JOIN
                         dbo.Usuario AS UsuarioEncargado ON dbo.Tarea.IdUsuarioAsignado = UsuarioEncargado.IdUsuario INNER JOIN
                         dbo.Grupo ON dbo.Tarea.IdGrupo = dbo.Grupo.IdGrupo INNER JOIN
                         dbo.Usuario AS UsuarioSolicitante ON dbo.Tarea.IdUsuarioSolicitante = UsuarioSolicitante.IdUsuario

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'VWGEN_001';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'er = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'VWGEN_001';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[5] 2[48] 3) )"
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
         Begin Table = "Tarea"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 238
               Right = 267
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "UsuarioEncargado"
            Begin Extent = 
               Top = 74
               Left = 556
               Bottom = 234
               Right = 746
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Grupo"
            Begin Extent = 
               Top = 234
               Left = 734
               Bottom = 364
               Right = 924
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "UsuarioSolicitante"
            Begin Extent = 
               Top = 0
               Left = 810
               Bottom = 130
               Right = 1000
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
      Begin ColumnWidths = 14
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 2310
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
         Alias = 3165
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrd', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'VWGEN_001';

