//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
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
        public int EstadoActual { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime FechaCulmina { get; set; }
        public string Observacion { get; set; }
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
        public Nullable<System.DateTime> FechaCierre { get; set; }
    }
}
