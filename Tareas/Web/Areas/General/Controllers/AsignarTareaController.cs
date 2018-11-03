using Bus;
using DevExpress.Web.Mvc;
using Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Helps;
using Info.Helps;

namespace Web.Areas.General.Controllers
{
    [SessionTimeout]
    public class AsignarTareaController : Controller
    {
        #region Variables
        Tarea_Bus bus_tarea = new Tarea_Bus();
        Grupo_Bus bus_grupo = new Grupo_Bus();
        Usuario_Bus bus_usuario = new Usuario_Bus();
        Estado_Bus bus_estado = new Estado_Bus();
        TareaArchivoAdjunto_Bus bus_adjunto = new TareaArchivoAdjunto_Bus();

        #endregion



        public ActionResult Index()
        {
            cl_filtros_Info model = new cl_filtros_Info();

            return View(model);
        }
        [HttpPost]
        public ActionResult Index(cl_filtros_Info model)
        {
            return View(model);
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartial_asignar_subtareas(DateTime? fecha_ini, DateTime? fecha_fin)
        {
            bus_tarea = new Tarea_Bus();
            List<Tarea_Info> model = new List<Tarea_Info>();
            ViewBag.fecha_ini = fecha_ini == null ? DateTime.Now.Date.AddMonths(-1) : fecha_ini;
            ViewBag.fecha_fin = fecha_fin == null ? DateTime.Now.Date.AddMonths(1) : fecha_fin;
            model = bus_tarea.get_lis(SessionTareas.IdUsuario, cl_enumeradores.eTipoTarea.ASIGNADA, ViewBag.fecha_ini, ViewBag.fecha_fin);

            return PartialView("_GridViewPartial_asignar_subtareas", model);
        }

        public ActionResult Nuevo(int IdTarea = 0)

        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionTareas.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionTareas.IdTransaccionSession = (Convert.ToDecimal(SessionTareas.IdTransaccionSession) + 1).ToString();
            SessionTareas.IdTransaccionSessionActual = SessionTareas.IdTransaccionSession;
            #endregion

            Tarea_Info model = bus_tarea.get_info(IdTarea);
            model.IdTransaccionSession = Convert.ToDecimal(SessionTareas.IdTransaccionSessionActual);
            model.list_adjuntos = bus_adjunto.get_lis(IdTarea);
            TareaArchivoAdjunto_Info_lis.set_list(model.list_adjuntos, model.IdTransaccionSession);
            cargar_combo();
            ViewBag.IdTareaPadre = model.IdTareaPadre= IdTarea;
            model.TareaConcurrente = false;
            model.IdUsuarioSolicitante = SessionTareas.IdUsuario;
            model.IdUsuarioAsignado = null;
            if (model == null)
                return RedirectToAction("Asignar_subtareas");
            return View(model);
        }
        [HttpPost]
        public ActionResult Nuevo(Tarea_Info model)
        {
            string mensaje = "";
            model.FechaEntrega = model.FechaEntrega;
            model.IdUsuarioModifica = SessionTareas.IdUsuario.ToString();
            if (model.ObsevacionModificacion == null | model.ObsevacionModificacion == "")
            {
                ViewBag.mensaje = "Ingrese una observación";
                cargar_combo();
                return View(model);
            }

            model.list_adjuntos = TareaArchivoAdjunto_Info_lis.get_list(model.IdTransaccionSession);

            mensaje = Validaciones(model);
            if (mensaje != "")
            {
                cargar_combo();
                ViewBag.mensaje = mensaje;
                return View(model);
            }
            model.IdUsuario = SessionTareas.IdUsuario.ToString();
            model.EstadoActual = 1;
            if (!bus_tarea.guardarDB(model))
            {
                cargar_combo();
                return View(model);
            }
            return RedirectToAction("Index");
        }

        #region cargar combo
        public void cargar_combo()
        {
            try
            {


                var list_usuarios = bus_usuario.get_lis(false);
                ViewBag.list_usuarios = list_usuarios;

                var list_estado = bus_estado.get_lis(1);
                ViewBag.list_estado = list_estado;

                var list_prioridad = bus_estado.get_lis(2);
                ViewBag.list_prioridad = list_prioridad;


                var list_tarea = bus_tarea.get_lis_cargar_combo();
                ViewBag.list_tarea = list_tarea; 
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void cargar_combo_detalle()
        {
            try
            {

                var list_usuarios = bus_usuario.get_lis(false);
                ViewBag.list_usuarios = list_usuarios;

                var list_estado_detalle = bus_estado.get_lis(3);
                ViewBag.list_estado_detalle = list_estado_detalle;



            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        private string Validaciones(Tarea_Info info)
        {
            try
            {
                string mensaje = "";
              

               
                
                return mensaje;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}