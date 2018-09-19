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
    public class DepartamentoController : Controller
    {
        #region Index
        Departamento_Bus bus_usuario = new Departamento_Bus();
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_departamento()
        {
            List<Departamento_Info> model = new List<Departamento_Info>();
            model = bus_usuario.get_lis();
            return PartialView("_GridViewPartial_departamento", model);
        }

        #endregion

        #region Acciones

        public ActionResult Nuevo()
        {
            Departamento_Info model = new Departamento_Info();
            return View(model);
        }

        [HttpPost]
        public ActionResult Nuevo(Departamento_Info model)
        {
            model.IdUsuario = SessionTareas.IdUsuario.ToString();

            if (!bus_usuario.guardarDB(model))
            {
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Modificar(int IdDepartamento = 0)
        {
            Departamento_Info model = bus_usuario.get_info(IdDepartamento);
            if (model == null)
                return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost]
        public ActionResult Modificar(Departamento_Info model)
        {
            model.IdUsuario = SessionTareas.IdUsuario.ToString();

            if (!bus_usuario.modificarDB(model))
            {
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Anular(int IdDepartamento = 0)
        {
            Departamento_Info model = bus_usuario.get_info(IdDepartamento);
            if (model == null)
                return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost]
        public ActionResult Anular(Departamento_Info model)
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