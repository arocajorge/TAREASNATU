using Data;
using Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus
{
   public class Tarea_Bus
    {
        Tarea_Data odata = new Tarea_Data();
        public List<Tarea_Info> get_lis()
        {
            try
            {
                return odata.get_lis();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool guardarDB(Tarea_Info info)
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
        public bool modificarDB(Tarea_Info info)
        {
            try
            {
                return odata.modificarDB(info);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool anularDB(Tarea_Info info)
        {
            try
            {
                return odata.anularDB(info);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Tarea_Info get_info(decimal IdTarea)
        {
            try
            {
                return odata.get_info(IdTarea);


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

