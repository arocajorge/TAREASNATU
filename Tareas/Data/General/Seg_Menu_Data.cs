using Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.General
{
   public class Seg_Menu_Data
    {
        public List<Seg_Menu_Info> get_list(bool mostrar_anulados)
        {
            try
            {
                List<Seg_Menu_Info> Lista;

                using (EntityTareas Context = new EntityTareas())
                {
                    if (mostrar_anulados)
                        Lista = (from q in Context.Seg_Menu
                                 select new Seg_Menu_Info
                                 {
                                     IdMenu = q.IdMenu,
                                     IdMenuPadre = q.IdMenuPadre,
                                     DescripcionMenu = q.DescripcionMenu,
                                     nivel = q.nivel,
                                     PosicionMenu = q.PosicionMenu,
                                     Habilitado = q.Habilitado,
                                 }).ToList();
                    else
                        Lista = (from q in Context.Seg_Menu
                                 where q.Habilitado == true
                                 select new Seg_Menu_Info
                                 {
                                     IdMenu = q.IdMenu,
                                     IdMenuPadre = q.IdMenuPadre,
                                     DescripcionMenu = q.DescripcionMenu,
                                     nivel = q.nivel,
                                     PosicionMenu = q.PosicionMenu,
                                     Habilitado = q.Habilitado,
                                 }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Seg_Menu_Info> get_list_combo(bool mostrar_anulados)
        {
            try
            {
                List<Seg_Menu_Info> Lista;

                using (EntityTareas Context = new EntityTareas())
                {
                    if (mostrar_anulados)
                        Lista = (from q in Context.Seg_Menu
                                 join m in Context.Seg_Menu
                                 on q.IdMenuPadre equals m.IdMenu into temp_padre
                                 from m in temp_padre.DefaultIfEmpty()
                                 join padre in Context.Seg_Menu
                                 on m.IdMenuPadre equals padre.IdMenu into temp_padre_padre
                                 from padre in temp_padre_padre.DefaultIfEmpty()
                                 select new Seg_Menu_Info
                                 {
                                     IdMenu = q.IdMenu,
                                     IdMenuPadre = q.IdMenuPadre,
                                     DescripcionMenu = q.DescripcionMenu,
                                     nivel = q.nivel,
                                     PosicionMenu = q.PosicionMenu,
                                     Habilitado = q.Habilitado,
                                     DescripcionMenu_combo = (padre == null ? "" : (padre.IdMenuPadre + " " + padre.DescripcionMenu + " - ")) + (m == null ? "" : (m.IdMenuPadre + " " + m.DescripcionMenu + " - ")) + q.IdMenuPadre + " " + q.DescripcionMenu

                                 }).ToList();
                    else
                        Lista = (from q in Context.Seg_Menu
                                 join m in Context.Seg_Menu
                                 on q.IdMenuPadre equals m.IdMenu into temp_padre
                                 from m in temp_padre.DefaultIfEmpty()
                                 join padre in Context.Seg_Menu
                                 on m.IdMenuPadre equals padre.IdMenu into temp_padre_padre
                                 from padre in temp_padre_padre.DefaultIfEmpty()
                                 where q.Habilitado == true
                                 select new Seg_Menu_Info
                                 {
                                     IdMenu = q.IdMenu,
                                     IdMenuPadre = q.IdMenuPadre,
                                     DescripcionMenu = q.DescripcionMenu,
                                     nivel = q.nivel,
                                     PosicionMenu = q.PosicionMenu,
                                     Habilitado = q.Habilitado,
                                     DescripcionMenu_combo = (padre == null ? "" : (padre.IdMenuPadre + " " + padre.DescripcionMenu + " - ")) + (m == null ? "" : (m.IdMenuPadre + " " + m.DescripcionMenu + " - ")) + q.IdMenuPadre + " " + q.DescripcionMenu
                                 }).ToList();
                }

                return Lista.OrderBy(q => q.DescripcionMenu_combo).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Seg_Menu_Info get_info(int IdMenu)
        {
            try
            {
                Seg_Menu_Info info = new Seg_Menu_Info();

                using (EntityTareas Context = new EntityTareas())
                {
                    Seg_Menu Entity = Context.Seg_Menu.FirstOrDefault(q => q.IdMenu == IdMenu);
                    if (Entity == null)
                        return null;
                    info = new Seg_Menu_Info
                    {
                        IdMenu = Entity.IdMenu,
                        IdMenuPadre = Entity.IdMenuPadre,
                        DescripcionMenu = Entity.DescripcionMenu,
                        PosicionMenu = Entity.PosicionMenu,
                        Tiene_FormularioAsociado = Entity.Tiene_FormularioAsociado,
                        web_nom_Area = Entity.web_nom_Area,
                        web_nom_Controller = Entity.web_nom_Controller,
                        web_nom_Action = Entity.web_nom_Action,
                        nivel = Entity.nivel,
                    };
                }

                return info;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private int get_id()
        {
            try
            {
                int ID = 1;

                using (EntityTareas Context = new EntityTareas())
                {
                    var lst = from q in Context.Seg_Menu
                              select q;

                    if (lst.Count() > 0)
                        ID = lst.Max(q => q.IdMenu) + 1;
                }

                return ID;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool guardarDB(Seg_Menu_Info info)
        {
            try
            {
                using (EntityTareas Context = new EntityTareas())
                {
                    Seg_Menu Entity = new Seg_Menu
                    {
                        IdMenu = get_id(),
                        IdMenuPadre = info.IdMenuPadre,
                        DescripcionMenu = info.DescripcionMenu,
                        PosicionMenu = info.PosicionMenu,
                        Habilitado = info.Habilitado = true,
                        Tiene_FormularioAsociado = info.Tiene_FormularioAsociado,
                        nivel = 1,
                        web_nom_Area = info.web_nom_Area,
                        web_nom_Controller = info.web_nom_Controller == null ? "" : info.web_nom_Controller,
                        web_nom_Action = info.web_nom_Action,
                        Estado=true,
                        FechaTransaccion=DateTime.Now,
                        IdUsuario=info.IdUsuario
                    };
                    Context.Seg_Menu.Add(Entity);
                    Context.SaveChanges();
                }

                return true;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public bool modificarDB(Seg_Menu_Info info)
        {
            try
            {
                using (EntityTareas Context = new EntityTareas())
                {
                    Seg_Menu Entity = Context.Seg_Menu.FirstOrDefault(q => q.IdMenu == info.IdMenu);
                    if (Entity == null) return false;
                    Entity.IdMenuPadre = info.IdMenuPadre;
                    Entity.DescripcionMenu = info.DescripcionMenu;
                    Entity.PosicionMenu = info.PosicionMenu;
                    Entity.Tiene_FormularioAsociado = info.Tiene_FormularioAsociado;
                    Entity.web_nom_Controller = info.web_nom_Controller == null ? "" : info.web_nom_Controller;
                    Entity.web_nom_Area = info.web_nom_Area;
                    Entity.web_nom_Action = info.web_nom_Action;
                    Entity.IdUsuarioModifica = info.IdUsuarioModifica;
                    Entity.FechaModificacion = DateTime.Now;
                    Context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool anularDB(Seg_Menu_Info info)
        {
            try
            {
                using (EntityTareas Context = new EntityTareas())
                {
                    Seg_Menu Entity = Context.Seg_Menu.FirstOrDefault(q => q.IdMenu == info.IdMenu);
                    if (Entity == null) return false;
                    Entity.Habilitado = info.Habilitado = false;
                    Entity.IdUsuarioAnula = info.IdUsuarioAnula;
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
    }
}
