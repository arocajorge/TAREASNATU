

--  exec sp_carga_laboral 'admin','2018-10-25',1

CREATE PROCEDURE [dbo].[sp_carga_laboral]
	@IdUsuario varchar(50) ,
	@FechaInicio date,
	@IdGrupo int
AS
BEGIN
	
	
	if(@IdGrupo=0)-- si solo se quiere saber la tareadel usuario
	select(
SELECT   COUNT(Tarea.IdTarea) As NumTareaPorAprobar   
FROM            dbo.Tarea 
						 where 
						 Tarea.AprobadoEncargado=0
						 and Tarea.IdUsuarioAsignado=@IdUsuario
						-- and CAST( Tarea.FechaEntrega as date) <= @FechaInicio 
						 )NumTareaPorAprobar,

						( 	SELECT   COUNT(Tarea.IdTarea) As NumTareaVencidas   
						    FROM    dbo.Tarea  
						    where 
						    CAST( Tarea.FechaEntrega as date) <= @FechaInicio 
						    and Tarea.IdUsuarioAsignado=@IdUsuario
						    and Tarea.FechaCierreEncargado is null
							and Tarea.FechaEntrega<CAST(GETDATE() as date)
						 )NumTareaVencidas,

(SELECT   COUNT(Tarea.IdTarea) As TotalTareaResueltas
FROM            dbo.Tarea  
						 WHERE CAST( Tarea.FechaCierreEncargado as date) <= @FechaInicio 						
						 and Tarea.IdUsuarioAsignado=@IdUsuario)
						 TotalTareaResueltas,

(SELECT   COUNT(Tarea.IdTarea)  TotalTareaPendiente   
FROM            dbo.Tarea  

						 where Tarea.FechaEntrega <= @FechaInicio					
						 and Tarea.IdUsuarioAsignado=@IdUsuario
						 and Tarea.FechaCierreEncargado is null
						 )TotalTareaPendiente

	
	else -- todas las tareas del grupo
		select (
	SELECT   COUNT(Tarea.IdTarea) As NumTareaPorAprobar   
FROM            dbo.Tarea 
						 where 
						 Tarea.FechaAprobacion is null
						 and Tarea.IdGrupo=@IdGrupo
						 )NumTareaPorAprobar,
						( 	SELECT   COUNT(Tarea.IdTarea) As NumTareaVencidas   
FROM            dbo.Tarea  
						 where 
						 CAST(Tarea.FechaEntrega as date) <= @FechaInicio 
					     AND Tarea.IdGrupo=@IdGrupo						
						 and Tarea.FechaCierreEncargado is null
						 and Tarea.FechaEntrega<CAST(GETDATE() as date)
						 )NumTareaVencidas,

(SELECT   COUNT(Tarea.IdTarea) As TotalTareaResueltas
FROM            dbo.Tarea  
						 where 
						 CAST( Tarea.FechaCierreEncargado as date) <= @FechaInicio 
						 and Tarea.IdGrupo=@IdGrupo)
						 TotalTareaResueltas,

(SELECT   COUNT(Tarea.IdTarea)  TotalTareaPendiente   
FROM            dbo.Tarea  
						 where 
						 CAST( Tarea.FechaEntrega as date)<= @FechaInicio 
						 and Tarea.IdGrupo=@IdGrupo
						 and Tarea.FechaCierreEncargado is null
						 )TotalTareaPendiente
 END