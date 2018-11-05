
CREATE procedure [dbo].[SPGEN_002] 

@FechaInicio date,
@FechaFin date

as
begin

--declare
--@FechaInicio date,
--@FechaFin date

--set @FechaFin ='2018-12-30'
--set @FechaInicio ='2018-10-01'

declare @MaxIdPregunta int
set @MaxIdPregunta=0

SELECT @MaxIdPregunta+(Row_number() over(order by @MaxIdPregunta))  Secuencia,TareasResumen.IdGrupo, sum(TareasResumen.Cumplidas)Cumplidas, sum( TareasResumen.Incumplidas)Incumplidas,sum(TareasResumen.EnProceso)EnProceso,TareasResumen.Encargado,TareasResumen.Grupo
  FROM(

SELECT          dbo.Tarea.IdGrupo, dbo.Tarea.EstadoActual, dbo.Tarea.FechaEntrega, dbo.Tarea.AsuntoTarea, 
                         dbo.Tarea.DescripcionTarea, dbo.Tarea.IdEstadoPrioridad, dbo.Tarea.TareaConcurrente, dbo.Tarea.AprobadoSolicitado, dbo.Tarea.AprobadoEncargado, dbo.Tarea.FechaAprobacion, dbo.Tarea.FechaFinConcurrencia, 
                         dbo.Tarea.DiasIntervaloProximaTarea, dbo.Tarea.FechaCierreEncargado, dbo.Usuario.Nombre AS Encargado, dbo.Grupo.Descripcion AS Grupo,
						 case when cast( Tarea.FechaCierreEncargado as date)<=CAST( Tarea.FechaEntrega as date) then COUNT(dbo.Tarea.IdUsuarioAsignado) else  0 end Cumplidas,
						 case when  cast(Tarea.FechaCierreEncargado as date)>cast( Tarea.FechaEntrega as date) then COUNT(dbo.Tarea.IdUsuarioAsignado) else  0 end Incumplidas,
						 case when  Tarea.FechaCierreEncargado is null and Tarea.FechaEntrega <= GETDATE() then COUNT(dbo.Tarea.IdUsuarioAsignado) else 0 end  EnProceso
FROM            dbo.Grupo INNER JOIN
                         dbo.Tarea ON dbo.Grupo.IdGrupo = dbo.Tarea.IdGrupo INNER JOIN
                         dbo.Usuario ON dbo.Grupo.IdUsuario = dbo.Usuario.IdUsuario

						  where Tarea.FechaEntrega between @FechaInicio and @FechaFin
						 --and Tarea.FechaCulmina between @FechaInicio and @FechaFin
group by
						  dbo.Tarea.IdTarea, dbo.Tarea.IdGrupo, dbo.Tarea.EstadoActual, dbo.Tarea.FechaEntrega, dbo.Tarea.AsuntoTarea, 
                         dbo.Tarea.DescripcionTarea, dbo.Tarea.IdEstadoPrioridad, dbo.Tarea.TareaConcurrente, dbo.Tarea.AprobadoSolicitado, dbo.Tarea.AprobadoEncargado, dbo.Tarea.FechaAprobacion, dbo.Tarea.FechaFinConcurrencia, 
                         dbo.Tarea.DiasIntervaloProximaTarea, dbo.Tarea.FechaCierreEncargado, dbo.Usuario.Nombre , dbo.Grupo.Descripcion
		

		) TareasResumen

		group by TareasResumen.Encargado,TareasResumen.Grupo,TareasResumen.IdGrupo
end