using Bus;
using DevExpress.Web.Mvc;
using Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Helps;
using Info.Helps;

namespace Web.Areas.General.Controllers
{
    [SessionTimeout]
    public class BuzonController : Controller
    {
        #region Variables
        Tarea_Bus bus_tarea = new Tarea_Bus();
        Grupo_Bus bus_grupo = new Grupo_Bus();
        Usuario_Bus bus_usuario = new Usuario_Bus();
        Estado_Bus bus_estado = new Estado_Bus();
        TareaArchivoAdjunto_Bus bus_adjunto = new TareaArchivoAdjunto_Bus();

        #endregion
        public ActionResult Buzon_entrada( String estado)
        {
            cl_filtros_Info model = new cl_filtros_Info();
            ViewBag.estado = estado;
            model.estado = estado;
            return View(model);
        }
        [HttpPost]
        public ActionResult Buzon_entrada(cl_filtros_Info model)
        {
            return View(model);
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartial_buzon_entrada(DateTime? fecha_ini, DateTime? fecha_fin, string estado)
        {
            List<Tarea_Info> model = new List<Tarea_Info>();
            ViewBag.fecha_ini = fecha_ini == null ? DateTime.Now.Date.AddMonths(-1) : fecha_ini;
            ViewBag.fecha_fin = fecha_fin == null ? DateTime.Now.Date.AddMonths(1) : fecha_fin;
            ViewBag.estado = estado;
            model = bus_tarea.get_lis(SessionTareas.IdUsuario.ToString(), cl_enumeradores.eTipoTarea.ASIGNADA, ViewBag.fecha_ini, ViewBag.fecha_fin);
            if (estado == "A") // APROBADAS
                model = model.Where(v => v.AprobadoEncargado == false).ToList();
            if (estado == "E") // ENTREGAR
                model = model.Where(v => v.AprobadoEncargado == true).ToList();
            if (estado == "V") // ENTREGAR
                model = model.Where(v => v.AprobadoEncargado == true && v.FechaEntrega.Date<DateTime.Now.Date).ToList();
            return PartialView("_GridViewPartial_buzon_entrada", model);
        }
        public ActionResult Buzon_salida()
        {
            cl_filtros_Info model = new cl_filtros_Info();

            return View(model);
        }
        [HttpPost]
        public ActionResult Buzon_salida(cl_filtros_Info model)
        {
            return View(model);
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartial_buzon_salida(DateTime? fecha_ini, DateTime? fecha_fin)
        {
            List<Tarea_Info> model = new List<Tarea_Info>();
            ViewBag.fecha_ini = fecha_ini == null ? DateTime.Now.Date.AddMonths(-1) : fecha_ini;
            ViewBag.fecha_fin = fecha_fin == null ? DateTime.Now.Date.AddMonths(1) : fecha_fin;
            model = bus_tarea.get_lis(ViewBag.fecha_ini, ViewBag.fecha_fin);

            model = bus_tarea.get_lis(SessionTareas.IdUsuario.ToString(), cl_enumeradores.eTipoTarea.GENERADAS, ViewBag.fecha_ini, ViewBag.fecha_fin);
            return PartialView("_GridViewPartial_buzon_salida", model);
        }

        public ActionResult Buzon_eliminado()
        {
            cl_filtros_Info model = new cl_filtros_Info();

            return View(model);
        }
        [HttpPost]
        public ActionResult Buzon_eliminado(cl_filtros_Info model)
        {
            return View(model);
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartial_buzon_eliminada(DateTime? fecha_ini, DateTime? fecha_fin)
        {
            List<Tarea_Info> model = new List<Tarea_Info>();
            ViewBag.fecha_ini = fecha_ini == null ? DateTime.Now.Date.AddMonths(-1) : fecha_ini;
            ViewBag.fecha_fin = fecha_fin == null ? DateTime.Now.Date.AddMonths(1) : fecha_fin;
            model = bus_tarea.get_lis(ViewBag.fecha_ini, ViewBag.fecha_fin);

            model = bus_tarea.get_lis_anulados(SessionTareas.IdUsuario.ToString(), ViewBag.fecha_ini, ViewBag.fecha_fin);
            return PartialView("_GridViewPartial_buzon_eliminada", model);
        }


    }
}