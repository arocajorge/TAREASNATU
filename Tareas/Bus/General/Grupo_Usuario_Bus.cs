using Data;
using Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus
{
  public  class Grupo_Usuario_Bus
    {
        Grupo_Usuario_Data odata = new Grupo_Usuario_Data();
        public List<Grupo_Usuario_Info> get_lis( int IdGrupo)
        {
            try
            {
                return odata.get_lis(IdGrupo);
            }
            catch (Exception)
            {

                throw;
            }
        }

      

    }
}
