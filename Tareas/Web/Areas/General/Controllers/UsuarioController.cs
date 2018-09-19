using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Info;
using Bus;
using Web.Helps;

namespace Web.Areas.General.Controllers
{
    public class UsuarioController : Controller
    {
        #region Index
        Usuario_Bus bus_usuario = new Usuario_Bus();
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_usuarios()
        {
            List<Usuario_Info> model = new List<Usuario_Info>();
            model = bus_usuario.get_lis(true);
            return PartialView("_GridViewPartial_usuarios", model);
        }

        #endregion
        #region Acciones

        public ActionResult Nuevo()
        {
            Usuario_Info model = new Usuario_Info();
            return View(model);
        }

        [HttpPost]
        public ActionResult Nuevo(Usuario_Info model)
        {
            model.IdUsuarioCreacion = SessionTareas.IdUsuario.ToString();

            if (!bus_usuario.guardarDB(model))
            {
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Modificar(string IdUsuario = "")
        {
            Usuario_Info model = bus_usuario.get_info(IdUsuario);
            if (model == null)
                return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost]
        public ActionResult Modificar(Usuario_Info model)
        {
            model.IdUsuarioModifica = SessionTareas.IdUsuario.ToString();

            if (!bus_usuario.modificarDB(model))
            {
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Anular(string IdUsuario)
        {
            Usuario_Info model = bus_usuario.get_info(IdUsuario);
            if (model == null)
                return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost]
        public ActionResult Anular(Usuario_Info model)
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