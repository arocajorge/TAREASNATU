using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info
{
   public class Tarea_det_Info
    {
       
        public decimal IdTarea { get; set; }
        public int Secuancial { get; set; }
        [Required(ErrorMessage = "La descripción de la tarea es obligatorio")]
        public string Descripcion { get; set; }
        public double NumHoras { get; set; }
        [Required(ErrorMessage = "El campo fecha inicio es obligatorio")]
        public System.DateTime FechaInicio { get; set; }
        [Required(ErrorMessage = "El campo fecha fin es obligatorio")]
        public System.DateTime FechaFin { get; set; }
        [Required(ErrorMessage = "El campo usuario asignado es obligatorio")]
        public string IdUsuario { get; set; }
        [Required(ErrorMessage = "El campo estado es obligatorio")]
        public int IdEstado { get; set; }

        public System.DateTime FechaUltimaModif { get; set; }
        public string Observacion { get; set; }
    }
}
