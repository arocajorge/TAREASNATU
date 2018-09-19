using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info
{
   public class Grupo_Info
    {
        public int IdGrupo { get; set; }
        public string IdUsuario { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public string IdUsuarioCreacion { get; set; }
        public string IdUsuarioModifica { get; set; }
        public string IdUsuarioAnula { get; set; }
        public Nullable<System.DateTime> FechaTransaccion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<System.DateTime> FechaAnulacion { get; set; }


        public string nomb_jef_grupo { get; set; }
        public List<Grupo_Usuario_Info> list_grupo_usuario { get; set; }
    }
}
