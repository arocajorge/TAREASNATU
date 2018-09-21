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

        public List<Seg_Menu_x_usuario_Info> get_list( string IdUsuario)
        {
            try
            {
                return odata.get_list( IdUsuario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Seg_Menu_x_usuario_Info> get_list(  string IdUsuario, int IdMenuPadre)
        {
            try
            {
                return odata.get_list( IdUsuario, IdMenuPadre);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool eliminarDB(  string IdUsuario)
        {
            try
            {
                return odata.eliminarDB( IdUsuario);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool guardarDB(List<Seg_Menu_x_usuario_Info> Lista,   string IdUsuario)
        {
            try
            {
                return odata.guardarDB(Lista,  IdUsuario);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
