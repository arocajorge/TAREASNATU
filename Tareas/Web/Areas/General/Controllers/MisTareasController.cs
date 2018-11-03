using Bus;
using DevExpress.Web.Mvc;
using Info;
using Info.Helps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Helps;
namespace Web.Areas.General.Controllers
{
    [SessionTimeout]
    public class MisTareasController : Controller
    {
        Tarea_Bus bus_tarea ;
      

        public ActionResult CargaLaboral()
        {
            bus_tarea = new Tarea_Bus();
            cargar_combo();
            Tarea_Info model = new Tarea_Info();
            Grupo_Bus bus_grupo = new Grupo_Bus();
            model = bus_tarea.get_carga_laboral(0, SessionTareas.IdUsuario, DateTime.Now.Date, DateTime.Now.Date);
            if (model == null)
                model = new Tarea_Info
                {
                    IdUsuario =SessionTareas.IdUsuario,
                };
            model.IdGrupoFiltro = null;
            model.FechaInicio = DateTime.Now.Date;
            model.FechaFin = DateTime.Now.Date;
            return View(model);
        }
        [HttpPost]
        public ActionResult CargaLaboral(Tarea_Info model)
        {
            bus_tarea = new Tarea_Bus();
            string IdUsuario = model.IdUsuario;
            cargar_combo();
             model = bus_tarea.get_carga_laboral(model.IdGrupoFiltro==null?0:Convert.ToInt32(model.IdGrupoFiltro), model.IdUsuario, model.FechaInicio, model.FechaFin);
            if(model==null)
            {
                model = new Tarea_Info
                {
                    FechaEntrega = DateTime.Now,
                    IdUsuario = IdUsuario
                };
            }
            if (model.IdGrupoFiltro == 0)
                model.IdGrupoFiltro = null;
            return View(model);
        }

       
        public ActionResult Por_aprobar()
        {
            cl_filtros_Info model = new cl_filtros_Info();

            return View(model);
        }
        [HttpPost]
        public ActionResult Por_aprobar(cl_filtros_Info model)
        {
            return View(model);
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartial_por_aprobar()
        {
            bus_tarea = new Tarea_Bus();
            List<Tarea_Info> model = new List<Tarea_Info>();
            model = bus_tarea.get_lis_x_aprobar(SessionTareas.IdUsuario);
            return PartialView("_GridViewPartial_por_aprobar", model);
        }


      
        public void cargar_combo_detalle()
        {
            try
            {

                Estado_Bus bus_estado = new Estado_Bus();
                Grupo_Bus bus_grupo = new Grupo_Bus();
                var list_estado_detalle = bus_estado.get_lis(3);
                ViewBag.list_estado_detalle = list_estado_detalle;
                


            }
            catch (Exception)
            {

                throw;
            }
        }

        public void cargar_combo()
        {
            try
            {

                Estado_Bus bus_estado = new Estado_Bus();
                Grupo_Bus bus_grupo = new Grupo_Bus();
                Usuario_Bus bus_usuario = new Usuario_Bus();
                var list_estado_detalle = bus_estado.get_lis(3);
                ViewBag.list_estado_detalle = list_estado_detalle;

                var list_grupo = bus_grupo.get_lis(false);
                ViewBag.list_grupo = list_grupo;

                var list_usuario = bus_usuario.get_lis(false);
                ViewBag.list_usuario = list_usuario;
                

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}