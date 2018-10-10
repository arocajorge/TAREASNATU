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
        public int Secuancial { get; set; }
        public int IdGrupo { get; set; }
        public string IdUsuarioSolicitante { get; set; }
        public string IdUsuarioAsignado { get; set; }
        public string IdUsuario { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime FechaInicioSubtarea { get; set; }
        public System.DateTime FechaFinSubtarea { get; set; }
        public double NumHoras { get; set; }
        public Nullable<double> NumHorasReales { get; set; }
        public Nullable<System.DateTime> FechaTerminoTarea { get; set; }
        public string NombreGrupo { get; set; }
        public int EstadoActual { get; set; }
        public System.DateTime FechaInicioTarea { get; set; }
        public System.DateTime FechaFinTarea { get; set; }
        public string Nombre { get; set; }
        public string ESTADO { get; set; }
        public string AsuntoTarea { get; set; }
    }
}
