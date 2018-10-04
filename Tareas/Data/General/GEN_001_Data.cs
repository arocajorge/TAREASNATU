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
        public List<GEN_001_Info> get_list(string IdUsuario, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                List<GEN_001_Info> Lista;
                using (EntityTareas Context = new EntityTareas())
                {
                    Lista = (from q in Context.VWGEN_001
                             where q.IdUsuario == IdUsuario
                             && q.FechaInicioSubtarea == fechaInicio
                             && q.FechaFinSubtarea == fechaFin
                             select new GEN_001_Info
                             {
                                 Descripcion = q.Descripcion,
                                 eSTADO = q.eSTADO,
                                 EstadoActual = q.EstadoActual,
                                 FechaFinSubtarea = q.FechaFinSubtarea,
                                 FechaFinTarea = q.FechaFinTarea,
                                 FechaInicioSubtarea = q.FechaInicioSubtarea,
                                 FechaInicioTarea = q.FechaInicioTarea,
                                 FechaTerminoTarea = q.FechaTerminoTarea,
                                 IdGrupo = q.IdGrupo,
                                 IdTarea = q.IdTarea, 
                                 IdUsuario = q.IdUsuario,
                                 IdUsuarioAsignado = q.IdUsuarioAsignado,
                                 IdUsuarioSolicitante = q.IdUsuarioSolicitante,
                                 Nombre = q.Nombre,
                                 NombreGrupo = q.NombreGrupo,
                                 NumHoras = q.NumHoras,
                                 NumHorasReales = q.NumHorasReales,
                                 Observacion = q.Observacion,
                                 Secuancial = q.Secuancial

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
