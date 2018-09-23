using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Info;
using Data;
namespace Bus
{
   public class Usuario_Bus
    {
        Usuario_Data odata = new Usuario_Data();
        public List<Usuario_Info> get_lis(bool MostrarAnulados)
        {
            try
            {
                return odata.get_lis(MostrarAnulados);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool guardarDB(Usuario_Info info)
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
        public bool modificarDB(Usuario_Info info)
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
        public bool anularDB(Usuario_Info info)
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
        public bool si_existe(string IdUsuario)
        {
            try
            {
                return odata.si_existe(IdUsuario);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool validar_login(string IdUsuario="", string clave="")
        {
            try
            {
                return odata.validar_login(IdUsuario, clave);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario_Info get_info(string IdUsuario)
        {
            try
            {
                return odata.get_info(IdUsuario);


            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool modificarDB(string IdUsuario, string old_Contrasena, string new_Contrasena)
        {
            try
            {
                return odata.modificarDB(IdUsuario, old_Contrasena, new_Contrasena);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
