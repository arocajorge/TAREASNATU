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
    
    public partial class vw_Tarea
    {
        public decimal IdTarea { get; set; }
        public string IdUsuarioSolicitante { get; set; }
        public int IdGrupo { get; set; }
        public string IdUsuarioAsignado { get; set; }
        public Nullable<int> EstadoActual { get; set; }
        public System.DateTime FechaEntrega { get; set; }
        public string AsuntoTarea { get; set; }
        public string DescripcionTarea { get; set; }
        public int IdEstadoPrioridad { get; set; }
        public bool TareaConcurrente { get; set; }
        public bool AprobadoSolicitado { get; set; }
        public bool AprobadoEncargado { get; set; }
        public string solicitante { get; set; }
        public string Asignado { get; set; }
        public string Prioridad { get; set; }
        public string EstadoTarea { get; set; }
        public string NombreGrupo { get; set; }
        public bool Estado { get; set; }
        public Nullable<System.DateTime> FechaAprobacion { get; set; }
        public Nullable<System.DateTime> FechaFinConcurrencia { get; set; }
        public Nullable<int> DiasIntervaloProximaTarea { get; set; }
        public Nullable<System.DateTime> FechaCierreSolicitante { get; set; }
        public Nullable<System.DateTime> FechaCierreEncargado { get; set; }
        public Nullable<decimal> IdTareaPadre { get; set; }
        public Nullable<int> NumSubtarea { get; set; }
        public Nullable<int> NumSubtareasAbiertas { get; set; }
        public string EstadoCumplimiento { get; set; }
        public Nullable<System.DateTime> FechaTransaccion { get; set; }
    }
}
