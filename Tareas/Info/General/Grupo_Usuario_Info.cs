using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info
{
  public  class Grupo_Usuario_Info
    {
        public int IdGrupo { get; set; }
        [Required(ErrorMessage = "El campo usuario es obligatorio")]
        public string IdUsuario { get; set; }
        public string Observacion { get; set; }

        public string Correo { get; set; }

    }
}
