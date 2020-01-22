
--  exec sp_carga_laboral 'admin','2018-10-25',1

CREATE PROCEDURE [dbo].[sp_carga_laboral]
	@IdUsuario varchar(50) ,
	@FechaInicio date,
	@IdGrupo int
AS
BEGIN
	
	
	if(@IdGrupo=0)-- si solo se quiere saber la tareadel usuario
	select(
					
					
	select   (
    (SELECT COUNT(IdTarea) FROM Tarea WHERE Tarea.AprobadoEncargado=0 and Tarea.IdUsuarioAsignado=@IdUsuario and tarea.estado = 1)+
	(SELECT COUNT(IdTarea) FROM Tarea WHERE Tarea.FechaCierreEncargado is not null and Tarea.FechaCierreSolicitante is null and Tarea.IdUsuarioSolicitante=@IdUsuario and tarea.estado = 1)
))NumTareaPorAprobar,



						( 	SELECT   COUNT(Tarea.IdTarea) As NumTareaVencidas   
						    FROM    dbo.Tarea  
						    where 
						     cast(isnull(Tarea.FechaCierreEncargado, getdate()) as date)> cast(Tarea.FechaEntrega as date)
						    and Tarea.IdUsuarioAsignado=@IdUsuario 
							AND Tarea.AprobadoEncargado = 1
							--AND Tarea.FechaCierreEncargado  IS NOT NULL
							and Tarea.Estado = 1
						 )NumTareaVencidas,

(SELECT   COUNT(Tarea.IdTarea) As TotalTareaResueltas
FROM            dbo.Tarea  
						 WHERE Tarea.IdUsuarioAsignado=@IdUsuario
						  and Tarea.FechaCierreSolicitante is not null
						  and Tarea.FechaCierreEncargado is not null
						  and Tarea.AprobadoEncargado=1
						  and Tarea.AprobadoSolicitado=1
						  and Tarea.Estado = 1
						  )
						 TotalTareaResueltas,

(SELECT   COUNT(Tarea.IdTarea)  TotalTareaPendiente   
FROM            dbo.Tarea  

						  				
						 where Tarea.IdUsuarioAsignado=@IdUsuario
						 and Tarea.AprobadoEncargado=1
						 and Tarea.AprobadoSolicitado=1
						 and Tarea.FechaCierreSolicitante is null
						 and Tarea.Estado = 1
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
						(Tarea.FechaCierreEncargado is not null and Tarea.FechaCierreSolicitante is null) and Tarea.Estado = 1)
						 
						 )NumTareaPorAprobar,
						( 	SELECT   COUNT(Tarea.IdTarea) As NumTareaVencidas   
FROM            dbo.Tarea  
						 where 
						 cast(isnull(Tarea.FechaCierreSolicitante,isnull( Tarea.FechaCierreEncargado,getdate())) as date)> cast(Tarea.FechaEntrega as date)
					     AND Tarea.IdGrupo=@IdGrupo and Tarea.Estado = 1
						 )NumTareaVencidas,

(SELECT   COUNT(Tarea.IdTarea) As TotalTareaResueltas
FROM            dbo.Tarea  
						WHERE Tarea.IdGrupo=@IdGrupo
						  and Tarea.FechaCierreSolicitante is not null
						  and Tarea.FechaCierreEncargado is not null
						  and Tarea.AprobadoEncargado=1
						  and Tarea.AprobadoSolicitado=1
						 and Tarea.Estado = 1
						 )
						 TotalTareaResueltas,

(SELECT   COUNT(Tarea.IdTarea)  TotalTareaPendiente   
FROM            dbo.Tarea  
						  
						where  
						  Tarea.IdGrupo=@IdGrupo
						 and Tarea.AprobadoEncargado=1
						 and Tarea.AprobadoSolicitado=1
						 and Tarea.FechaCierreSolicitante is null
						 and Tarea.Estado = 1
						 )TotalTareaPendiente
 END