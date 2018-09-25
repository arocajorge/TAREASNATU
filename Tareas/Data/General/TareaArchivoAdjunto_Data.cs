using Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   public class TareaArchivoAdjunto_Data
    {
        public List<TareaArchivoAdjunto_Info> get_lis(decimal IdTarea)
        {
            try
            {
                List<TareaArchivoAdjunto_Info> Lista = new List<TareaArchivoAdjunto_Info>();

                using (EntityTareas Context = new EntityTareas())
                {
                    Lista = (from q in Context.TareaArchivoAdjunto
                             where q.IdTarea == IdTarea
                             select new TareaArchivoAdjunto_Info
                             {
                                 IdTarea = q.IdTarea,
                                 Secuencial = q.Secuencial,
                                 NombreArchivo = q.NombreArchivo,
                             }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TareaArchivoAdjunto_Info get_info(decimal IdTarea, int Secuancial)
        {
            try
            {
                TareaArchivoAdjunto_Info info = new TareaArchivoAdjunto_Info();

                using (EntityTareas Context = new EntityTareas())
                {
                    TareaArchivoAdjunto Entity = Context.TareaArchivoAdjunto.FirstOrDefault(q => q.IdTarea == IdTarea && q.Secuencial==Secuancial);
                    if (Entity == null)
                        return null;

                    info = new TareaArchivoAdjunto_Info
                    {
                        IdTarea = Entity.IdTarea,
                        Secuencial = Entity.Secuencial,
                        NombreArchivo = Entity.NombreArchivo,
                        Archivo=Entity.Archivo

                    };
                }

                return info;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
