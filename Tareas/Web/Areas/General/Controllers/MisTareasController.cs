using Bus;
using Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Helps;

namespace Web.Areas.General.Controllers
{
    public class MisTareasController : Controller
    {
        Tarea_Bus bus_tarea = new Tarea_Bus();
        Tarea_det_Bus bus_detalle = new Tarea_det_Bus();
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_mis_tareas()
        {
            List<Tarea_Info> model = new List<Tarea_Info>();
           
            model = bus_tarea.get_lis("");
            return PartialView("_GridViewPartial_mis_tareas", model);
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartial_mis_tareas_det(decimal IdTarea=0)
        {
            cargar_combo_detalle();
            Tarea_Info model = new Tarea_Info();
            model.list_detalle = bus_detalle.get_lis(IdTarea);
            return PartialView("_GridViewPartial_mis_tareas_det", model.list_detalle);
        }

        public void cargar_combo_detalle()
        {
            try
            {

                Estado_Bus bus_estado = new Estado_Bus();

                var list_estado_detalle = bus_estado.get_lis(3);
                ViewBag.list_estado_detalle = list_estado_detalle;

              

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}