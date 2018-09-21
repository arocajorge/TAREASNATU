using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info
{
  public  class Estado_Info
    {
        public int IdEstado { get; set; }
        [Required(ErrorMessage = "El campo tipo de estado es obligatorio")]
        public int IdEstadoTipo { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio")]
        public string Descripcion { get; set; }
        public bool Estado1 { get; set; }
        public string IdUsuario { get; set; }
        public string IdUsuarioModifica { get; set; }
        public string IdUsuarioAnula { get; set; }
        public Nullable<System.DateTime> FechaTransaccion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<System.DateTime> FechaAnulacion { get; set; }
    }
}
