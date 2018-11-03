using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info.General
{
   public class GEN_002_Info
    {
        public Nullable<long> Secuencia { get; set; }
        public int IdGrupo { get; set; }
        public Nullable<int> Cumplidas { get; set; }
        public Nullable<int> Incumplidas { get; set; }
        public Nullable<int> EnProceso { get; set; }
        public string Encargado { get; set; }
        public string Grupo { get; set; }

        public double Total { get; set; }
    }
}
