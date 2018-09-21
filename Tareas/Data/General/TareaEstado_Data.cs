using Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   public class TareaEstado_Data
    {
        public List<TareaEstado_Info> get_lis()
        {
            try
            {
                List<TareaEstado_Info> Lista = new List<TareaEstado_Info>();

                using (EntityTareas Context = new EntityTareas())
                {
                    Lista = (from q in Context.TareaEstado
                             select new TareaEstado_Info
                             {
                                 IdTarea = q.IdTarea,
                                 Secuancial = q.Secuancial,
                                 FechaModificacion = q.FechaModificacion,
                                 IdUsuario = q.IdUsuario,
                                 IdEstado = q.IdEstado
                             }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool guardarDB(TareaEstado_Info info)
        {
            try
            {
                using (EntityTareas Context = new EntityTareas())
                {
                    TareaEstado Entity = new TareaEstado
                    {
                        IdTarea = info.IdTarea,
                        IdUsuario = info.IdUsuario,
                       Secuancial=info.Secuancial=get_id(info.IdTarea),
                       Observacion=info.Observacion,
                       FechaModificacion=DateTime.Now
                    };
                    Context.SaveChanges();
                    Context.TareaEstado.Add(Entity);
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
   
        public int get_id( decimal IdTarea)
        {
            try
            {
                int ID = 1;
                using (EntityTareas Context = new EntityTareas())
                {
                    var lst = from q in Context.TareaEstado
                              where q.IdTarea== IdTarea
                              select q;
                    if (lst.Count() > 0)
                        ID = lst.Max(q => q.Secuancial) + 1;
                }
                return ID;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
