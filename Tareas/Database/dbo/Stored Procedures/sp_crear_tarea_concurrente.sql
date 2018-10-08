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
FechaInicio,																		FechaCulmina,																				Observacion,							
IdEstadoPrioridad,		TareaConcurrente,											AprobadoSolicitado,						AprobadoEncargado,									Estado,	
IdUsuario,				IdUsuarioModifica,											IdUsuarioAnula,							FechaTransaccion,									FechaModificacion,						
FechaAnulacion,			FechaAprobacion,											FechaFinConcurrencia,					DiasIntervaloProximaTarea
)

 select 
@IdTareaNew,			IdUsuarioSolicitante,										IdGrupo,								IdUsuarioAsignado,									1,
DATEADD(DAY,ISNULL( @DiasIntervaloProximaTarea,0),FechaInicio),						DATEADD(DAY, isnull(@DiasIntervaloProximaTarea,0), FechaCulmina),							Observacion,							
IdEstadoPrioridad,		TareaConcurrente,											AprobadoSolicitado,						AprobadoEncargado,									Estado,									
IdUsuario,				IdUsuarioModifica,											IdUsuarioAnula,							GETDATE(),									       FechaModificacion,	
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
DATEADD(DAY,ISNULL( @DiasIntervaloProximaTarea,0),FechaInicio),				DATEADD(DAY,ISNULL( @DiasIntervaloProximaTarea,0),FechaFin),		NumHoras,
IdUsuario,															8,																			FechaUltimaModif,
Observacion,														NumHorasReales,																null
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