using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info.General
{
   public class GEN_002_Info
    {
        public decimal IdTarea { get; set; }
        public string IdUsuarioSolicitante { get; set; }
        public int IdGrupo { get; set; }
        public string IdUsuarioAsignado { get; set; }
        public int EstadoActual { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime FechaCulmina { get; set; }
        public string AsuntoTarea { get; set; }
        public string DescripcionTarea { get; set; }
        public int IdEstadoPrioridad { get; set; }
        public bool TareaConcurrente { get; set; }
        public bool AprobadoSolicitado { get; set; }
        public bool AprobadoEncargado { get; set; }
        public Nullable<System.DateTime> FechaAprobacion { get; set; }
        public Nullable<System.DateTime> FechaFinConcurrencia { get; set; }
        public Nullable<int> DiasIntervaloProximaTarea { get; set; }
        public Nullable<System.DateTime> FechaCierreEncargado { get; set; }
        public string Encargado { get; set; }
        public string Grupo { get; set; }
        public Nullable<int> Cumplidas { get; set; }
        public Nullable<int> Incumplidas { get; set; }
        public Nullable<int> EnProceso { get; set; }

        public int Total { get; set; }

    }
}
