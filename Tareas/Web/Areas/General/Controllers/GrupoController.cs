﻿using Bus;
using DevExpress.Web.Mvc;
using Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Helps;

namespace Web.Areas.General.Controllers
{
    public class GrupoController : Controller
    {
        #region Variables
        Usuario_Bus bus_usuarios = new Usuario_Bus();
        Grupo_Usuario_Bus bus_grupo_det = new Grupo_Usuario_Bus();
        Grupo_Usuario_Info_lis Lis_Grupo_Usuario_Info_lis = new Grupo_Usuario_Info_lis();
        #endregion

        #region Index
        Grupo_Bus bus_Grupo = new Grupo_Bus();
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_Grupo()
        {
            List<Grupo_Info> model = new List<Grupo_Info>();
            model = bus_Grupo.get_lis();
            return PartialView("_GridViewPartial_Grupo", model);
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartial_grupo_det()
        {
            cargar_combo();
            Grupo_Info model = new Grupo_Info();
            model.list_grupo_usuario = Lis_Grupo_Usuario_Info_lis.get_list();
            return PartialView("_GridViewPartial_grupo_det", model);
        }

        #endregion

        #region Acciones

        public ActionResult Nuevo()
        {
            Grupo_Info model = new Grupo_Info();
            Lis_Grupo_Usuario_Info_lis.set_list(new List<Grupo_Usuario_Info>());
            cargar_combo();
            return View(model);
        }

        [HttpPost]
        public ActionResult Nuevo(Grupo_Info model)
        {
            model.list_grupo_usuario = Lis_Grupo_Usuario_Info_lis.get_list();
            model.IdUsuarioCreacion = SessionTareas.IdUsuario.ToString();
            if (model.list_grupo_usuario==null)
            {
                cargar_combo();
                ViewBag.mensaje = "El grupo debe tener almenos un usuario miembro del grupo";
                return View(model);
            }
            else
            {
                if (model.list_grupo_usuario.Count() == 0)
                {
                    cargar_combo();
                    ViewBag.mensaje = "El grupo debe tener almenos un usuario miembro del grupo";
                    return View(model);
                }
            }
            if (!bus_Grupo.guardarDB(model))
            {
                cargar_combo();
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Modificar(int IdGrupo = 0)
        {
            Grupo_Info model = bus_Grupo.get_info(IdGrupo);
            model.list_grupo_usuario = bus_grupo_det.get_lis(IdGrupo);
            Lis_Grupo_Usuario_Info_lis.set_list(model.list_grupo_usuario);
            cargar_combo();
            if (model == null)
                return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost]
        public ActionResult Modificar(Grupo_Info model)
        {
            model.list_grupo_usuario = Lis_Grupo_Usuario_Info_lis.get_list();
            model.IdUsuarioModifica = SessionTareas.IdUsuario.ToString();
            if (model.list_grupo_usuario == null)
            {
                cargar_combo();
                ViewBag.mensaje = "El grupo debe tener almenos un usuario miembro del grupo";
                return View(model);
            }
            else
            {
                if (model.list_grupo_usuario.Count() == 0)
                {
                    cargar_combo();
                    ViewBag.mensaje = "El grupo debe tener almenos un usuario miembro del grupo";
                    return View(model);
                }
            }
            if (!bus_Grupo.modificarDB(model))
            {
                cargar_combo();
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Anular(int IdGrupo = 0)
        {
            Grupo_Info model = bus_Grupo.get_info(IdGrupo);
            model.list_grupo_usuario = bus_grupo_det.get_lis(IdGrupo);
            Lis_Grupo_Usuario_Info_lis.set_list(model.list_grupo_usuario);
            cargar_combo();
            if (model == null)
                return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost]
        public ActionResult Anular(Grupo_Info model)
        {
            model.IdUsuarioAnula = SessionTareas.IdUsuario.ToString();


            if (!bus_Grupo.anularDB(model))
            {
                cargar_combo();

                return View(model);
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region cargar combo
        public void cargar_combo()
        {
            try
            {
                var list_usuarios = bus_usuarios.get_lis(false);
                ViewBag.list_usuarios = list_usuarios;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region funciones del detalle
        [HttpPost, ValidateInput(false)]
        public ActionResult EditingAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Grupo_Usuario_Info info_det)
        {
            if (ModelState.IsValid)
                Lis_Grupo_Usuario_Info_lis.AddRow(info_det);
            Grupo_Info model = new Grupo_Info();
            model.list_grupo_usuario = Lis_Grupo_Usuario_Info_lis.get_list();
            cargar_combo();
            return PartialView("_GridViewPartial_grupo_det", model);
        }

      
        public ActionResult EditingDelete([ModelBinder(typeof(DevExpressEditorsBinder))] Grupo_Usuario_Info info_det)
        {
            Lis_Grupo_Usuario_Info_lis.DeleteRow(info_det.IdUsuario);
            Grupo_Info model = new Grupo_Info();
            model.list_grupo_usuario = Lis_Grupo_Usuario_Info_lis.get_list();
            cargar_combo();
            return PartialView("_GridViewPartial_grupo_det", model);
        }
        #endregion


        #region json
        public JsonResult get_grupo(int IdGrupo = 0)
        {
           
            var resultado = bus_Grupo.get_info_grup_usuario(IdGrupo);

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }



    public class Grupo_Usuario_Info_lis
    {
        public List<Grupo_Usuario_Info> get_list()
        {
            if (HttpContext.Current.Session["Grupo_Usuario_Info"] == null)
            {
                List<Grupo_Usuario_Info> list = new List<Grupo_Usuario_Info>();

                HttpContext.Current.Session["Grupo_Usuario_Info"] = list;
            }
            return (List<Grupo_Usuario_Info>)HttpContext.Current.Session["Grupo_Usuario_Info"];
        }

        public void set_list(List<Grupo_Usuario_Info> list)
        {
            HttpContext.Current.Session["Grupo_Usuario_Info"] = list;
        }

        public void AddRow(Grupo_Usuario_Info info_det)
        {
            List<Grupo_Usuario_Info> list = get_list();
            list.Add(info_det);
        }

     
        public void DeleteRow(string IdUsuario)
        {
            List<Grupo_Usuario_Info> list = get_list();
            list.Remove(list.Where(m => m.IdUsuario == IdUsuario).First());
        }
    }
}
