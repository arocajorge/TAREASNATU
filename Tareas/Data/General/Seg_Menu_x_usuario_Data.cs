using Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.General
{
   public class Seg_Menu_x_usuario_Data
    {
        public List<Seg_Menu_x_usuario_Info> get_list( string IdUsuario)
        {
            try
            {
                List<Seg_Menu_x_usuario_Info> Lista;

                using (EntityTareas Context = new EntityTareas())
                {
                    Lista = (from m in Context.Seg_Menu                           
                             join meu in Context.Seg_Menu_x_usuario
                             on new { m.IdMenu } equals new {meu.IdMenu }
                             where m.Habilitado == true 
                             && meu.IdUsuario == IdUsuario
                             select new Seg_Menu_x_usuario_Info
                             {
                                 seleccionado = true,
                                 IdUsuario = meu.IdUsuario,
                                 IdMenu = meu.IdMenu,
                                 Lectura = meu.Lectura,
                                 Escritura = meu.Escritura,
                                 Eliminacion = meu.Eliminacion,
                                 info_menu = new Seg_Menu_Info
                                 {
                                     IdMenu = m.IdMenu,
                                     DescripcionMenu = m.DescripcionMenu,
                                     IdMenuPadre = m.IdMenuPadre,
                                     PosicionMenu = m.PosicionMenu
                                 }
                             }).ToList();

                    Lista.AddRange((from q in Context.Seg_Menu
                                   
                                    where q.Habilitado == true 
                                    && !Context.Seg_Menu_x_usuario.Any(meu => meu.IdMenu == q.IdMenu && meu.IdUsuario == IdUsuario)
                                    select new Seg_Menu_x_usuario_Info
                                    {
                                        seleccionado = false,
                                        IdUsuario = IdUsuario,
                                        IdMenu = q.IdMenu,
                                        info_menu = new Seg_Menu_Info
                                        {
                                            IdMenu = q.IdMenu,
                                            DescripcionMenu = q.DescripcionMenu,
                                            IdMenuPadre = q.IdMenuPadre,
                                            PosicionMenu = q.PosicionMenu
                                        }

                                    }).ToList());
                }

                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Seg_Menu_x_usuario_Info> get_list( string IdUsuario, int IdMenuPadre)
        {
            try
            {
                List<Seg_Menu_x_usuario_Info> Lista;

                using (EntityTareas Context = new EntityTareas())
                {
                    Lista = (from m in Context.Seg_Menu
                             join me in Context.Seg_Menu_x_usuario
                             on m.IdMenu equals me.IdMenu
                             join meu in Context.Seg_Menu_x_usuario
                             on new {  me.IdMenu } equals new {meu.IdMenu }
                             where m.Habilitado == true 
                             && meu.IdUsuario == IdUsuario && m.IdMenuPadre == IdMenuPadre
                             orderby m.PosicionMenu
                             select new Seg_Menu_x_usuario_Info
                             {
                                 seleccionado = true,
                                 IdUsuario = meu.IdUsuario,
                                 IdMenu = meu.IdMenu,
                                 Lectura = meu.Lectura,
                                 Escritura = meu.Escritura,
                                 Eliminacion = meu.Eliminacion,
                                 info_menu = new Seg_Menu_Info
                                 {
                                     IdMenu = m.IdMenu,
                                     DescripcionMenu = m.DescripcionMenu,
                                     IdMenuPadre = m.IdMenuPadre,
                                     PosicionMenu = m.PosicionMenu,
                                     web_nom_Action = m.web_nom_Action,
                                     web_nom_Area = m.web_nom_Area,
                                     web_nom_Controller = m.web_nom_Controller
                                 }
                             }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool eliminarDB( string IdUsuario)
        {
            try
            {
                using (EntityTareas Context = new EntityTareas())
                {
                    Context.Database.ExecuteSqlCommand("DELETE Seg_Menu_x_usuario WHERE  IdUsuario = '" + IdUsuario + "'");
                }

                return true;
            }
            catch (Exception e)
            {

                throw;
            }
        }
        public bool guardarDB(List<Seg_Menu_x_usuario_Info> Lista, string IdUsuario)
        {
            try
            {
                using (EntityTareas Context = new EntityTareas())
                {
                    foreach (var item in Lista)
                    {
                        Seg_Menu_x_usuario Entity = new Data.Seg_Menu_x_usuario
                        {
                            IdUsuario = item.IdUsuario,
                            IdMenu = item.IdMenu,
                            Lectura = item.Lectura,
                            Escritura = item.Escritura,
                            Eliminacion = item.Eliminacion
                        };
                        Context.Seg_Menu_x_usuario.Add(Entity);
                    }

                    Context.SaveChanges();
                    //string sql = "exec spseg_corregir_menu '" + IdUsuario + "'";
                    //Context.Database.ExecuteSqlCommand(sql);

                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
