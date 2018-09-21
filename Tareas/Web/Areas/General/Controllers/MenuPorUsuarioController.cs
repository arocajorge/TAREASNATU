using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bus.General;
using Info.General;
using Bus;
using DevExpress.Web.Mvc;

namespace Web.Areas.General.Controllers
{
    public class MenuPorUsuarioController : Controller
    {
        #region Index

        static Seg_Menu_x_usuario_Bus bus_menu_x_empresa_x_usuario = new Seg_Menu_x_usuario_Bus();
        public ActionResult Index()
        {
            Seg_Menu_x_usuario_Info model = new Seg_Menu_x_usuario_Info();
            cargar_combos();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(Seg_Menu_x_usuario_Info model)
        {
            cargar_combos();
            return View(model);
        }
        public static void CreateTreeViewNodesRecursive(List<Seg_Menu_x_usuario_Info> model, MVCxTreeViewNodeCollection nodesCollection, Int32 parentID, int IdEmpresa = 0, string IdUsuario = "")
        {
            var rows = bus_menu_x_empresa_x_usuario.get_list( IdUsuario, parentID);

            foreach (Seg_Menu_x_usuario_Info row in rows)
            {
                var url = string.IsNullOrEmpty(row.info_menu.web_nom_Controller) ? null :
                    ("~/" + row.info_menu.web_nom_Area + "/" + row.info_menu.web_nom_Controller + "/" + row.info_menu.web_nom_Action + "/");
                MVCxTreeViewNode node = nodesCollection.Add(row.info_menu.DescripcionMenu, row.IdMenu.ToString(), null, url);
                CreateTreeViewNodesRecursive(model, node.Nodes, row.IdMenu, IdEmpresa, IdUsuario);
            }
        }
        private void cargar_combos()
        {
            

            Usuario_Bus bus_usuario = new Usuario_Bus();
            var lst_usuario = bus_usuario.get_lis(false);
            ViewBag.lst_usuario = lst_usuario;
        }
        #endregion

        [ValidateInput(false)]
        public ActionResult TreeListPartial_menu_x_usuario(string IdUsuario = "")
        {
            var model = bus_menu_x_empresa_x_usuario.get_list( IdUsuario);
            ViewBag.IdUsuario = IdUsuario;
            ViewData["selectedIDs"] = Request.Params["selectedIDs"];
            if (ViewData["selectedIDs"] == null)
            {
                int x = 0;
                string selectedIDs = "";
                foreach (var item in model.Where(q => q.seleccionado == true).ToList())
                {
                    if (x == 0)
                        selectedIDs = item.IdMenu.ToString();
                    else
                        selectedIDs += "," + item.IdMenu.ToString();
                    x++;
                }
                ViewData["selectedIDs"] = selectedIDs;
            }

            return PartialView("_TreeListPartial_menu_x_usuario", model);
        }

        public JsonResult guardar(int IdEmpresa = 0, string IdUsuario = "", string Ids = "")
        {
            string[] array = Ids.Split(',');

            List<Seg_Menu_x_usuario_Info> lista = new List<Seg_Menu_x_usuario_Info>();
            var output = array.GroupBy(q => q).ToList();
            foreach (var item in output)
            {
                if (!string.IsNullOrEmpty(item.Key))
                {
                    Seg_Menu_x_usuario_Info info = new Seg_Menu_x_usuario_Info
                    {
                        IdMenu = Convert.ToInt32(item.Key),
                        IdUsuario = IdUsuario
                    };
                    lista.Add(info);
                }
            }
            bus_menu_x_empresa_x_usuario.eliminarDB( IdUsuario);
            var resultado = bus_menu_x_empresa_x_usuario.guardarDB(lista,  IdUsuario);


            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
    }
}