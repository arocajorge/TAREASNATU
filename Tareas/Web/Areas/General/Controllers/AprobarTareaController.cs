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
    public class AprobarTareaController : Controller
    {
        #region Variables
        Tarea_Bus bus_tarea = new Tarea_Bus();
        Grupo_Bus bus_grupo = new Grupo_Bus();
        Usuario_Bus bus_usuario = new Usuario_Bus();
        Estado_Bus bus_estado = new Estado_Bus();
        TareaArchivoAdjunto_Bus bus_adjunto = new TareaArchivoAdjunto_Bus();

        #endregion

        public ActionResult Nuevo(int IdTarea = 0)
        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionTareas.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionTareas.IdTransaccionSession = (Convert.ToDecimal(SessionTareas.IdTransaccionSession) + 1).ToString();
            SessionTareas.IdTransaccionSessionActual = SessionTareas.IdTransaccionSession;
            #endregion

            Tarea_Info model = bus_tarea.get_info(IdTarea);
            if (model == null)
            {
                model = new Tarea_Info();
                return View(model);
            }
            model.AprobadoEncargado = true;
            model.IdTransaccionSession = Convert.ToDecimal(SessionTareas.IdTransaccionSessionActual);
            model.list_adjuntos = bus_adjunto.get_lis(IdTarea);
            TareaArchivoAdjunto_Info_lis.set_list(model.list_adjuntos, model.IdTransaccionSession);
            cargar_combo();
            ViewBag.IdTareaPadre = model.IdTareaPadre;

            if (model == null)
                return RedirectToAction("Buzon_entrada");
            return View(model);
        }
        [HttpPost]
        public ActionResult Nuevo(Tarea_Info model)
        {

            if (model != null)
            {
                model.Controller = cl_enumeradores.eController.Tarea;
                model.Accion = cl_enumeradores.eAcciones.Consultar;
                model.IdUsuario = SessionTareas.IdUsuario;
                model.list_adjuntos = TareaArchivoAdjunto_Info_lis.get_list(model.IdTransaccionSession);
                model.FechaEntrega = model.FechaEntrega;

            }

            if ( !bus_tarea.Aprobar(model))
            {
                cargar_combo();
                return View(model);
            }
            else
            {
                return RedirectToAction("Por_aprobar", "MisTareas");
            }
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

                var list_grupo = bus_grupo.get_lis(true);
                ViewBag.list_grupo = list_grupo;

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
               
               
                if (info.TareaConcurrente)
                {
                    if (info.DiasIntervaloProximaTarea == null | info.DiasIntervaloProximaTarea == 0)
                        mensaje = "Los dias de intervalo es obligatorio";
                    if (info.FechaFinConcurrencia == null)
                        mensaje = "La fecha de expiracion es obligatoria";
                    else
                        if (Convert.ToDateTime(info.FechaFinConcurrencia).Year == 1)
                        mensaje = "La fecha de expiracion no es valida";

                }
                return mensaje;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}