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
    
    public partial class vw_TareaAlerta
    {
        public string IdUsuarioAsignado { get; set; }
        public decimal IdTarea { get; set; }
        public Nullable<int> MinutosCaducar { get; set; }
        public string AsuntoTarea { get; set; }
        public string Correo { get; set; }
        public int MinutosUltimaAlarma { get; set; }
        public System.DateTime FechaEntrega { get; set; }
        public int IntervaloRepetirAlarma { get; set; }
    }
}
