using Data.General;
using Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus.General
{
    public class GEN_001_Bus
    {
        GEN_001_Data odata = new GEN_001_Data();
        public List<GEN_001_Info> get_list(string IdUsuario, decimal IdTarea, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                return odata.get_list(IdUsuario, IdTarea,  fechaInicio, fechaFin);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
