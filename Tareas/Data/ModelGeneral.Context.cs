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
    
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Grupo> Grupo { get; set; }
        public virtual DbSet<Grupo_Usuario> Grupo_Usuario { get; set; }
        public virtual DbSet<Parametro> Parametro { get; set; }
        public virtual DbSet<Tarea> Tarea { get; set; }
        public virtual DbSet<Tarea_det> Tarea_det { get; set; }
        public virtual DbSet<TareaArchivoAdjunto> TareaArchivoAdjunto { get; set; }
        public virtual DbSet<TareaEstado> TareaEstado { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<EstadoTipo> EstadoTipo { get; set; }
    }
}
