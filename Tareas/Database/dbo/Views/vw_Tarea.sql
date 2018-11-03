CREATE VIEW dbo.vw_Tarea
AS
SELECT        dbo.Tarea.IdTarea, dbo.Tarea.IdUsuarioSolicitante, dbo.Tarea.IdGrupo, dbo.Tarea.IdUsuarioAsignado, dbo.Tarea.EstadoActual,  dbo.Tarea.FechaEntrega, dbo.Tarea.AsuntoTarea, 
                         dbo.Tarea.DescripcionTarea, dbo.Tarea.IdEstadoPrioridad, dbo.Tarea.TareaConcurrente, dbo.Tarea.AprobadoSolicitado, dbo.Tarea.AprobadoEncargado, Usuario_1.Nombre AS solicitante, dbo.Usuario.Nombre AS Asignado, 
                         Estado_1.Descripcion AS Prioridad, dbo.Estado.Descripcion AS EstadoTarea, dbo.Grupo.Descripcion AS NombreGrupo, dbo.Tarea.Estado, dbo.Tarea.FechaAprobacion, dbo.Tarea.FechaFinConcurrencia, 
                         dbo.Tarea.DiasIntervaloProximaTarea, dbo.Tarea.FechaCierreSolicitante, dbo.Tarea.FechaCierreEncargado
FROM            dbo.Tarea INNER JOIN
                         dbo.Grupo ON dbo.Tarea.IdGrupo = dbo.Grupo.IdGrupo INNER JOIN
                         dbo.Usuario ON dbo.Tarea.IdUsuarioAsignado = dbo.Usuario.IdUsuario INNER JOIN
                         dbo.Usuario AS Usuario_1 ON dbo.Tarea.IdUsuarioSolicitante = Usuario_1.IdUsuario INNER JOIN
                         dbo.Estado ON dbo.Tarea.EstadoActual = dbo.Estado.IdEstado INNER JOIN
                         dbo.Estado AS Estado_1 ON dbo.Tarea.IdEstadoPrioridad = Estado_1.IdEstado
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vw_Tarea';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'   Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
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
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vw_Tarea';






GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[23] 4[5] 2[41] 3) )"
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
               Bottom = 316
               Right = 236
            End
            DisplayFlags = 280
            TopColumn = 11
         End
         Begin Table = "Grupo"
            Begin Extent = 
               Top = 126
               Left = 348
               Bottom = 256
               Right = 538
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Usuario"
            Begin Extent = 
               Top = 176
               Left = 610
               Bottom = 306
               Right = 800
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Usuario_1"
            Begin Extent = 
               Top = 0
               Left = 627
               Bottom = 130
               Right = 817
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Estado"
            Begin Extent = 
               Top = 270
               Left = 38
               Bottom = 400
               Right = 228
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Estado_1"
            Begin Extent = 
               Top = 260
               Left = 708
               Bottom = 390
               Right = 898
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
      Begin ColumnWidths = 26
         Width = 284
         Width = 1500
         Width = 1500
      ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vw_Tarea';





