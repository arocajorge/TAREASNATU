using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info.General
{
   public class Seg_Menu_x_usuario_Info
    {
        public string IdUsuario { get; set; }
        public int IdMenu { get; set; }
        public bool Lectura { get; set; }
        public bool Escritura { get; set; }
        public bool Eliminacion { get; set; }


        public bool seleccionado { get; set; }
        public Seg_Menu_Info info_menu { get; set; }
    }
}
