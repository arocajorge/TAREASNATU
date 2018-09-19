using Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   public class Grupo_Usuario_Data
    {
        public List<Grupo_Usuario_Info> get_lis( int IdGrupo)
        {
            try
            {
                List<Grupo_Usuario_Info> Lista = new List<Grupo_Usuario_Info>();

                using (EntityTareas Context = new EntityTareas())
                {
                    Lista = (from q in Context.Grupo_Usuario
                             where q.IdGrupo== IdGrupo
                             select new Grupo_Usuario_Info
                             {
                                 IdGrupo = q.IdGrupo,
                                 Observacion = q.Observacion,
                                 IdUsuario = q.IdUsuario
                             }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
       
    }
}
