using Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   public class Tarea_det_Data
    {

        public List<Tarea_det_Info> get_lis(decimal IdTarea, string IdUsuario)
        {
            try
            {
                List<Tarea_det_Info> Lista = new List<Tarea_det_Info>();

                using (EntityTareas Context = new EntityTareas())
                {
                    Lista = (from q in Context.Tarea_det
                             where q.IdTarea== IdTarea
                             && q.IdUsuario==IdUsuario
                             && q.IdEstado==8
                             orderby q.FechaFin ascending
                             select new Tarea_det_Info
                             {
                                 IdTarea = q.IdTarea,
                                 Secuancial = q.Secuancial,
                                 Descripcion=q.Descripcion,
                                 NumHoras=q.NumHoras,
                                 FechaInicio=q.FechaInicio,
                                 FechaFin=q.FechaFin,
                                 IdUsuario=q.IdUsuario,
                                 IdEstado=q.IdEstado
                                

                             }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Tarea_det_Info> get_lis(decimal IdTarea)
        {
            try
            {
                List<Tarea_det_Info> Lista = new List<Tarea_det_Info>();

                using (EntityTareas Context = new EntityTareas())
                {
                    Lista = (from q in Context.Tarea_det
                             where q.IdTarea == IdTarea
                            
                             select new Tarea_det_Info
                             {
                                 IdTarea = q.IdTarea,
                                 Secuancial = q.Secuancial,
                                 Descripcion = q.Descripcion,
                                 NumHoras = q.NumHoras,
                                 FechaInicio = q.FechaInicio,
                                 FechaFin = q.FechaFin,
                                 IdUsuario=q.IdUsuario,
                                 IdEstado=q.IdEstado


                             }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool cambiar_estado(Tarea_det_Info info)
        {
            try
            {
                using (EntityTareas Context = new EntityTareas())
                {
                    var Entity = Context.Tarea_det.Where(v => v.IdTarea == info.IdTarea && v.Secuancial== info.Secuancial).FirstOrDefault();
                    if (Entity == null)
                        return false;
                    Entity.Observacion = info.Observacion;
                    Entity.FechaTerminoTarea = DateTime.Now;
                    Entity.IdEstado = info.IdEstado;
                    Context.SaveChanges();
                    return true;
                }
                }
            catch (Exception)
            {
            
                throw;
            }
        }
    }
}
