﻿using Bus;
using DevExpress.Web.Mvc;
using Info;
using Info.Helps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Helps;
namespace Web.Areas.General.Controllers
{
    [SessionTimeout]
    public class MisTareasController : Controller
    {
        Tarea_Bus bus_tarea ;
        Tarea_det_Bus bus_detalle ;
        public ActionResult Index()
        {
            cl_filtros_Info model = new cl_filtros_Info();
            return View(model);
        }

        public ActionResult CargaLaboral()
        {
            bus_tarea = new Tarea_Bus();
            cargar_combo();
            Tarea_Info model = new Tarea_Info();
            Grupo_Bus bus_grupo = new Grupo_Bus();
            var grupo = bus_grupo.get_info_grup_usuario(SessionTareas.IdUsuario);
            model = bus_tarea.get_carga_laboral(grupo.IdGrupo, SessionTareas.IdUsuario, DateTime.Now.Date, DateTime.Now.Date);
            if (model == null)
                model = new Tarea_Info
                {
                    IdUsuario =SessionTareas.IdUsuario
                };
            return View(model);
        }
        [HttpPost]
        public ActionResult CargaLaboral(Tarea_Info model)
        {
            bus_tarea = new Tarea_Bus();
            string IdUsuario = model.IdUsuario;
            cargar_combo();
             model = bus_tarea.get_carga_laboral(model.IdGrupoFiltro==null?0:Convert.ToInt32(model.IdGrupoFiltro), model.IdUsuario, DateTime.Now.Date, DateTime.Now.Date);
            if(model==null)
            {
                model = new Tarea_Info
                {
                    FechaCulmina = DateTime.Now,
                    IdUsuario = IdUsuario
                };
            }
            return View(model);
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_mis_tareas()
        {
            bus_tarea = new Tarea_Bus();
            List<Tarea_Info> model = new List<Tarea_Info>();
            string IdUsuario = "";
            if (SessionTareas.IdUsuario != null)
            {
                IdUsuario = SessionTareas.IdUsuario.ToString();
                model = bus_tarea.get_lis(IdUsuario);
                return PartialView("_GridViewPartial_mis_tareas", model);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartial_mis_tareas_det(decimal IdTarea=0)
        {
            cargar_combo_detalle();
            bus_detalle = new Tarea_det_Bus();
            ViewBag.IdTarea = IdTarea;
            string IdUsuario = "";
            if (SessionTareas.IdUsuario != null)
            {
                IdUsuario = SessionTareas.IdUsuario.ToString();
                Tarea_Info model = new Tarea_Info();
                model.list_detalle = bus_detalle.get_lis(IdTarea, IdUsuario);
                return PartialView("_GridViewPartial_mis_tareas_det", model.list_detalle);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult EditingUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Tarea_det_Info info_det)
        {
            bus_detalle = new Tarea_det_Bus();
            string IdUsuario = "";
            cargar_combo_detalle();
            if (SessionTareas.IdUsuario != null)
                {
                    IdUsuario = SessionTareas.IdUsuario.ToString();
                    Tarea_Info model = new Tarea_Info();
                    bus_detalle.cambiar_estado(info_det);
                    model.list_detalle = bus_detalle.get_lis(info_det.IdTarea, IdUsuario);
                return RedirectToAction("Index");
            }
            else
                {
                    return RedirectToAction("Login");
                }
        }


        public void cargar_combo_detalle()
        {
            try
            {

                Estado_Bus bus_estado = new Estado_Bus();
                Grupo_Bus bus_grupo = new Grupo_Bus();
                var list_estado_detalle = bus_estado.get_lis(3);
                ViewBag.list_estado_detalle = list_estado_detalle;
                


            }
            catch (Exception)
            {

                throw;
            }
        }

        public void cargar_combo()
        {
            try
            {

                Estado_Bus bus_estado = new Estado_Bus();
                Grupo_Bus bus_grupo = new Grupo_Bus();
                Usuario_Bus bus_usuario = new Usuario_Bus();
                var list_estado_detalle = bus_estado.get_lis(3);
                ViewBag.list_estado_detalle = list_estado_detalle;

                var list_grupo = bus_grupo.get_lis(false);
                ViewBag.list_grupo = list_grupo;

                var list_usuario = bus_usuario.get_lis(false);
                ViewBag.list_usuario = list_usuario;
                

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}