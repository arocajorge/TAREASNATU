using Data;
using Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus
{
   public class EstadoTipo_Bus
    {
        EstadoTipoTipo_Data odata = new EstadoTipoTipo_Data();
        public List<EstadoTipo_Info> get_lis()
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

        public bool guardarDB(EstadoTipo_Info info)
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
        public bool modificarDB(EstadoTipo_Info info)
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
        public bool anularDB(EstadoTipo_Info info)
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

        public EstadoTipo_Info get_info(int IdEstadoTipo)
        {
            try
            {
                return odata.get_info(IdEstadoTipo);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
