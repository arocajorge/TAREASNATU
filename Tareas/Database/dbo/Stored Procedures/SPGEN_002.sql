
CREATE procedure [dbo].[SPGEN_002] 

@FechaInicio date,
@FechaFin date

as
begin

--declare
--@FechaInicio date,
--@FechaFin date

--set @FechaInicio ='2018-10-04'
--set @FechaFin ='2018-12-30'

select TareasResumen.IdUsuario, TareasResumen.Nombre, SUM(TareasResumen.TotalTarea) TotalTarea, sum(TareasResumen.Cumplidas) Cumplidas, sum(TareasResumen.Incumplidas) Incumplidas, SUM(EnProceso)EnProceso

from(
SELECT        dbo.Usuario.IdUsuario, dbo.Usuario.Nombre, COUNT(dbo.Tarea_det.IdUsuario)TotalTarea, 
case when cast( Tarea_det.FechaTerminoTarea as date)<=CAST( Tarea_det.FechaFin as date) then COUNT(dbo.Tarea_det.IdUsuario) else  0 end Cumplidas,
case when  cast(Tarea_det.FechaTerminoTarea as date)>cast( Tarea_det.FechaFin as date) then COUNT(dbo.Tarea_det.IdUsuario) else  0 end Incumplidas,
case when  Tarea_det.FechaTerminoTarea is null then COUNT(dbo.Tarea_det.IdUsuario) else  0 end EnProceso
FROM            dbo.Tarea_det INNER JOIN
                         dbo.Usuario ON dbo.Tarea_det.IdUsuario = dbo.Usuario.IdUsuario INNER JOIN
                         dbo.Tarea ON dbo.Tarea_det.IdTarea = dbo.Tarea.IdTarea
						 where Tarea_det.FechaFin between @FechaInicio and @FechaFin
						 and Tarea_det.FechaFin between @FechaInicio and @FechaFin
GROUP BY dbo.Usuario.IdUsuario, dbo.Usuario.Nombre, Tarea_det.FechaInicio, Tarea_det.FechaFin, Tarea_det.FechaTerminoTarea
)TareasResumen

group by TareasResumen.IdUsuario, TareasResumen.Nombre

end