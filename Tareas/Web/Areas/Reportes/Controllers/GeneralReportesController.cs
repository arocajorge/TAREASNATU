using DevExpress.Web.Mvc;
using Bus;
using Info;
using Info.Helps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Reportes;

namespace Web.Areas.Reportes.Controllers
{
    public class GeneralReportesController : Controller
    {
        private void cargar_combos()
        {
            Usuario_Bus bus_usuario = new Usuario_Bus();
            var lst_usuario = bus_usuario.get_lis(false);
            lst_usuario.Add(new Usuario_Info
            {
                IdUsuario = "",
                Nombre = "TODOS"
            });
            ViewBag.lst_usuario = lst_usuario;
        }
        public ActionResult GEN_001()
        {
            cl_filtros_Info model = new cl_filtros_Info
            {
               IdUsuario = ""
            };
            cargar_combos();
            GEN_001_Rpt report = new GEN_001_Rpt();
            report.p_IdUsuario.Value = model.IdUsuario;
            report.p_fechaInicio.Value = model.fecha_ini;
            report.p_fechaFin.Value = model.fecha_fin;
            ViewBag.Report = report;
            return View(model);
        }
        [HttpPost]
        public ActionResult GEN_001(cl_filtros_Info model)
        {
            GEN_001_Rpt report = new GEN_001_Rpt();
            report.p_IdUsuario.Value = model.IdUsuario;
            report.p_fechaInicio.Value = model.fecha_ini;
            report.p_fechaFin.Value = model.fecha_fin;
            cargar_combos();
            ViewBag.Report = report;
            return View(model);
        }
        public ActionResult GEN_002()
        {
            cl_filtros_Info model = new cl_filtros_Info
            {
                IdUsuario = ""
            };
            cargar_combos();
            GEN_002_Rpt report = new GEN_002_Rpt();
            report.p_IdUsuario.Value = model.IdUsuario;
            report.p_fechaInicio.Value = model.fecha_ini;
            report.p_fechaFin.Value = model.fecha_fin;
            ViewBag.Report = report;
            return View(model);
        }
        [HttpPost]
        public ActionResult GEN_002(cl_filtros_Info model)
        {
            GEN_002_Rpt report = new GEN_002_Rpt();
            report.p_IdUsuario.Value = model.IdUsuario;
            report.p_fechaInicio.Value = model.fecha_ini;
            report.p_fechaFin.Value = model.fecha_fin;
            cargar_combos();
            ViewBag.Report = report;
            return View(model);
        }
    }
}