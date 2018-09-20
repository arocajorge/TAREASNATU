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
    public class  EstadoTipoController : Controller
    {
        #region Index
         EstadoTipo_Bus bus_usuario = new  EstadoTipo_Bus();
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_estado_tipo()
        {
            List< EstadoTipo_Info> model = new List< EstadoTipo_Info>();
            model = bus_usuario.get_lis();
            return PartialView("_GridViewPartial_estado_tipo", model);
        }

        #endregion

        #region Acciones

        public ActionResult Nuevo()
        {
            EstadoTipo_Info model = new EstadoTipo_Info()
            {
               
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Nuevo( EstadoTipo_Info model)
        {
            model.IdUsuario = SessionTareas.IdUsuario.ToString();
            if (!bus_usuario.guardarDB(model))
            {
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Modificar(int IdEstadoTipo = 0)
        {
             EstadoTipo_Info model = bus_usuario.get_info(IdEstadoTipo);
            if (model == null)
                return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost]
        public ActionResult Modificar( EstadoTipo_Info model)
        {
            model.IdUsuarioModifica = SessionTareas.IdUsuario.ToString();
            if (!bus_usuario.modificarDB(model))
            {
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Anular(int IdEstadoTipo = 0)
        {
             EstadoTipo_Info model = bus_usuario.get_info(IdEstadoTipo);
            if (model == null)
                return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost]
        public ActionResult Anular( EstadoTipo_Info model)
        {
            model.IdUsuarioAnula = SessionTareas.IdUsuario.ToString();
            if (!bus_usuario.anularDB(model))
            {
                return View(model);
            }
            return RedirectToAction("Index");
        }
        #endregion
    }
}