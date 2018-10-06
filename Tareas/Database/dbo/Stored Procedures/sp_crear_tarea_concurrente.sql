-- exec sp_crear_tarea_concurrente 5
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
FechaInicio,																		FechaCulmina,																				Observacion,							
IdEstadoPrioridad,		TareaConcurrente,											AprobadoSolicitado,						AprobadoEncargado,									Estado,	
IdUsuario,				IdUsuarioModifica,											IdUsuarioAnula,							FechaTransaccion,									FechaModificacion,						
FechaAnulacion,			FechaAprobacion,											FechaFinConcurrencia,					DiasIntervaloProximaTarea
)

 select 
@IdTareaNew,			IdUsuarioSolicitante,										IdGrupo,								IdUsuarioAsignado,									EstadoActual,
DATEADD(DAY, DiasIntervaloProximaTarea,FechaInicio),								DATEADD(DAY, DiasIntervaloProximaTarea, FechaCulmina),										Observacion,							
IdEstadoPrioridad,		TareaConcurrente,											AprobadoSolicitado,						AprobadoEncargado,									Estado,									
IdUsuario,				IdUsuarioModifica,											IdUsuarioAnula,							GETDATE(),									FechaModificacion,	
FechaAnulacion,			FechaAprobacion,											FechaFinConcurrencia,					DiasIntervaloProximaTarea

 from Tarea where IdTarea=@IdTarea

 insert into Tarea_det (
IdTarea,															Secuancial,																	Descripcion,
FechaInicio,														fechaFin,																	NumHoras,
IdUsuario,															IdEstado,																	FechaUltimaModif,
Observacion,														NumHorasReales,																FechaTerminoTarea
)

select

@IdTareaNew,														Secuancial,																	Descripcion,
DATEADD(DAY, @DiasIntervaloProximaTarea,FechaInicio),				DATEADD(DAY, @DiasIntervaloProximaTarea,FechaFin),							NumHoras,
IdUsuario,															8,																			FechaUltimaModif,
Observacion,														NumHorasReales,																FechaTerminoTarea
from Tarea_det where IdTarea=@IdTarea


 insert into TareaArchivoAdjunto(
IdTarea,															secuencial,																	NombreArchivo,
Archivo	
)												
select

@IdTareaNew,														secuencial,																	NombreArchivo,
Archivo	
from TareaArchivoAdjunto where IdTarea=@IdTarea




END