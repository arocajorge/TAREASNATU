using Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   public class Departamento_Data
    {
        public List<Departamento_Info> get_lis()
        {
            try
            {
                List<Departamento_Info> Lista = new List<Departamento_Info>();

                using (EntityTareas Context = new EntityTareas())
                {
                    Lista = (from q in Context.Departamento
                             select new Departamento_Info
                             {
                                 IdDepartamento = q.IdDepartamento,
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
        public bool guardarDB(Departamento_Info info)
        {
            try
            {
                using (EntityTareas Context = new EntityTareas())
                {
                    Departamento Entity = new Departamento
                    {
                        IdDepartamento = info.IdDepartamento = get_id(),
                        Descripcion = info.Descripcion,
                        Estado = true,
                        IdUsuario=info.IdUsuario,
                        FechaTransaccion=info.FechaTransaccion=DateTime.Now
                    };
                    Context.Departamento.Add(Entity);
                    Context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool modificarDB(Departamento_Info info)
        {
            try
            {
                using (EntityTareas Context = new EntityTareas())
                {
                    var Entity = Context.Departamento.Where(v => v.IdDepartamento == info.IdDepartamento).FirstOrDefault();
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
        public bool anularDB(Departamento_Info info)
        {
            try
            {
                using (EntityTareas Context = new EntityTareas())
                {
                    var Entity = Context.Departamento.Where(v => v.IdDepartamento == info.IdDepartamento).FirstOrDefault();
                    if (Entity == null)
                        return false;
                    Entity.Estado = false;
                    Entity.FechaAnulacion = DateTime.Now;

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
                    var lst = from q in Context.Departamento
                              select q;
                    if (lst.Count() > 0)
                        ID = lst.Max(q => q.IdDepartamento) + 1;
                }
                return ID;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Departamento_Info get_info(int IdDepartamento)
        {
            try
            {
                Departamento_Info info = new Departamento_Info();
                using (EntityTareas Context = new EntityTareas())
                {
                    Departamento Entity = Context.Departamento.FirstOrDefault(q => q.IdDepartamento == IdDepartamento);
                    if (Entity == null) return null;

                    info = new Departamento_Info
                    {
                        IdDepartamento = Entity.IdDepartamento,
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
