using Data.General;
using Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus.General
{
  public  class Seg_Menu_x_usuario_Bus
    {
        Seg_Menu_x_usuario_Data odata = new Seg_Menu_x_usuario_Data();

        public List<Seg_Menu_x_usuario_Info> get_list(int IdEmpresa, string IdUsuario)
        {
            try
            {
                return odata.get_list(IdEmpresa, IdUsuario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Seg_Menu_x_usuario_Info> get_list(int IdEmpresa, string IdUsuario, int IdMenuPadre)
        {
            try
            {
                return odata.get_list(IdEmpresa, IdUsuario, IdMenuPadre);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool eliminarDB(int IdEmpresa, string IdUsuario)
        {
            try
            {
                return odata.eliminarDB(IdEmpresa, IdUsuario);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool guardarDB(List<Seg_Menu_x_usuario_Info> Lista, int IdEmpresa, string IdUsuario)
        {
            try
            {
                return odata.guardarDB(Lista, IdEmpresa, IdUsuario);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
