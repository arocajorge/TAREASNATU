﻿using Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.General
{
    public class GEN_002_Data
    {
        public List<GEN_002_Info> get_list( int IdGrupo,  DateTime fechaInicio, DateTime fechaFin)
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
                        Lista = (from q in Context.SPGEN_002(fechaInicio, fechaFin)
                             where 
                              q.IdGrupo >= q.IdGrupo && q.IdGrupo <= IdGrupoFin
                             select new GEN_002_Info
                             {
                                 Secuencia=q.Secuencia,
                                 IdGrupo=q.IdGrupo,
                                 Cumplidas=q.Cumplidas,
                                 Incumplidas=q.Incumplidas,
                                 EnProceso = q.EnProceso,
                                 Encargado=q.Encargado,
                                 Grupo=q.Grupo

                             }).ToList();
                   
                }

                foreach (var item in Lista)
                {
                    if (item.EnProceso != null)
                        item.Total =item.Total+ Convert.ToInt32(item.EnProceso);
                    if (item.Cumplidas != null)
                        item.Total = item.Total + Convert.ToInt32(item.Cumplidas);
                    /*if (item.Incumplidas != null)
                        item.Total = item.Total + Convert.ToInt32(item.Incumplidas);*/
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
