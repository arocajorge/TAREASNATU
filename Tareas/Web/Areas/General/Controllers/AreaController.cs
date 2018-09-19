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
    public class AreaController : Controller
    {
        #region Index
        Area_Bus bus_usuario = new Area_Bus();
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_area()
        {
            List<Area_Info> model = new List<Area_Info>();
            model = bus_usuario.get_lis();
            return PartialView("_GridViewPartial_area", model);
        }

        #endregion

        #region Acciones

        public ActionResult Nuevo()
        {
            Area_Info model = new Area_Info();
            return View(model);
        }

        [HttpPost]
        public ActionResult Nuevo(Area_Info model)
        {
            model.IdUsuario = SessionTareas.IdUsuario.ToString();
            if (!bus_usuario.guardarDB(model))
            {
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Modificar(int IdArea = 0)
        {
            Area_Info model = bus_usuario.get_info(IdArea);
            if (model == null)
                return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost]
        public ActionResult Modificar(Area_Info model)
        {
            model.IdUsuario = SessionTareas.IdUsuario.ToString();
            if (!bus_usuario.modificarDB(model))
            {
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Anular(int IdArea = 0)
        {
            Area_Info model = bus_usuario.get_info(IdArea);
            if (model == null)
                return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost]
        public ActionResult Anular(Area_Info model)
        {
            model.IdUsuario = SessionTareas.IdUsuario.ToString();

            if (!bus_usuario.anularDB(model))
            {
                return View(model);
            }
            return RedirectToAction("Index");
        }
        #endregion
    }
}