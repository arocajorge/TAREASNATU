using Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   public class Grupo_Data
    {
        public List<Grupo_Info> get_lis()
        {
            try
            {
                List<Grupo_Info> Lista = new List<Grupo_Info>();

                using (EntityTareas Context = new EntityTareas())
                {
                    Lista = (from q in Context.Grupo
                             select new Grupo_Info
                             {
                                 IdGrupo = q.IdGrupo,
                                 Descripcion = q.Descripcion,
                                 IdUsuario = q.IdUsuario,
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
        public bool guardarDB(Grupo_Info info)
        {
            try
            {
                using (EntityTareas Context = new EntityTareas())
                {
                    Grupo Entity = new Grupo
                    {
                        IdGrupo=info.IdGrupo=get_id(),
                        IdUsuario=info.IdUsuario,
                        Descripcion=info.Descripcion,
                        Estado = true,
                        IdUsuarioCreacion=info.IdUsuarioCreacion,
                        FechaTransaccion=info.FechaTransaccion=DateTime.Now
                    };
                    Context.Grupo.Add(Entity);
                    foreach (var item in info.list_grupo_usuario)
                    {
                        Grupo_Usuario Detalle = new Grupo_Usuario
                        {
                            IdGrupo = info.IdGrupo,
                            IdUsuario = item.IdUsuario,
                            Observacion = item.Observacion
                        };
                        Context.Grupo_Usuario.Add(Detalle);
                    }
                    Context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool modificarDB(Grupo_Info info)
        {
            try
            {
                using (EntityTareas Context = new EntityTareas())
                {
                    var Entity = Context.Grupo.Where(v => v.IdGrupo == info.IdGrupo).FirstOrDefault();
                    if (Entity == null)
                        return false;
                    Entity.IdUsuario = info.IdUsuario;
                    Entity.Descripcion = info.Descripcion;
                    Entity.IdUsuarioModifica = info.IdUsuarioModifica;
                    Entity.FechaModificacion = DateTime.Now;
                    var resultado = Context.Grupo_Usuario.Where(v=>v.IdGrupo==info.IdGrupo);
                    Context.Grupo_Usuario.RemoveRange(resultado);
                    foreach(var item in info.list_grupo_usuario)
                    {
                        Grupo_Usuario Detalle = new Grupo_Usuario
                        {
                            IdGrupo = info.IdGrupo,
                            IdUsuario = item.IdUsuario,
                            Observacion = item.Observacion
                        };
                        Context.Grupo_Usuario.Add(Detalle);
                    }
                    Context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool anularDB(Grupo_Info info)
        {
            try
            {
                using (EntityTareas Context = new EntityTareas())
                {
                    var Entity = Context.Grupo.Where(v => v.IdGrupo == info.IdGrupo).FirstOrDefault();
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
                    var lst = from q in Context.Grupo
                              select q;
                    if (lst.Count() > 0)
                        ID = lst.Max(q => q.IdGrupo) + 1;
                }
                return ID;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Grupo_Info get_info(int IdGrupo)
        {
            try
            {
                Grupo_Info info = new Grupo_Info();
                using (EntityTareas Context = new EntityTareas())
                {
                    Grupo Entity = Context.Grupo.FirstOrDefault(q => q.IdGrupo == IdGrupo);
                    if (Entity == null) return null;

                    info = new Grupo_Info
                    {
                        IdUsuario = Entity.IdUsuario,
                        IdGrupo = Entity.IdGrupo,
                        Descripcion = Entity.Descripcion,
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


        public Grupo_Info get_info_grup_usuario(string IdUsuario)
        {
            try
            {
                Grupo_Info info = new Grupo_Info();
                using (EntityTareas Context = new EntityTareas())
                {
                    info = (from grupo in Context.Grupo
                            join usuario in Context.Usuario
                            on grupo.IdUsuario equals usuario.IdUsuario
                            where grupo.IdUsuario == IdUsuario
                            select new Grupo_Info
                            {
                                IdUsuario = grupo.IdUsuario,
                                IdGrupo = grupo.IdGrupo,
                                Descripcion = grupo.Descripcion,
                                Estado = grupo.Estado,
                                nomb_jef_grupo = usuario.Nombre

                            }).FirstOrDefault();
                }
                return info;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Grupo_Info get_info_grup_usuario(int IdGrupo)
        {
            try
            {
                Grupo_Info info = new Grupo_Info();
                using (EntityTareas Context = new EntityTareas())
                {
                     info = (from grupo in Context.Grupo
                                      join usuario in Context.Usuario
                                      on grupo.IdUsuario equals usuario.IdUsuario
                                       where grupo.IdGrupo==IdGrupo
                                      select new Grupo_Info
                                      {
                                          IdUsuario = grupo.IdUsuario,
                                          IdGrupo = grupo.IdGrupo,
                                          Descripcion = grupo.Descripcion,
                                          Estado = grupo.Estado,
                                          nomb_jef_grupo = usuario.Nombre

                                      }).FirstOrDefault();
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
