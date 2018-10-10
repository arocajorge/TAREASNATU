using Data.General;
using Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus.General
{
   public class GEN_002_Bus
    {
        GEN_002_Data odata = new GEN_002_Data();
        public List<GEN_002_Info> get_list(string IdUsuarioAsignado, int IdGrupo,  DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                return odata.get_list(IdUsuarioAsignado, IdGrupo, fechaInicio, fechaFin);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
