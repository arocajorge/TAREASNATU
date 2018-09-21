using Data;
using Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus
{
   public class Departamento_Bus
    {
        Departamento_Data odata = new Departamento_Data();
        public List<Departamento_Info> get_lis()
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

        public bool guardarDB(Departamento_Info info)
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
        public bool modificarDB(Departamento_Info info)
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
        public bool anularDB(Departamento_Info info)
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

        public Departamento_Info get_info(int IdDepartamento)
        {
            try
            {
                return odata.get_info(IdDepartamento);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
