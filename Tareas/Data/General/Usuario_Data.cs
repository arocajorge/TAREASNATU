using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Info;
namespace Data
{
  public  class Usuario_Data
    {
        public List<Usuario_Info> get_lis(bool MostarAnulados)
        {
            try
            {
                List<Usuario_Info> Lista = new List<Usuario_Info>();

                using (EntityTareas Context=new EntityTareas())
                {
                    if(MostarAnulados)
                    Lista = (from q in Context.Usuario
                             select new Usuario_Info
                             {
                                IdUsuario=q.IdUsuario,
                                Clave=q.Clave,
                                Correo=q.Correo,
                                Nombre=q.Nombre,
                                Estado=q.Estado
                             }).ToList();
                    else
                        Lista = (from q in Context.Usuario
                                 where q.Estado==true
                                 select new Usuario_Info
                                 {
                                     IdUsuario = q.IdUsuario,
                                     Clave = q.Clave,
                                     Correo = q.Correo,
                                     Nombre = q.Nombre,
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
        public bool guardarDB(Usuario_Info info)
        {
            try
            {
                using (EntityTareas Context=new EntityTareas())
                {
                    Usuario Entity = new Usuario
                    {
                        IdUsuario = info.IdUsuario,
                        Clave = info.Clave,
                        Nombre = info.Nombre,
                        Correo = info.Correo,
                        Estado = true,
                        FechaTransaccion=info.FechaTransaccion=DateTime.Now,
                        IdUsuarioCreacion=info.IdUsuarioCreacion
                        
                    };
                    Context.Usuario.Add(Entity);
                    Context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
               
                throw;
            }
        }
        public bool modificarDB(Usuario_Info info)
        {
            try
            {
                using (EntityTareas Context = new EntityTareas())
                {
                    var Entity = Context.Usuario.Where(v=>v.IdUsuario==info.IdUsuario).FirstOrDefault();
                    if (Entity == null)
                        return false;
                    Entity.Nombre = info.Nombre;
                    Entity.Correo = info.Correo;
                    Entity.IdUsuarioModifica = info.IdUsuarioModifica;
                    Entity.FechaModificacion = info.FechaModificacion=DateTime.Now;
                    Context.SaveChanges();

                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool anularDB(Usuario_Info info)
        {
            try
            {
                using (EntityTareas Context = new EntityTareas())
                {
                    var Entity = Context.Usuario.Where(v => v.IdUsuario == info.IdUsuario).FirstOrDefault();
                    if (Entity == null)
                        return false;
                    Entity.Estado = false;
                    Entity.IdUsuarioAnula = info.IdUsuarioAnula;
                    Entity.FechaAnulacion = info.FechaModificacion=DateTime.Now;
                    Context.SaveChanges();

                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool si_existe(string IdUsuario)
        {
            try
            {
                using (EntityTareas Context = new EntityTareas())
                {
                    var Entity = Context.Usuario.Where(v => v.IdUsuario == IdUsuario).FirstOrDefault();
                    if (Entity == null)
                        return false;
                    else
                        return true;
                }


               
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool validar_login(string IdUsuario, string clave)
        {
            try
            {
                using (EntityTareas Context = new EntityTareas())
                {
                    var Entity = Context.Usuario.Where(v => v.IdUsuario == IdUsuario&& v.Clave==clave).FirstOrDefault();
                    if (Entity == null)
                        return false;
                    else
                        return true;
                }



            }
            catch (Exception)
            {
                throw;
            }
        }
        public Usuario_Info get_info(string IdUsuario)
        {
            try
            {
                Usuario_Info info = new Usuario_Info();
                using (EntityTareas Context = new EntityTareas())
                {
                    Usuario Entity = Context.Usuario.FirstOrDefault(q => q.IdUsuario == IdUsuario);
                    if (Entity == null) return null;

                    info = new Usuario_Info
                    {
                        IdUsuario = Entity.IdUsuario,
                        Clave = Entity.Clave,
                        Nombre = Entity.Nombre,
                        Correo = Entity.Correo,
                        Estado = Entity.Estado

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
