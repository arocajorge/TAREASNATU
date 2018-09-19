using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace Info
{
   public class Usuario_Info
    {
        //[Required(ErrorMessage = "El campo usuario es obligatorio")]
        public string IdUsuario { get; set; }
        //[Required(ErrorMessage = "El campo contraseña es obligatorio")]
        public string Clave { get; set; }
        //[Required(ErrorMessage = "El campo nombre es obligatorio")]
        public string Nombre { get; set; }
        //[Required(ErrorMessage = "El campo correo es obligatorio")]
        public string Correo { get; set; }
        public bool Estado { get; set; }
    }
}
