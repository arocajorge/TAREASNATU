using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Info.General;
using Data.General;
namespace Bus.General
{
  public  class Seg_Men_Bus
    {

        Seg_Menu_Data odata = new Seg_Menu_Data();
        public List<Seg_Menu_Info> get_list(bool mostrar_anulados)
        {
            try
            {
                return odata.get_list(mostrar_anulados);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Seg_Menu_Info> get_list_combo(bool mostrar_anulados)
        {
            try
            {
                return odata.get_list_combo(mostrar_anulados);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Seg_Menu_Info get_info(int IdMenu)
        {
            try
            {
                return odata.get_info(IdMenu);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool guardarDB(Seg_Menu_Info info)
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

        public bool modificarDB(Seg_Menu_Info info)
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

        public bool anularDB(Seg_Menu_Info info)
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

    }
}
