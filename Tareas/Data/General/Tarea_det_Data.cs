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

        public List<Tarea_det_Info> get_lis(decimal IdTarea)
        {
            try
            {
                List<Tarea_det_Info> Lista = new List<Tarea_det_Info>();

                using (EntityTareas Context = new EntityTareas())
                {
                    Lista = (from q in Context.Tarea_det
                             where q.IdTarea== IdTarea
                             select new Tarea_det_Info
                             {
                                 IdTarea = q.IdTarea,
                                 Secuancial = q.Secuancial,
                                 Descripcion=q.Descripcion,
                                 NumHoras=q.NumHoras,
                                 FechaInicio=q.FechaInicio,
                                 FechaFin=q.FechaFin
                                

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
