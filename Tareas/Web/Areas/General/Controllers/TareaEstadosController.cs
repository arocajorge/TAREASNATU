using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Info.General;
using Bus.General;
using Bus;
using Info;
using Web.Helps;
using DevExpress.Web.Mvc;

namespace Web.Areas.General.Controllers
{
    [SessionTimeout]
    public class TareaEstadosController : Controller
    {
        Usuario_Bus bus_usuario = new Usuario_Bus();
        Estado_Bus bus_estado = new Estado_Bus();
        TareaEstado_Bus bus_tarea_estado = new TareaEstado_Bus();
        Tarea_Bus bus_tarea = new Tarea_Bus();

        [ValidateInput(false)]
        public ActionResult GridViewPartial_tarea_det_estados(decimal IdTarea=0)
        {
            cargar_combo_detalle();
            ViewBag.IdTarea = IdTarea;
            SessionTareas.IdTarea = IdTarea.ToString();
            List<TareaEstado_Info> model =new List<TareaEstado_Info>();
            model = bus_tarea_estado.get_lis(IdTarea).OrderBy(q=>q.FechaModificacion).ToList();
            return PartialView("_GridViewPartial_tarea_det_estados", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditingAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] TareaEstado_Info info_det)
        {
            if (info_det != null)
                if (!string.IsNullOrEmpty(info_det.Observacion))
                {
                    bus_tarea_estado.guardarDB(new TareaEstado_Info
                    {
                        IdTarea = Convert.ToDecimal(SessionTareas.IdTarea),
                        IdUsuario = SessionTareas.IdUsuario,
                        Observacion = info_det.Observacion,
                        IdEstado = bus_tarea.get_info(Convert.ToDecimal(SessionTareas.IdTarea)).EstadoActual ?? 0
                    });
                }
            cargar_combo_detalle();
            List<TareaEstado_Info> model = new List<TareaEstado_Info>();
            model = bus_tarea_estado.get_lis(Convert.ToDecimal(SessionTareas.IdTarea)).OrderBy(q => q.FechaModificacion).ToList();
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