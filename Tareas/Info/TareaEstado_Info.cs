using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info
{
  public  class TareaEstado_Info
    {
        public decimal IdTarea { get; set; }
        public int Secuancial { get; set; }
        public string Estado { get; set; }
        public string IdUsuario { get; set; }
        public System.DateTime FechaModificacion { get; set; }
        public string Observacion { get; set; }
    }
}
