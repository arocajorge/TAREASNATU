-- exec sp_crear_tarea_concurrente 1
CREATE PROCEDURE [dbo].[sp_crear_tarea_concurrente] 
    @IdTarea numeric 

AS
BEGIN
	

declare
@IdTareaNew numeric, 
@FechaInicio date,
@FechaFin date,
@DiasIntervaloProximaTarea int

select @IdTareaNew=MAX( IdTarea)+1, @DiasIntervaloProximaTarea= DiasIntervaloProximaTarea from Tarea
group by IdTarea, DiasIntervaloProximaTarea

insert into Tarea (
IdTarea,				IdUsuarioSolicitante,										IdGrupo,								IdUsuarioAsignado,									EstadoActual,
FechaEntrega,																																						AsuntoTarea,	DescripcionTarea,						
IdEstadoPrioridad,		TareaConcurrente,											AprobadoSolicitado,						AprobadoEncargado,									Estado,	
IdUsuario,				IdUsuarioModifica,											IdUsuarioAnula,							FechaTransaccion,									FechaModificacion,						
FechaAnulacion,			FechaAprobacion,											FechaFinConcurrencia,					DiasIntervaloProximaTarea
)

 select 
@IdTareaNew,			IdUsuarioSolicitante,										IdGrupo,								IdUsuarioAsignado,									1,
 case when @DiasIntervaloProximaTarea=30 then DATEADD (MONTH,ISNULL( 1,0),FechaEntrega) else DATEADD (DAY,ISNULL( @DiasIntervaloProximaTarea,0),FechaEntrega) end,						case when @DiasIntervaloProximaTarea=30 then DATEADD (MONTH,ISNULL( 1,0),FechaEntrega) else DATEADD (DAY,ISNULL( @DiasIntervaloProximaTarea,0),FechaEntrega) end,							AsuntoTarea,	DescripcionTarea,							
IdEstadoPrioridad,		TareaConcurrente,											AprobadoSolicitado,						AprobadoEncargado,									Estado,									
IdUsuario,				IdUsuarioModifica,											IdUsuarioAnula,							GETDATE(),									       FechaModificacion,	
FechaAnulacion,			FechaAprobacion,											FechaFinConcurrencia,					DiasIntervaloProximaTarea

 from Tarea where IdTarea=@IdTarea


 insert into TareaArchivoAdjunto(
IdTarea,															secuencial,																	NombreArchivo,
Archivo	
)												
select

@IdTareaNew,														secuencial,																	NombreArchivo,
Archivo	
from TareaArchivoAdjunto where IdTarea=@IdTarea




END