using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info
{
   public class Tarea_Info
    {
        public decimal IdTransaccionSession { get; set; }
        public decimal IdTarea { get; set; }
        [Required(ErrorMessage = "El campo usuario que solicita es obligatorio")]
        public string IdUsuarioSolicitante { get; set; }
        [Required(ErrorMessage = "El campo grupo que solicita es obligatorio")]
        public int IdGrupo { get; set; }
        [Required(ErrorMessage = "El campo usuario asignado es obligatorio")]
        public string IdUsuarioAsignado { get; set; }
        [Required(ErrorMessage = "El campo estado es obligatorio")]
        public int EstadoActual { get; set; }
        [Required(ErrorMessage = "El campo fecha inicio es obligatorio")]
        public System.DateTime FechaInicio { get; set; }
        [Required(ErrorMessage = "El campo fecha fin es obligatorio")]
        public System.DateTime FechaCulmina { get; set; }
        public string Observacion { get; set; }
        [Required(ErrorMessage = "El campo prioridad de la tarea es obligatorio")]
        public int IdEstadoPrioridad { get; set; }
        public bool TareaConcurrente { get; set; }
        public bool AprobadoSolicitado { get; set; }
        public bool AprobadoEncargado { get; set; }
        public Nullable<System.DateTime> FechaFinConcurrencia { get; set; }
        public Nullable<int> DiasIntervaloProximaTarea { get; set; }
        public bool Estado { get; set; }
        public string IdUsuario { get; set; }
        public string IdUsuarioModifica { get; set; }
        public string IdUsuarioAnula { get; set; }
        public Nullable<System.DateTime> FechaTransaccion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<System.DateTime> FechaAnulacion { get; set; }



       


        public List<Tarea_det_Info> list_detalle { get; set; }
        public List<TareaArchivoAdjunto_Info> list_adjuntos { get; set; }
        public TareaEstado_Info InfoEstado { get; set; }
        public string nomb_jef_grupo { get; set; }

        public Tarea_Info()
        {
            list_detalle = new List<Tarea_det_Info>();
            list_adjuntos = new List<TareaArchivoAdjunto_Info>();
        }


        #region campos adicionales
        public string solicitante { get; set; }
        public string Asignado { get; set; }
        public string Prioridad { get; set; }
        public string EstadoTarea { get; set; }
        public string NombreGrupo { get; set; }

        public Nullable<int> NumTareaDia { get; set; }
        public Nullable<int> NumTareaVencidas { get; set; }
        public Nullable<int> TotalTareaResueltas { get; set; }
        public Nullable<int> TotalTareaPendiente { get; set; }
        public Nullable<System.DateTime> FechaCierre { get; set; }

        #endregion
    }
}
