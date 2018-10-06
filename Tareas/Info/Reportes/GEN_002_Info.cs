using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info.General
{
   public class GEN_002_Info
    {
        public string IdUsuario { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> TotalTarea { get; set; }
        public Nullable<int> Cumplidas { get; set; }
        public Nullable<int> Incumplidas { get; set; }
        public Nullable<int> EnProceso { get; set; }

    }
}
