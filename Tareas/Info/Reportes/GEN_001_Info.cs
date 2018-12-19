using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info.General
{
   public class GEN_001_Info
    {

        public decimal IdTarea { get; set; }
        public int IdGrupo { get; set; }
        public string IdUsuarioAsignado { get; set; }
        public System.DateTime FechaEntrega { get; set; }
        public Nullable<System.DateTime> FechaCierreEncargado { get; set; }
        public Nullable<System.DateTime> FechaCierreSolicitante { get; set; }
        public string NombreGrupo { get; set; }
        public int EstadoActual { get; set; }
        public string AsuntoTarea { get; set; }
        public string Encargado { get; set; }
        public string Asunto { get; set; }
        public string Estado { get; set; }
        public string Solicitante { get; set; }
        public string Vencida { get; set; }
        public string Usuario { get; set; }
    }
}
