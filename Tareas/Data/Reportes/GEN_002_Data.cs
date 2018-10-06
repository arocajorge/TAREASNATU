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
        public List<GEN_002_Info> get_list(string IdUsuario, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                fechaFin = Convert.ToDateTime(fechaFin.ToShortDateString());
                fechaInicio = Convert.ToDateTime(fechaInicio.ToShortDateString());

                List<GEN_002_Info> Lista;
                using (EntityTareas Context = new EntityTareas())
                {
                    if (IdUsuario != "")
                        Lista = (from q in Context.SPGEN_002(fechaInicio, fechaFin)
                             where q.IdUsuario == IdUsuario
                             select new GEN_002_Info
                             {
                                 Cumplidas = q.Cumplidas,
                                 IdUsuario = q.IdUsuario,
                                 Incumplidas = q.Incumplidas,
                                 Nombre = q.Nombre,
                                 TotalTarea = q.TotalTarea,
                                 EnProceso = q.EnProceso


                             }).ToList();
                    else
                        Lista = (from q in Context.SPGEN_002(fechaInicio, fechaFin)
                                 select new GEN_002_Info
                                 {
                                     Cumplidas = q.Cumplidas,
                                     IdUsuario = q.IdUsuario,
                                     Incumplidas = q.Incumplidas,
                                     Nombre = q.Nombre,
                                     TotalTarea = q.TotalTarea,
                                     EnProceso=q.EnProceso

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
