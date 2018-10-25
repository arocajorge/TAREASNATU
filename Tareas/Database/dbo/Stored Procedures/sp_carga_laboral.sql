

--  exec sp_carga_laboral 'admin','2018-10-25',1

CREATE PROCEDURE [dbo].[sp_carga_laboral]
	@IdUsuario varchar(50) ,
	@Fecha date,
	@IdGrupo int
AS
BEGIN
	
	
	if(@IdGrupo=0)-- si solo se quiere saber la tareadel usuario
	select(
SELECT   COUNT(Tarea.IdTarea) As NumTareaDia   
FROM            dbo.Tarea  LEFT OUTER JOIN
                         dbo.Tarea_det ON dbo.Tarea.IdTarea = dbo.Tarea_det.IdTarea
						 where 
						
						  Tarea.Estado=1
						 and Tarea.FechaAprobacion is null
						 and Tarea.IdUsuarioAsignado=@IdUsuario
						 and ISNULL( Tarea_det.IdEstado,8)=8
						 )NumTareaDia,
						( 	SELECT   COUNT(Tarea.IdTarea) As NumTareaVencidas   
FROM            dbo.Tarea  LEFT OUTER JOIN
                         dbo.Tarea_det ON dbo.Tarea.IdTarea = dbo.Tarea_det.IdTarea
						 where 
						
						  Tarea.Estado=1
						 and CAST( ISNULL( Tarea_det.FechaFin,Tarea.FechaCulmina) as date) <@Fecha
					    
						 and Tarea.IdUsuarioAsignado=@IdUsuario
						 and ISNULL( Tarea_det.IdEstado,8)=8
						 and Tarea.FechaCierreEncargado is null
						 )NumTareaVencidas,

(SELECT   COUNT(Tarea.IdTarea) As TotalTareaResueltas
FROM            dbo.Tarea  LEFT OUTER JOIN
                         dbo.Tarea_det ON dbo.Tarea.IdTarea = dbo.Tarea_det.IdTarea
						 where 
						
						  Tarea.Estado=1
						 and CAST( Tarea.FechaCierreEncargado as date) =@Fecha						
						 and Tarea.IdUsuarioAsignado=@IdUsuario
						 and ISNULL( Tarea_det.IdEstado,7)=7)
						 TotalTareaResueltas,

(SELECT   COUNT(Tarea.IdTarea)  TotalTareaPendiente   
FROM            dbo.Tarea  LEFT OUTER JOIN
                         dbo.Tarea_det ON dbo.Tarea.IdTarea = dbo.Tarea_det.IdTarea
						 where 
						 
						  Tarea.Estado=1
						 and ISNULL( Tarea_det.FechaInicio,Tarea.FechaInicio)<=@Fecha					
						 and Tarea.IdUsuarioAsignado=@IdUsuario
						 and Tarea.FechaCierreEncargado is null
						 and ISNULL( Tarea_det.IdEstado,8)=8
						 )TotalTareaPendiente

	
	else -- todas las tareas del grupo
		select (
	SELECT   COUNT(Tarea.IdTarea) As NumTareaDia   
FROM            dbo.Tarea  LEFT OUTER JOIN
                         dbo.Tarea_det ON dbo.Tarea.IdTarea = dbo.Tarea_det.IdTarea
						 where 
						
						  Tarea.Estado=1
						 and Tarea.FechaAprobacion is null
						 and Tarea.IdGrupo=@IdGrupo
						 and ISNULL( Tarea_det.IdEstado,8)=8
						 )NumTareaDia,
						( 	SELECT   COUNT(Tarea.IdTarea) As NumTareaVencidas   
FROM            dbo.Tarea  LEFT OUTER JOIN
                         dbo.Tarea_det ON dbo.Tarea.IdTarea = dbo.Tarea_det.IdTarea
						 where 
						
						  Tarea.Estado=1
						 and CAST( ISNULL( Tarea_det.FechaFin,Tarea.FechaCulmina) as date) <@Fecha
					     and Tarea.IdGrupo=@IdGrupo
						 and ISNULL( Tarea_det.IdEstado,8)=8
						 and Tarea.FechaCierreEncargado is null
						 )NumTareaVencidas,

(SELECT   COUNT(Tarea.IdTarea) As TotalTareaResueltas
FROM            dbo.Tarea  LEFT OUTER JOIN
                         dbo.Tarea_det ON dbo.Tarea.IdTarea = dbo.Tarea_det.IdTarea
						 where 
						
						  Tarea.Estado=1
						 and CAST( Tarea.FechaCierreEncargado as date) =@Fecha
						 and Tarea.IdGrupo=@IdGrupo
						 and ISNULL( Tarea_det.IdEstado,7)=7)
						 TotalTareaResueltas,

(SELECT   COUNT(Tarea.IdTarea)  TotalTareaPendiente   
FROM            dbo.Tarea  LEFT OUTER JOIN
                         dbo.Tarea_det ON dbo.Tarea.IdTarea = dbo.Tarea_det.IdTarea
						 where 
						 
						  Tarea.Estado=1
						 and ISNULL( Tarea_det.FechaInicio,Tarea.FechaInicio)<=@Fecha
						 and Tarea.IdGrupo=@IdGrupo
						 and Tarea.FechaCierreEncargado is null
						 and ISNULL( Tarea_det.IdEstado,8)=8
						 )TotalTareaPendiente
 END