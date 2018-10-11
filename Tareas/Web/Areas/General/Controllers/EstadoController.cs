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
    [SessionTimeout]
    public class EstadoController : Controller
    {
        EstadoTipo_Bus bus_estado_tipo = new EstadoTipo_Bus();
        #region Index
        Estado_Bus bus_usuario = new Estado_Bus();
        public ActionResult Index( int IdEstadoTipo)
        {
            ViewBag.IdEstadoTipo = IdEstadoTipo;
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_estado(int IdEstadoTipo = 0)
        {
            List<Estado_Info> model = new List<Estado_Info>();
            ViewBag.IdEstadoTipo = IdEstadoTipo;
            model = bus_usuario.get_lis(IdEstadoTipo);
            return PartialView("_GridViewPartial_estado", model);
        }

        #endregion

        #region Acciones

        public ActionResult Nuevo(int IdEstadoTipo=0)
        {
            Estado_Info model = new Estado_Info()
            {
                IdEstadoTipo = IdEstadoTipo
            };
            ViewBag.IdEstadoTipo = IdEstadoTipo;
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
            return RedirectToAction("Index",new { IdEstadoTipo = model.IdEstadoTipo });
        }

        public ActionResult Modificar(int IdEstadoTipo=0, int IdEstado = 0)
        {
            Estado_Info model = bus_usuario.get_info(IdEstadoTipo,IdEstado);
            if (model == null)
                return RedirectToAction("Index", new { IdEstadoTipo = IdEstadoTipo});
            ViewBag.IdEstadoTipo = IdEstadoTipo;
            cargar_combo();
            return View(model);
        }

        [HttpPost]
        public ActionResult Modificar(Estado_Info model)
        {

            model.IdUsuarioModifica = SessionTareas.IdUsuario.ToString();
            if (!bus_usuario.modificarDB(model))
            {
                ViewBag.IdEstadoTipo = model.IdEstadoTipo;
                cargar_combo();
                return View(model);
            }
            return RedirectToAction("Index", new { IdEstadoTipo = model.IdEstadoTipo });
        }

        public ActionResult Anular(int IdEstadoTipo, int IdEstado = 0)
        {
            Estado_Info model = bus_usuario.get_info(IdEstadoTipo, IdEstado);
            if (model == null)
                return RedirectToAction("Index", new { IdEstadoTipo = IdEstadoTipo });
            ViewBag.IdEstadoTipo = model.IdEstadoTipo;
            cargar_combo();
            return View(model);
        }

        [HttpPost]
        public ActionResult Anular(Estado_Info model)
        {
            model.IdUsuarioAnula = SessionTareas.IdUsuario.ToString();
            if (!bus_usuario.anularDB(model))
            {
                ViewBag.IdEstadoTipo = model.IdEstadoTipo;
                cargar_combo();
                return View(model);
            }
            return RedirectToAction("Index", new { IdEstadoTipo = model.IdEstadoTipo });
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