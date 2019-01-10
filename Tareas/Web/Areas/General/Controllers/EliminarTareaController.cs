using Bus;
using Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.General.Controllers
{
    public class EliminarTareaController : Controller
    {
        Tarea_Bus bus_tarea = new Tarea_Bus();
        // GET: General/EliminarTarea
        public ActionResult Index()
        {
            Tarea_Info model = new Tarea_Info();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(Tarea_Info model)
        {
            try
            {
                if(bus_tarea.Eliminar(model))
                    model = new Tarea_Info();
            }
            catch (Exception EX)
            {
                ViewBag.mensaje = "No se ha podido eliminar la tarea "+EX.ToString();   
            }
            
            return View(model);
        }
        
    }
}