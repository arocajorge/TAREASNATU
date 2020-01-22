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

select @IdTareaNew= MAX( IdTarea)+1 from Tarea

select @DiasIntervaloProximaTarea = DiasIntervaloProximaTarea from tarea
where IdTarea = @IdTarea

insert into Tarea (
IdTarea,				IdUsuarioSolicitante,										IdGrupo,								IdUsuarioAsignado,									EstadoActual,
FechaEntrega,																																						
AsuntoTarea,			DescripcionTarea,						
IdEstadoPrioridad,		TareaConcurrente,											AprobadoSolicitado,						AprobadoEncargado,									Estado,	
IdUsuario,				IdUsuarioModifica,											IdUsuarioAnula,							FechaTransaccion,									FechaModificacion,						
FechaAnulacion,			FechaAprobacion,											FechaFinConcurrencia,					DiasIntervaloProximaTarea,							TipoRecurrencia
)

 select 
@IdTareaNew,			IdUsuarioSolicitante,										IdGrupo,								IdUsuarioAsignado,									1,
 
 CASE WHEN TipoRecurrencia = '1DIA'
 THEN DATEADD(DAY, 1, FechaEntrega)
 WHEN TipoRecurrencia = '1SEMANA'
 THEN DATEADD(WEEK, 1, FechaEntrega)
 WHEN TipoRecurrencia = '2SEMANA'
 THEN DATEADD(WEEK, 2, FechaEntrega)
 WHEN TipoRecurrencia = '1MES'
 THEN DATEADD(MONTH, 1, FechaEntrega)
 WHEN TipoRecurrencia = '2MES'
 THEN DATEADD(MONTH, 2, FechaEntrega)
 WHEN TipoRecurrencia = '3MES'
 THEN DATEADD(MONTH, 3, FechaEntrega)
 WHEN TipoRecurrencia = '6MES'
 THEN DATEADD(MONTH, 6, FechaEntrega)
 WHEN TipoRecurrencia = '1ANIO'
 THEN DATEADD(YEAR, 1, FechaEntrega)
 END,													
 AsuntoTarea,			DescripcionTarea,							
IdEstadoPrioridad,		TareaConcurrente,											AprobadoSolicitado,						AprobadoEncargado,									Estado,									
IdUsuario,				IdUsuarioModifica,											IdUsuarioAnula,							GETDATE(),									       FechaModificacion,	
FechaAnulacion,			FechaAprobacion,											FechaFinConcurrencia,					DiasIntervaloProximaTarea,							TipoRecurrencia

 from Tarea where IdTarea=@IdTarea


 insert into TareaArchivoAdjunto(
IdTarea,															secuencial,																	NombreArchivo,
Archivo,															TipoArchivo	
)						
select

@IdTareaNew,														secuencial,																	NombreArchivo,
Archivo,															TipoArchivo	
from TareaArchivoAdjunto where IdTarea=@IdTarea




END