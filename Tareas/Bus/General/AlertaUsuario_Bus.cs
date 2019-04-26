using Data.General;
using Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus.General
{
    public class AlertaUsuario_Bus
    {
        AlertaUsuario_Data odata = new AlertaUsuario_Data();

        public List<AlertaUsuario_Info> GetListUsuarios()
        {
            try
            {
                return odata.GetListUsuarios();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<AlertaUsuario_Info> GetListTareas(string IdUsuario)
        {
            try
            {
                return odata.GetListTareas(IdUsuario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Guardar(AlertaUsuario_Info info)
        {
            try
            {
                return odata.Guardar(info);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
