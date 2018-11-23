

--  exec sp_carga_laboral 'admin','2018-10-25',1

CREATE PROCEDURE [dbo].[sp_carga_laboral]
	@IdUsuario varchar(50) ,
	@FechaInicio date,
	@IdGrupo int
AS
BEGIN
	
	
	if(@IdGrupo=0)-- si solo se quiere saber la tareadel usuario
	select(
					
					
						SELECT   COUNT(Tarea.IdTarea)    
						FROM            dbo.Tarea 
												 where 
						(Tarea.IdUsuarioAsignado=@IdUsuario or Tarea.IdUsuarioSolicitante=@IdUsuario)
						and 
						( Tarea.AprobadoEncargado=0 or (Tarea.FechaCierreEncargado is not null and Tarea.FechaCierreSolicitante is null))
						 )
						 NumTareaPorAprobar,



						( 	SELECT   COUNT(Tarea.IdTarea) As NumTareaVencidas   
						    FROM    dbo.Tarea  
						    where 
						    CAST( Tarea.FechaEntrega as date) < @FechaInicio 
						    and Tarea.IdUsuarioAsignado=@IdUsuario
						    and Tarea.FechaCierreEncargado is null
						 )NumTareaVencidas,

(SELECT   COUNT(Tarea.IdTarea) As TotalTareaResueltas
FROM            dbo.Tarea  
						 WHERE CAST( Tarea.FechaCierreEncargado as date) <= @FechaInicio 						
						 and Tarea.IdUsuarioAsignado=@IdUsuario
						  and Tarea.FechaCierreSolicitante is not null
						  and Tarea.FechaCierreEncargado is not null
						  and Tarea.AprobadoEncargado=1
						  and Tarea.AprobadoSolicitado=1
						  )
						 TotalTareaResueltas,

(SELECT   COUNT(Tarea.IdTarea)  TotalTareaPendiente   
FROM            dbo.Tarea  

						  				
						 where Tarea.IdUsuarioAsignado=@IdUsuario
						 and Tarea.AprobadoEncargado=1
						 and Tarea.AprobadoSolicitado=1
						 and Tarea.FechaCierreSolicitante is null
						 )TotalTareaPendiente






	
	else 	
	-- todas las tareas del grupo
		select (
	SELECT   COUNT(Tarea.IdTarea) As NumTareaPorAprobar   
FROM            dbo.Tarea 
						 where 
						 (Tarea.IdGrupo=@IdGrupo)
						and 
						( Tarea.AprobadoEncargado=0 or 
						(Tarea.FechaCierreEncargado is not null and Tarea.FechaCierreSolicitante is null))
						 
						 )NumTareaPorAprobar,
						( 	SELECT   COUNT(Tarea.IdTarea) As NumTareaVencidas   
FROM            dbo.Tarea  
						 where 
						 CAST(Tarea.FechaEntrega as date) < @FechaInicio 
					     AND Tarea.IdGrupo=@IdGrupo						
						 and Tarea.FechaCierreEncargado is null
						 )NumTareaVencidas,

(SELECT   COUNT(Tarea.IdTarea) As TotalTareaResueltas
FROM            dbo.Tarea  
						WHERE CAST( Tarea.FechaCierreEncargado as date) <= @FechaInicio 						
						 and Tarea.IdGrupo=@IdGrupo
						  and Tarea.FechaCierreSolicitante is not null
						  and Tarea.FechaCierreEncargado is not null
						  and Tarea.AprobadoEncargado=1
						  and Tarea.AprobadoSolicitado=1
						 
						 )
						 TotalTareaResueltas,

(SELECT   COUNT(Tarea.IdTarea)  TotalTareaPendiente   
FROM            dbo.Tarea  
						  
						where  
						  Tarea.IdGrupo=@IdGrupo
						 and Tarea.AprobadoEncargado=1
						 and Tarea.AprobadoSolicitado=1
						 and Tarea.FechaCierreSolicitante is null
						 )TotalTareaPendiente
 END