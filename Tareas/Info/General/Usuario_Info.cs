using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Info
{
   public class Usuario_Info
    {
        [Required(ErrorMessage = "El campo cédula es obligatorio")]
        public string IdUsuario { get; set; }
        [Required(ErrorMessage = "El campo clave es obligatorio")]
        public string Clave { get; set; }
        [Required(ErrorMessage = "El campo nombres es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo correo es obligatorio")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "El campo tipo de usuario es obligatorio")]
        public int TipoUsuario { get; set; }
        public bool Estado { get; set; }
        public string IdUsuarioCreacion { get; set; }
        public string IdUsuarioModifica { get; set; }
        public string IdUsuarioAnula { get; set; }
        public Nullable<System.DateTime> FechaTransaccion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<System.DateTime> FechaAnulacion { get; set; }
        public string new_clave { get; set; }
    }
}
