﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class EntityTareas : DbContext
    {
        public EntityTareas()
            : base("name=EntityTareas")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<EstadoTipo> EstadoTipo { get; set; }
        public virtual DbSet<Grupo> Grupo { get; set; }
        public virtual DbSet<Grupo_Usuario> Grupo_Usuario { get; set; }
        public virtual DbSet<TareaArchivoAdjunto> TareaArchivoAdjunto { get; set; }
        public virtual DbSet<TareaEstado> TareaEstado { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<vw_Grupo_Usuario> vw_Grupo_Usuario { get; set; }
        public virtual DbSet<VWGEN_001> VWGEN_001 { get; set; }
        public virtual DbSet<vw_TareaArchivoAdjunto> vw_TareaArchivoAdjunto { get; set; }
        public virtual DbSet<vw_TareaEstado> vw_TareaEstado { get; set; }
        public virtual DbSet<vw_Tarea_asignar_subtarea> vw_Tarea_asignar_subtarea { get; set; }
        public virtual DbSet<vw_Tarea> vw_Tarea { get; set; }
        public virtual DbSet<Parametro> Parametro { get; set; }
        public virtual DbSet<Tarea> Tarea { get; set; }
    
        public virtual int sp_crear_tarea_concurrente(Nullable<decimal> idTarea)
        {
            var idTareaParameter = idTarea.HasValue ?
                new ObjectParameter("IdTarea", idTarea) :
                new ObjectParameter("IdTarea", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_crear_tarea_concurrente", idTareaParameter);
        }
    
        public virtual ObjectResult<sp_Tareas_X_Usuarios_Result> sp_Tareas_X_Usuarios(string idUsuario)
        {
            var idUsuarioParameter = idUsuario != null ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Tareas_X_Usuarios_Result>("sp_Tareas_X_Usuarios", idUsuarioParameter);
        }
    
        public virtual ObjectResult<SPGEN_002_Result> SPGEN_002(Nullable<System.DateTime> fechaInicio, Nullable<System.DateTime> fechaFin)
        {
            var fechaInicioParameter = fechaInicio.HasValue ?
                new ObjectParameter("FechaInicio", fechaInicio) :
                new ObjectParameter("FechaInicio", typeof(System.DateTime));
    
            var fechaFinParameter = fechaFin.HasValue ?
                new ObjectParameter("FechaFin", fechaFin) :
                new ObjectParameter("FechaFin", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPGEN_002_Result>("SPGEN_002", fechaInicioParameter, fechaFinParameter);
        }
    
        public virtual ObjectResult<sp_carga_laboral_Result> sp_carga_laboral(string idUsuario, Nullable<System.DateTime> fechaInicio, Nullable<int> idGrupo)
        {
            var idUsuarioParameter = idUsuario != null ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(string));
    
            var fechaInicioParameter = fechaInicio.HasValue ?
                new ObjectParameter("FechaInicio", fechaInicio) :
                new ObjectParameter("FechaInicio", typeof(System.DateTime));
    
            var idGrupoParameter = idGrupo.HasValue ?
                new ObjectParameter("IdGrupo", idGrupo) :
                new ObjectParameter("IdGrupo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_carga_laboral_Result>("sp_carga_laboral", idUsuarioParameter, fechaInicioParameter, idGrupoParameter);
        }
    
        public virtual ObjectResult<sp_tareas_por_aprobar_Result> sp_tareas_por_aprobar(string idUsuario)
        {
            var idUsuarioParameter = idUsuario != null ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_tareas_por_aprobar_Result>("sp_tareas_por_aprobar", idUsuarioParameter);
        }
    
        public virtual int CierreTareaAutomatico()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CierreTareaAutomatico");
        }
    }
}
