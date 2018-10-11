using Data;
using Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus
{
   public class Grupo_Bus
    {
       Grupo_Data odata = new Grupo_Data();
        public List<Grupo_Info> get_lis()
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

        public bool guardarDB(Grupo_Info info)
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
        public bool modificarDB(Grupo_Info info)
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
        public bool anularDB(Grupo_Info info)
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
        public Grupo_Info get_info(int IdGrupo)
        {
            try
            {
                return odata.get_info(IdGrupo);


            }
            catch (Exception)
            {

                throw;
            }
        }
        public Grupo_Info get_info_grup_usuario(string IdUsuario)
        {
            try
            {
                return odata.get_info_grup_usuario(IdUsuario);


            }
            catch (Exception)
            {

                throw;
            }
        }
        public Grupo_Info get_info_grup_usuario(int IdGrupo)
        {
            try
            {
                return odata.get_info_grup_usuario(IdGrupo);


            }
            catch (Exception)
            {

                throw;
            }
        }
    
    }
}
