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
    public class ParametroController : Controller
    {
        Parametro_Bus bus_pare = new Parametro_Bus();
        Estado_Bus bus_estado = new Estado_Bus();
        // GET: General/Parametro
        public ActionResult Index()
        {
            Parametro_Info model = bus_pare.get_info();
            ViewBag.lis_estado = bus_estado.get_lis(1);
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(Parametro_Info model)
        {
            bus_pare.grabarDB(model);
            ViewBag.lis_estado = bus_estado.get_lis(1);
            return View(model);
        }
    }
}