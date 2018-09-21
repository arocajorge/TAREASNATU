using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Info.General;
using Bus.General;
using Web.Helps;
namespace Web.Areas.General.Controllers
{
    public class MenuController : Controller
    {
        #region Index/Metodos

        Seg_Men_Bus bus_menu = new Seg_Men_Bus();
        public ActionResult Index()
        {
            return View();
        }
        private void cargar_combos()
        {
            var lst_menu = bus_menu.get_list_combo(false);
            lst_menu.Add(new Seg_Menu_Info { DescripcionMenu_combo = "== Seleccione ==" });
            ViewBag.lst_menu = lst_menu;
        }

        #endregion
        [ValidateInput(false)]
        public ActionResult TreeListPartial_menu()
        {
            List<Seg_Menu_Info> model = bus_menu.get_list(true);
            return PartialView("_TreeListPartial_menu", model);
        }

        #region Acciones

        public ActionResult Nuevo()
        {
            Seg_Menu_Info model = new Seg_Menu_Info();
            cargar_combos();
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(Seg_Menu_Info model)
        {
            model.IdUsuario = SessionTareas.IdUsuario.ToString();
            if (!bus_menu.guardarDB(model))
            {
                cargar_combos();
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Modificar(int IdMenu = 0)
        {
            Seg_Menu_Info model = bus_menu.get_info(IdMenu);
            if (model == null)
                return RedirectToAction("Index");
            cargar_combos();
            return View(model);
        }
        [HttpPost]
        public ActionResult Modificar(Seg_Menu_Info model)
        {
            model.IdUsuarioModifica = SessionTareas.IdUsuario.ToString();
            if (!bus_menu.modificarDB(model))
            {
                cargar_combos();
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Anular(int IdMenu = 0)
        {
            Seg_Menu_Info model = bus_menu.get_info(IdMenu);
            if (model == null)
                return RedirectToAction("Index");
            cargar_combos();
            return View(model);
        }
        [HttpPost]
        public ActionResult Anular(Seg_Menu_Info model)
        {
            model.IdUsuarioAnula = SessionTareas.IdUsuario.ToString();
            if (!bus_menu.anularDB(model))
            {
                cargar_combos();
                return View(model);
            }
            return RedirectToAction("Index");
        }
        #endregion
    }
}