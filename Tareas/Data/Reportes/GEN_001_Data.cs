using Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.General
{
  public class GEN_001_Data
    {
        public List<GEN_001_Info> get_list(string IdUsuario, decimal IdTarea,  DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                fechaFin = Convert.ToDateTime(fechaFin.ToShortDateString());
                fechaInicio = Convert.ToDateTime(fechaInicio.ToShortDateString());
                decimal IdTareaIni = IdTarea;
                decimal IdTareaFin = IdTarea == 0 ? 9999 : IdTarea;

                List<GEN_001_Info> Lista;
                using (EntityTareas Context = new EntityTareas())
                {
                    if(IdUsuario!="")
                    Lista = (from q in Context.VWGEN_001
                             where q.IdUsuarioAsignado == IdUsuario
                             && q.IdTarea >= IdTareaIni && q.IdTarea <= IdTareaFin
                             && q.FechaEntrega >= fechaInicio
                             && q.FechaEntrega <= fechaFin
                             select new GEN_001_Info
                             {
                                 IdGrupo = q.IdGrupo,
                                 IdTarea = q.IdTarea,
                                 IdUsuarioAsignado = q.IdUsuarioAsignado,
                                 FechaEntrega=q.FechaEntrega,
                                 FechaCierreEncargado=q.FechaCierreEncargado,
                                 FechaCierreSolicitante=q.FechaCierreSolicitante,
                                 NombreGrupo=q.NombreGrupo,
                                 EstadoActual=q.EstadoActual,
                                 Asunto=q.AsuntoTarea,
                                 Encargado=q.Encargado,
                                 Solicitante=q.Solicitante,
                                 Estado=q.Estado,
                                 Usuario= IdUsuario
                             }).ToList();
                    else
                        Lista = (from q in Context.VWGEN_001
                                 where  q.IdTarea >= IdTareaIni && q.IdTarea <= IdTareaFin
                                 && q.FechaEntrega >= fechaInicio
                                 && q.FechaEntrega <= fechaFin
                                 select new GEN_001_Info
                                 {
                                     IdGrupo = q.IdGrupo,
                                     IdTarea = q.IdTarea,
                                     IdUsuarioAsignado = q.IdUsuarioAsignado,
                                     FechaEntrega = q.FechaEntrega,
                                     FechaCierreEncargado = q.FechaCierreEncargado,
                                     FechaCierreSolicitante = q.FechaCierreSolicitante,
                                     NombreGrupo = q.NombreGrupo,
                                     EstadoActual = q.EstadoActual,
                                     Asunto = q.AsuntoTarea,
                                     Encargado = q.Encargado,
                                     Solicitante = q.Solicitante,
                                     Estado = q.Estado,
                                     Usuario = IdUsuario

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
