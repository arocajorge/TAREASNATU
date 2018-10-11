using Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.General
{
    public class GEN_002_Data
    {
        public List<GEN_002_Info> get_list(string IdUsuarioAsignado, int IdGrupo,  DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                fechaFin = Convert.ToDateTime(fechaFin.ToShortDateString());
                fechaInicio = Convert.ToDateTime(fechaInicio.ToShortDateString());

                int IdGrupoIni = IdGrupo;
                int IdGrupoFin = IdGrupo == 0 ? 9999 : IdGrupo;
                List<GEN_002_Info> Lista;
                using (EntityTareas Context = new EntityTareas())
                {
                    if (IdUsuarioAsignado != "")
                        Lista = (from q in Context.SPGEN_002(fechaInicio, fechaFin)
                             where q.IdUsuarioAsignado == IdUsuarioAsignado
                             && q.IdGrupo >= q.IdGrupo && q.IdGrupo <= IdGrupoFin
                             select new GEN_002_Info
                             {
                                 Cumplidas = q.Cumplidas,
                                 Incumplidas = q.Incumplidas,
                                 IdUsuarioAsignado = q.IdUsuarioAsignado,
                                 Encargado =q.Encargado,
                                 Grupo = q.Grupo,
                                 IdGrupo = q.IdGrupo,
                                 EnProceso = q.EnProceso,

                             }).ToList();
                    else
                        Lista = (from q in Context.SPGEN_002(fechaInicio, fechaFin)
                                 where q.IdGrupo >= q.IdGrupo && q.IdGrupo <= IdGrupoFin
                                 select new GEN_002_Info
                                 {
                                     Cumplidas = q.Cumplidas,
                                     Incumplidas = q.Incumplidas,
                                     IdUsuarioAsignado = q.IdUsuarioAsignado,
                                     Encargado = q.Encargado,
                                     Grupo = q.Grupo,
                                     IdGrupo = q.IdGrupo,
                                     EnProceso = q.EnProceso,

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
