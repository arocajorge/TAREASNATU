using Bus;
using Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.General.Controllers
{
    public class ParametroController : Controller
    {
        Parametro_Bus bus_pare = new Parametro_Bus();
        // GET: General/Parametro
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Parametro_Info model)
        {
            bus_pare.grabarDB(model);
            return View(model);
        }
    }
}