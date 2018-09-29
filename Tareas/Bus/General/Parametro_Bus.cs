using Data;
using Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.General;
namespace Bus
{
    public class Parametro_Bus
    {
        Parametro_Data odata = new Parametro_Data();
        public bool grabarDB(Parametro_Info info)
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
        public Parametro_Info get_info()
        {
            try
            {
                return odata.get_info();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
