using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Info.General;
using Bus.General;
using Bus;
using Info;
namespace Web.Areas.General.Controllers
{
    public class TareaEstadosController : Controller
    {
        Usuario_Bus bus_usuario = new Usuario_Bus();
        Estado_Bus bus_estado = new Estado_Bus();
        TareaEstado_Bus bus_tarea_estado = new TareaEstado_Bus();
            [ValidateInput(false)]
        public ActionResult GridViewPartial_tarea_det_estados(decimal IdTarea=0)
        {
            cargar_combo_detalle();
            ViewBag.IdTarea = IdTarea;
            List<TareaEstado_Info> model =new List<TareaEstado_Info>();
            model = bus_tarea_estado.get_lis(IdTarea);
            return PartialView("_GridViewPartial_tarea_det_estados", model);
        }

        public void cargar_combo_detalle()
        {
            try
            {

                var list_usuarios = bus_usuario.get_lis(false);
                ViewBag.list_usuarios = list_usuarios;

                var list_estado_detalle = bus_estado.get_lis(1);
                ViewBag.list_estado_detalle = list_estado_detalle;



            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}