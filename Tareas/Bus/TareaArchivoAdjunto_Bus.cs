using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Info;
namespace Bus
{
   public class TareaArchivoAdjunto_Bus
    {
        TareaArchivoAdjunto_Data odata = new TareaArchivoAdjunto_Data();
        public List<TareaArchivoAdjunto_Info> get_lis(decimal IdTarea)
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
    }
}
