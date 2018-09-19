using Data;
using Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus
{
   public class Estado_Bus
    {
        Estado_Data odata = new Estado_Data();
        public List<Estado_Info> get_lis(int IdEstadoTipo)
        {
            try
            {
                return odata.get_lis(IdEstadoTipo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool guardarDB(Estado_Info info)
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
        public bool modificarDB(Estado_Info info)
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
        public bool anularDB(Estado_Info info)
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

        public Estado_Info get_info(int IdEstado)
        {
            try
            {
                return odata.get_info(IdEstado);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
