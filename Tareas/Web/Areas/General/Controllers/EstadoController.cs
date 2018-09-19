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
    public class EstadoController : Controller
    {
        EstadoTipo_Bus bus_estado_tipo = new EstadoTipo_Bus();
        #region Index
        Estado_Bus bus_usuario = new Estado_Bus();
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_estado(int IdEstadoTipo = 0)
        {
            List<Estado_Info> model = new List<Estado_Info>();
            model = bus_usuario.get_lis(IdEstadoTipo);
            return PartialView("_GridViewPartial_estado", model);
        }

        #endregion

        #region Acciones

        public ActionResult Nuevo()
        {
            Estado_Info model = new Estado_Info();
            cargar_combo();
            return View(model);
        }

        [HttpPost]
        public ActionResult Nuevo(Estado_Info model)
        {
            model.IdUsuario = SessionTareas.IdUsuario.ToString();
            if (!bus_usuario.guardarDB(model))
            {
                cargar_combo();

                return View(model);
            }
            ViewBag.IdEstadoTipo = model.IdEstadoTipo;
            return RedirectToAction("Index");
        }

        public ActionResult Modificar(int IdEstado = 0)
        {
            Estado_Info model = bus_usuario.get_info(IdEstado);
            if (model == null)
                return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost]
        public ActionResult Modificar(Estado_Info model)
        {

            model.IdUsuarioModifica = SessionTareas.IdUsuario.ToString();
            if (!bus_usuario.modificarDB(model))
            {
                cargar_combo();
                return View(model);
            }
            ViewBag.IdEstadoTipo = model.IdEstadoTipo;
            return RedirectToAction("Index");
        }

        public ActionResult Anular(int IdEstado = 0)
        {
            Estado_Info model = bus_usuario.get_info(IdEstado);
            cargar_combo();
            if (model == null)
                return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost]
        public ActionResult Anular(Estado_Info model)
        {
            model.IdUsuarioAnula = SessionTareas.IdUsuario.ToString();
            if (!bus_usuario.anularDB(model))
            {
                cargar_combo();
                return View(model);
            }
            ViewBag.IdEstadoTipo = model.IdEstadoTipo;
            return RedirectToAction("Index");
        }

        private void cargar_combo()
        {

            try
            {
                var lis_estado_tipo = bus_estado_tipo.get_lis();
                ViewBag.lis_estado_tipo = lis_estado_tipo;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}