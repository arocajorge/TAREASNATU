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
        public List<GEN_002_Info> get_list(string IdUsuario, int IdGrupo,  DateTime fechaInicio, DateTime fechaFin)
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
                             where q.IdUsuarioAsignado == IdUsuario
                             && q.IdGrupo == IdGrupo
                             select new GEN_002_Info
                             {
                                 Cumplidas = q.Cumplidas,
                                 Incumplidas = q.Incumplidas,
                                 IdUsuarioAsignado = q.IdUsuarioAsignado,
                                 AprobadoEncargado = q.AprobadoEncargado,
                                 AprobadoSolicitado = q.AprobadoSolicitado,
                                 AsuntoTarea = q.AsuntoTarea,
                                 DescripcionTarea = q.DescripcionTarea,
                                 DiasIntervaloProximaTarea = q.DiasIntervaloProximaTarea,
                                 Encargado =q.Encargado,
                                 EstadoActual = q.EstadoActual,
                                 FechaCierreEncargado = q.FechaCierreEncargado,
                                 FechaAprobacion = q.FechaAprobacion,
                                 FechaCulmina = q.FechaCulmina,
                                 FechaFinConcurrencia = q.FechaFinConcurrencia,
                                 FechaInicio = q.FechaInicio,
                                 Grupo = q.Grupo,
                                 IdEstadoPrioridad = q.IdEstadoPrioridad,
                                 IdGrupo = q.IdGrupo,
                                 IdTarea = q.IdTarea,
                                 IdUsuarioSolicitante = q.IdUsuarioSolicitante,
                                 EnProceso = q.EnProceso,
                                 TareaConcurrente = q.TareaConcurrente

                             }).ToList();
                    else
                        Lista = (from q in Context.SPGEN_002(fechaInicio, fechaFin)
                                 where q.IdGrupo == IdGrupo
                                 select new GEN_002_Info
                                 {
                                     Cumplidas = q.Cumplidas,
                                     Incumplidas = q.Incumplidas,
                                     IdUsuarioAsignado = q.IdUsuarioAsignado,
                                     AprobadoEncargado = q.AprobadoEncargado,
                                     AprobadoSolicitado = q.AprobadoSolicitado,
                                     AsuntoTarea = q.AsuntoTarea,
                                     DescripcionTarea = q.DescripcionTarea,
                                     DiasIntervaloProximaTarea = q.DiasIntervaloProximaTarea,
                                     Encargado = q.Encargado,
                                     EstadoActual = q.EstadoActual,
                                     FechaCierreEncargado = q.FechaCierreEncargado,
                                     FechaAprobacion = q.FechaAprobacion,
                                     FechaCulmina = q.FechaCulmina,
                                     FechaFinConcurrencia = q.FechaFinConcurrencia,
                                     FechaInicio = q.FechaInicio,
                                     Grupo = q.Grupo,
                                     IdEstadoPrioridad = q.IdEstadoPrioridad,
                                     IdGrupo = q.IdGrupo,
                                     IdTarea = q.IdTarea,
                                     IdUsuarioSolicitante = q.IdUsuarioSolicitante,
                                     EnProceso = q.EnProceso,
                                     TareaConcurrente = q.TareaConcurrente

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
