using Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   public class Estado_Data
    {
        public List<Estado_Info> get_lis(int IdEstadoTipo)
        {
            try
            {
                List<Estado_Info> Lista = new List<Estado_Info>();

                using (EntityTareas Context = new EntityTareas())
                {
                    Lista = (from q in Context.Estado
                             where q.IdEstadoTipo==IdEstadoTipo
                             select new Estado_Info
                             {
                                 IdEstado = q.IdEstado,
                                 IdEstadoTipo=q.IdEstadoTipo,
                                 Descripcion = q.Descripcion,
                                 Estado1 = q.Estado1
                             }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool guardarDB(Estado_Info info)
        {
            try
            {
                using (EntityTareas Context = new EntityTareas())
                {
                    Estado Entity = new Estado
                    {
                        IdEstado = info.IdEstado = get_id(info.IdEstadoTipo),
                        Descripcion = info.Descripcion,
                        IdEstadoTipo=info.IdEstadoTipo,
                        Estado1 = true,
                        FechaTransaccion = info.FechaTransaccion = DateTime.Now,
                        IdUsuario=info.IdUsuario
                    };
                    Context.Estado.Add(Entity);
                    Context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool modificarDB(Estado_Info info)
        {
            try
            {
                using (EntityTareas Context = new EntityTareas())
                {
                    var Entity = Context.Estado.Where(v => v.IdEstado == info.IdEstado && v.IdEstadoTipo == info.IdEstadoTipo).FirstOrDefault();
                    if (Entity == null)
                        return false;
                    Entity.Descripcion = info.Descripcion;
                    Entity.IdEstadoTipo = info.IdEstadoTipo;
                    Entity.IdUsuarioModifica = info.IdUsuarioModifica;

                    Entity.FechaModificacion = info.FechaModificacion = DateTime.Now;
                    Context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool anularDB(Estado_Info info)
        {
            try
            {
                using (EntityTareas Context = new EntityTareas())
                {
                    var Entity = Context.Estado.Where(v => v.IdEstado == info.IdEstado && v.IdEstadoTipo==info.IdEstadoTipo).FirstOrDefault();
                    if (Entity == null)
                        return false;
                    Entity.Estado1 = false;
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
        public int get_id( int IdEstadoTipo)
        {
            try
            {
                int ID = 1;
                using (EntityTareas Context = new EntityTareas())
                {
                    var lst = from q in Context.Estado
                              where q.IdEstadoTipo== IdEstadoTipo
                              select q;
                    if (lst.Count() > 0)
                        ID = lst.Max(q => q.IdEstado) + 1;
                }
                return ID;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Estado_Info get_info(int IdEstadoTipo, int IdEstado)
        {
            try
            {
                Estado_Info info = new Estado_Info();
                using (EntityTareas Context = new EntityTareas())
                {
                    Estado Entity = Context.Estado.FirstOrDefault(q => q.IdEstado == IdEstado && q.IdEstadoTipo== IdEstadoTipo);
                    if (Entity == null) return null;

                    info = new Estado_Info
                    {
                        IdEstado = Entity.IdEstado,
                        Descripcion = Entity.Descripcion,
                        IdEstadoTipo=Entity.IdEstadoTipo
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
