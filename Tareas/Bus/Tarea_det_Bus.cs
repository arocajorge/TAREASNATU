using Data;
using Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus
{
   public class Tarea_det_Bus
    {
        Tarea_det_Data odata = new Tarea_det_Data();
        public List<Tarea_det_Info> get_lis(decimal IdTarea)
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
