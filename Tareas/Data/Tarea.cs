//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Tarea
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tarea()
        {
            this.Tarea_det = new HashSet<Tarea_det>();
            this.TareaArchivoAdjunto = new HashSet<TareaArchivoAdjunto>();
            this.TareaEstado = new HashSet<TareaEstado>();
        }
    
        public decimal IdTarea { get; set; }
        public string IdUsuarioSolicitante { get; set; }
        public int IdGrupo { get; set; }
        public string IdUsuarioAsignado { get; set; }
        public int EstadoActual { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime FechaCulmina { get; set; }
        public string Observacion { get; set; }
        public int IdEstadoPrioridad { get; set; }
        public bool TareaConcurrente { get; set; }
        public bool AprobadoSolicitado { get; set; }
        public bool AprobadoEncargado { get; set; }
        public bool Estado { get; set; }
        public string IdUsuario { get; set; }
        public string IdUsuarioModifica { get; set; }
        public string IdUsuarioAnula { get; set; }
        public Nullable<System.DateTime> FechaTransaccion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<System.DateTime> FechaAnulacion { get; set; }
    
        public virtual Estado Estado1 { get; set; }
        public virtual Estado Estado2 { get; set; }
        public virtual Grupo Grupo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tarea_det> Tarea_det { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Usuario Usuario1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TareaArchivoAdjunto> TareaArchivoAdjunto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TareaEstado> TareaEstado { get; set; }
    }
}
