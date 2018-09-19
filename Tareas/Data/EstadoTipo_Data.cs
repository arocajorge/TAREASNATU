using Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
  public  class EstadoTipoTipo_Data
    {
        public List<EstadoTipo_Info> get_lis()
        {
            try
            {
                List<EstadoTipo_Info> Lista = new List<EstadoTipo_Info>();

                using (EntityTareas Context = new EntityTareas())
                {
                    Lista = (from q in Context.EstadoTipo
                             select new EstadoTipo_Info
                             {
                                 IdEstadoTipo = q.IdEstadoTipo,
                                 Descripcion = q.Descripcion,
                                 Estado = q.Estado
                             }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool guardarDB(EstadoTipo_Info info)
        {
            try
            {
                using (EntityTareas Context = new EntityTareas())
                {
                    EstadoTipo Entity = new EstadoTipo
                    {
                        IdEstadoTipo = info.IdEstadoTipo = get_id(),
                        Descripcion = info.Descripcion,
                        Estado = true,
                        FechaTransaccion=info.FechaTransaccion=DateTime.Now,
                        IdUsuario=info.IdUsuario
                    };
                    Context.EstadoTipo.Add(Entity);
                    Context.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {

                throw;
            }
        }
        public bool modificarDB(EstadoTipo_Info info)
        {
            try
            {
                using (EntityTareas Context = new EntityTareas())
                {
                    var Entity = Context.EstadoTipo.Where(v => v.IdEstadoTipo == info.IdEstadoTipo).FirstOrDefault();
                    if (Entity == null)
                        return false;
                    Entity.Descripcion = info.Descripcion;
                    Entity.FechaModificacion = info.FechaModificacion=DateTime.Now;
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
        public bool anularDB(EstadoTipo_Info info)
        {
            try
            {
                using (EntityTareas Context = new EntityTareas())
                {
                    var Entity = Context.EstadoTipo.Where(v => v.IdEstadoTipo == info.IdEstadoTipo).FirstOrDefault();
                    if (Entity == null)
                        return false;
                    Entity.Estado = false;
                    Entity.FechaAnulacion = info.FechaAnulacion = DateTime.Now;
                    Entity.IdUsuarioAnula = info.IdUsuarioAnula;
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
                    var lst = from q in Context.EstadoTipo
                              select q;
                    if (lst.Count() > 0)
                        ID = lst.Max(q => q.IdEstadoTipo) + 1;
                }
                return ID;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public EstadoTipo_Info get_info(int IdEstadoTipo)
        {
            try
            {
                EstadoTipo_Info info = new EstadoTipo_Info();
                using (EntityTareas Context = new EntityTareas())
                {
                    EstadoTipo Entity = Context.EstadoTipo.FirstOrDefault(q => q.IdEstadoTipo == IdEstadoTipo);
                    if (Entity == null) return null;

                    info = new EstadoTipo_Info
                    {
                        IdEstadoTipo = Entity.IdEstadoTipo,
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
