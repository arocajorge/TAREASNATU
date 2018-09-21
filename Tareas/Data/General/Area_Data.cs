using Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
 public  class Area_Data
    {
        public List< Area_Info> get_lis()
        {
            try
            {
                List< Area_Info> Lista = new List< Area_Info>();

                using (EntityTareas Context = new EntityTareas())
                {
                    Lista = (from q in Context. Area
                             select new  Area_Info
                             {
                                 IdArea = q.IdArea,
                                 Descripcion = q.Descripcion,
                                 Estado=q.Estado
                             }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool guardarDB( Area_Info info)
        {
            try
            {
                using (EntityTareas Context = new EntityTareas())
                {
                     Area Entity = new  Area
                    {
                        IdArea = info.IdArea = get_id(),
                        Descripcion = info.Descripcion,
                         Estado = true,
                         FechaTransaccion=DateTime.Now,
                         IdUsuario=info.IdUsuario
                    };
                    Context. Area.Add(Entity);
                    Context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool modificarDB( Area_Info info)
        {
            try
            {
                using (EntityTareas Context = new EntityTareas())
                {
                    var Entity = Context. Area.Where(v => v.IdArea == info.IdArea).FirstOrDefault();
                    if (Entity == null)
                        return false;
                    Entity.Descripcion = info.Descripcion;
                    Entity.FechaModificacion = DateTime.Now;
                    Entity.IdUsuarioModifica = info.IdUsuarioModifica;
                    Context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool anularDB( Area_Info info)
        {
            try
            {
                using (EntityTareas Context = new EntityTareas())
                {
                    var Entity = Context. Area.Where(v => v.IdArea == info.IdArea).FirstOrDefault();
                    if (Entity == null)
                        return false;
                    Entity. Estado = false;
                    Entity.IdUsuarioModifica = info.IdUsuarioModifica;
                    Context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int get_id()
        {
            try
            {
                int ID = 1;
                using (EntityTareas Context = new EntityTareas())
                {
                    var lst = from q in Context. Area
                              select q;
                    if (lst.Count() > 0)
                        ID = lst.Max(q => q.IdArea) + 1;
                }
                return ID;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public  Area_Info get_info(int IdArea)
        {
            try
            {
                 Area_Info info = new  Area_Info();
                using (EntityTareas Context = new EntityTareas())
                {
                     Area Entity = Context. Area.FirstOrDefault(q => q.IdArea == IdArea);
                    if (Entity == null) return null;

                    info = new  Area_Info
                    {
                        IdArea = Entity.IdArea,
                        Descripcion = Entity.Descripcion
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
