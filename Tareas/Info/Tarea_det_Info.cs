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
        public string Descripcion { get; set; }
        public int OrdenEjecuacion { get; set; }
        [Required(ErrorMessage = "El campo fecha inicio es obligatorio")]
        public System.DateTime FechaInicio { get; set; }
        [Required(ErrorMessage = "El campo fecha fin es obligatorio")]
        public System.DateTime FechaFin { get; set; }
    }
}
