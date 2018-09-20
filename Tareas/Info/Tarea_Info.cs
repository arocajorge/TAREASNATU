using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info
{
   public class Tarea_Info
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
        public bool Estado { get; set; }
        public string IdUsuario { get; set; }
        public string IdUsuarioModifica { get; set; }
        public string IdUsuarioAnula { get; set; }
        public Nullable<System.DateTime> FechaTransaccion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<System.DateTime> FechaAnulacion { get; set; }
        public List<Tarea_det_Info> list_detalle { get; set; }
        public List<TareaArchivoAdjunto_Info> list_adjuntos { get; set; }
        public string nomb_jef_grupo { get; set; }

        public Tarea_Info()
        {
            list_detalle = new List<Tarea_det_Info>();
            list_adjuntos = new List<TareaArchivoAdjunto_Info>();
        }
    }
}
