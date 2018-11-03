

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
FROM            dbo.Tarea 
						 where 
						
						  Tarea.Estado=1
						 and Tarea.FechaAprobacion is null
						 and Tarea.IdUsuarioAsignado=@IdUsuario
						 and Tarea.EstadoActual=8
						 )NumTareaDia,
						( 	SELECT   COUNT(Tarea.IdTarea) As NumTareaVencidas   
FROM            dbo.Tarea  
						 where 
						
						  Tarea.Estado=1
						 and CAST( Tarea.FechaEntrega as date) <@Fecha
					    
						 and Tarea.IdUsuarioAsignado=@IdUsuario
						 and Tarea.EstadoActual=8
						 and Tarea.FechaCierreEncargado is null
						 )NumTareaVencidas,

(SELECT   COUNT(Tarea.IdTarea) As TotalTareaResueltas
FROM            dbo.Tarea  
						 where 
						
						  Tarea.Estado=1
						 and CAST( Tarea.FechaCierreEncargado as date) =@Fecha						
						 and Tarea.IdUsuarioAsignado=@IdUsuario
						 and Tarea.EstadoActual=1)
						 TotalTareaResueltas,

(SELECT   COUNT(Tarea.IdTarea)  TotalTareaPendiente   
FROM            dbo.Tarea  
						 where 
						 
						  Tarea.Estado=1
						 and Tarea.FechaEntrega<=@Fecha					
						 and Tarea.IdUsuarioAsignado=@IdUsuario
						 and Tarea.FechaCierreEncargado is null
						 and  Tarea.EstadoActual=8
						 )TotalTareaPendiente

	
	else -- todas las tareas del grupo
		select (
	SELECT   COUNT(Tarea.IdTarea) As NumTareaDia   
FROM            dbo.Tarea 
						 where 
						
						  Tarea.Estado=1
						 and Tarea.FechaAprobacion is null
						 and Tarea.IdGrupo=@IdGrupo
						 and Tarea.EstadoActual=8
						 )NumTareaDia,
						( 	SELECT   COUNT(Tarea.IdTarea) As NumTareaVencidas   
FROM            dbo.Tarea  
						 where 
						
						  Tarea.Estado=1
						 and CAST(Tarea.FechaEntrega as date) <@Fecha
					     AND Tarea.IdGrupo=@IdGrupo
						 and Tarea.EstadoActual=8
						 and Tarea.FechaCierreEncargado is null
						 )NumTareaVencidas,

(SELECT   COUNT(Tarea.IdTarea) As TotalTareaResueltas
FROM            dbo.Tarea  
						 where 
						
						  Tarea.Estado=1
						 and CAST( Tarea.FechaCierreEncargado as date) =@Fecha
						 and Tarea.IdGrupo=@IdGrupo
						 and Tarea.EstadoActual=1)
						 TotalTareaResueltas,

(SELECT   COUNT(Tarea.IdTarea)  TotalTareaPendiente   
FROM            dbo.Tarea  
						 where 
						 
						  Tarea.Estado=1
						 and CAST( Tarea.FechaEntrega as date)<=@Fecha
						 and Tarea.IdGrupo=@IdGrupo
						 and Tarea.FechaCierreEncargado is null
						 and EstadoActual=8
						 )TotalTareaPendiente
 END