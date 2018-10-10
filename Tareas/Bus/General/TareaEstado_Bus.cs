using Data;
using Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus
{
   public class TareaEstado_Bus
    {
        TareaEstado_Data odata = new TareaEstado_Data();
        public List<TareaEstado_Info> get_lis(decimal IdTarea)
        {
            try
            {
                return odata.get_lis(IdTarea);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool guardarDB(TareaEstado_Info info)
        {
            try
            {
                return odata.guardarDB(info);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
