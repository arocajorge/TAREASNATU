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
    public class TareaController : Controller
    {
        #region Variables
        Tarea_Bus bus_tarea = new Tarea_Bus();
        Grupo_Bus bus_grupo = new Grupo_Bus();
        Usuario_Bus bus_usuario = new Usuario_Bus();
        Estado_Bus bus_estado = new Estado_Bus();
        TareaArchivoAdjunto_Bus bus_adjunto = new TareaArchivoAdjunto_Bus();
        Parametro_Bus bus_parametro = new Parametro_Bus();
        #endregion

        #region Vistas tareas
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
        public ActionResult GridViewPartial_Tarea(DateTime? fecha_ini)
        {
            List<Tarea_Info> model = new List<Tarea_Info>();
            ViewBag.fecha_ini = fecha_ini == null ? DateTime.Now.Date : fecha_ini;
            model = bus_tarea.get_lis(ViewBag.fecha_ini);
            return PartialView("_GridViewPartial_tarea", model);
        }
      
        public ActionResult GridViewPartial_tarea_det_adjunto()
        {
            cargar_combo();
            Tarea_Info model = new Tarea_Info();
            model.list_adjuntos = TareaArchivoAdjunto_Info_lis.get_list(Convert.ToDecimal(SessionTareas.IdTransaccionSessionActual));
            return PartialView("_GridViewPartial_tarea_det_adjunto", model);
        }


     
        #endregion

        #region Acciones

        public ActionResult Nuevo()
        {
            bus_grupo = new Grupo_Bus();
            #region Validar Session
            if (string.IsNullOrEmpty(SessionTareas.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionTareas.IdTransaccionSession = (Convert.ToDecimal(SessionTareas.IdTransaccionSession) + 1).ToString();
            SessionTareas.IdTransaccionSessionActual = SessionTareas.IdTransaccionSession;
            #endregion
            var grupo = bus_grupo.get_info_grup_usuario(SessionTareas.IdUsuario.ToString());
            if (grupo == null)
                grupo = new Grupo_Info();
            Tarea_Info model = new Tarea_Info()
            {
                FechaEntrega = DateTime.Now,
                IdUsuarioSolicitante = SessionTareas.IdUsuario.ToString(),
                IdEstadoPrioridad = 2,
                EstadoActual = 1,
                AprobadoSolicitado = true,
                IdTransaccionSession = Convert.ToDecimal(SessionTareas.IdTransaccionSessionActual),
                IdGrupo = grupo.IdGrupo,
                nomb_jef_grupo = grupo.nomb_jef_grupo,

            };
            TareaArchivoAdjunto_Info_lis.set_list(new List<TareaArchivoAdjunto_Info>(), Convert.ToDecimal(model.IdTransaccionSession));
            cargar_combo();
            return View(model);
        }
        [HttpPost]
        public ActionResult Nuevo(Tarea_Info model)
        {
            string mensaje = "";
            model.Controller = cl_enumeradores.eController.AprobarTarea;
            model.Accion = cl_enumeradores.eAcciones.Nuevo;
            if(model.FechaEntrega.Date < DateTime.Now.AddDays(1).Date)
            {
                cargar_combo();
                ViewBag.mensaje = "La fecha de entrega no puede ser hoy, seleccione una fecha de entrega superior";
                return View(model);
            }
            var param = bus_parametro.get_info();
            if(param==null)
                param = new Parametro_Info();
            if (param != null)
            {
                if (model.IdUsuarioAsignado == SessionTareas.IdUsuario)
                {
                    model.EstadoActual = param.IdEstadoAprobarTarea;
                    model.AprobadoEncargado = true;
                    model.AprobadoSolicitado = true;
                    model.FechaAprobacion = DateTime.Now;
                }
                else
                {
                    model.EstadoActual = 1;
                    model.AprobadoSolicitado = true;

                }
            }
            bus_grupo = new Grupo_Bus();
            var grupo = bus_grupo.get_info_grup_usuario(model.IdUsuarioAsignado);
            if (grupo != null)
            {
                model.IdGrupo = grupo.IdGrupo;
            }

            model.list_adjuntos = TareaArchivoAdjunto_Info_lis.get_list(model.IdTransaccionSession);
            model.IdUsuario = SessionTareas.IdUsuario.ToString();
            model.FechaEntrega = model.FechaEntrega;            
            mensaje = Validaciones(model);
            if(mensaje!="")
            {
                cargar_combo();
                ViewBag.mensaje =mensaje;
                return View(model);
            }
            if (!bus_tarea.guardarDB(model))
            {
                cargar_combo();
                return View(model);
            }
            return RedirectToAction("Buzon_salida", "Buzon");
        }


        public ActionResult Modificar(int IdTarea = 0)
        
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
            if (model == null)
                return RedirectToAction("Index");
            model.AprobadoSolicitado = true;
            
            return View(model);
        }
        [HttpPost]
        public ActionResult Modificar(Tarea_Info model)
        {
            model.Controller = cl_enumeradores.eController.AprobarTarea;
            model.Accion = cl_enumeradores.eAcciones.Nuevo;
            var param = bus_parametro.get_info();
            string mensaje = "";
            if (model.FechaEntrega.Date < DateTime.Now.Date)
            {
                cargar_combo();
                ViewBag.mensaje = "La fecha de entrega no puede ser menor a la fecha actual";
                return View(model);
            }
            var grupo = bus_grupo.get_info_grup_usuario(model.IdUsuarioAsignado);
            if (grupo != null)
            {
                model.IdGrupo = grupo.IdGrupo;
            }
            if (model.ObsevacionModificacion == null | model.ObsevacionModificacion == "")
            {
                mensaje = "Ingrese una observación";
                ViewBag.mensaje = mensaje;
                cargar_combo();
                return View(model);
            }

            model.list_adjuntos = TareaArchivoAdjunto_Info_lis.get_list(model.IdTransaccionSession);
            model.IdUsuarioModifica = SessionTareas.IdUsuario;
            if (param == null)
            {
                param = new Parametro_Info();
                if (model.IdUsuarioAsignado == SessionTareas.IdUsuario)
                {
                    model.EstadoActual = param.IdEstadoAprobarTarea;
                    model.AprobadoEncargado = true;
                    model.AprobadoSolicitado = true;
                    model.FechaAprobacion = DateTime.Now;
                    model.IdEstadoPrioridad = param.IdEstadoAprobarTarea;

                }
                else
                {
                    model.EstadoActual = 1;
                }
            }
            mensaje = Validaciones(model);
            if (mensaje != "")
            {
                cargar_combo();
                ViewBag.mensaje = mensaje;
                return View(model);
            }
            if (!bus_tarea.modificarDB(model))
            {
                cargar_combo();
                return View(model);
            }
            return RedirectToAction("Buzon_salida","Buzon");
        }


        public ActionResult Anular(decimal IdTarea = 0)
        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionTareas.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionTareas.IdTransaccionSession = (Convert.ToDecimal(SessionTareas.IdTransaccionSession) + 1).ToString();
            SessionTareas.IdTransaccionSessionActual = SessionTareas.IdTransaccionSession;
            #endregion

            Tarea_Info model = bus_tarea.get_info(IdTarea);
            if (model == null)
                model = new Tarea_Info();
            model.IdTransaccionSession = Convert.ToDecimal(SessionTareas.IdTransaccionSessionActual);
            model.list_adjuntos = bus_adjunto.get_lis(IdTarea);
            TareaArchivoAdjunto_Info_lis.set_list(model.list_adjuntos, model.IdTransaccionSession);
            cargar_combo();
            ViewBag.IdTareaPadre = model.IdTareaPadre;
            if (model == null)
                return RedirectToAction("Index");
            return View(model);
        }
        [HttpPost]
        public ActionResult Anular(Tarea_Info model)
        {
            string mensaje = "";
            model.FechaEntrega = model.FechaEntrega;
            if (model.ObsevacionModificacion == null | model.ObsevacionModificacion == "")
            {
                mensaje = "Ingrese una observación";
                ViewBag.mensaje = mensaje;
                cargar_combo();
                return View(model);
            }

            if (!bus_tarea.anularDB(model))
            {
                cargar_combo();

                return View(model);
            }
            return RedirectToAction("Buzon_salida", "Buzon");
        }


        public ActionResult Consultar(decimal IdTarea = 0)
        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionTareas.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionTareas.IdTransaccionSession = (Convert.ToDecimal(SessionTareas.IdTransaccionSession) + 1).ToString();
            SessionTareas.IdTransaccionSessionActual = SessionTareas.IdTransaccionSession;
            #endregion

            Tarea_Info model = bus_tarea.get_info(IdTarea);
            if (model == null)
                model = new Tarea_Info();
            model.IdTransaccionSession = Convert.ToDecimal(SessionTareas.IdTransaccionSessionActual);
            model.list_adjuntos = bus_adjunto.get_lis(IdTarea);
            TareaArchivoAdjunto_Info_lis.set_list(model.list_adjuntos, model.IdTransaccionSession);
            cargar_combo();
            ViewBag.IdTareaPadre = model.IdTareaPadre;
            if (model == null)
                return RedirectToAction("Index");
            return View(model);
        }
       

        public ActionResult Cerrar(int IdTarea = 0)

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
            if (model == null)
                return RedirectToAction("Buzon_entrada");
            ViewBag.IdTareaPadre = model.IdTareaPadre;
            return View(model);
        }
        [HttpPost]
        public ActionResult Cerrar(Tarea_Info model)
        {
            model.Controller = cl_enumeradores.eController.Tarea;
            model.Accion = cl_enumeradores.eAcciones.Consultar;
            bus_tarea = new Tarea_Bus();
            string mensaje = "";
            model.list_adjuntos = TareaArchivoAdjunto_Info_lis.get_list(model.IdTransaccionSession);
            model.IdUsuarioModifica = SessionTareas.IdUsuario.ToString();
            model.FechaEntrega = model.FechaEntrega;

           
           
            mensaje = Validaciones(model);
            if (mensaje != "")
            {
                cargar_combo();
                ViewBag.mensaje = mensaje;
                return View(model);
            }
            model.IdUsuario = SessionTareas.IdUsuario.ToString();
            if (!bus_tarea.Cerrar(model))
            {
                cargar_combo();
                return View(model);
            }
            return RedirectToAction("Buzon_entrada","Buzon");
        }

        public ActionResult CerrarPorSolicitante(int IdTarea = 0)

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
            ViewBag.IdTareaPadre = model.IdTareaPadre;

            if (model == null)
                return RedirectToAction("Buzon_salida");
          
            return View(model);
        }
        [HttpPost]
        public ActionResult CerrarPorSolicitante(Tarea_Info model)
        {
            model.Controller = cl_enumeradores.eController.Tarea;
            model.Accion = cl_enumeradores.eAcciones.Consultar;
           

            model.list_adjuntos = TareaArchivoAdjunto_Info_lis.get_list(model.IdTransaccionSession);
            model.IdUsuarioModifica = SessionTareas.IdUsuario.ToString();
            model.FechaEntrega = model.FechaEntrega;

            

            model.IdUsuario = SessionTareas.IdUsuario.ToString();
            if (!bus_tarea.CerrarPorSolicitante(model))
            {
                cargar_combo();
                return View(model);
            }
            return RedirectToAction("Buzon_salida", "Buzon");
        }


        public FileResult DolowarFille(decimal IdTarea, int Secuencial)
        {
            var info= bus_adjunto.get_info(IdTarea, Secuencial);
            if (info == null)
            {
               var archivo= TareaArchivoAdjunto_Info_lis.get_list(Convert.ToDecimal( SessionTareas.IdTransaccionSession)).Where(m => m.Secuencial == Secuencial).FirstOrDefault();
                return File(archivo.Archivo, archivo.TipoArchivo, archivo.NombreArchivo);
            }
            else
                return File(info.Archivo, info.TipoArchivo, info.NombreArchivo);

        }

        #endregion

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

     
        #region funciones de los adjuntos
        public ActionResult EditingDelete_adjunto([ModelBinder(typeof(DevExpressEditorsBinder))] TareaArchivoAdjunto_Info info_det)
        {
            TareaArchivoAdjunto_Info_lis.DeleteRow(info_det.Secuencial, Convert.ToDecimal(SessionTareas.IdTransaccionSessionActual));
            Tarea_Info model = new Tarea_Info();
            model.list_adjuntos = TareaArchivoAdjunto_Info_lis.get_list(Convert.ToDecimal(SessionTareas.IdTransaccionSessionActual));
            return PartialView("_GridViewPartial_tarea_det_adjunto", model);
        }
        #endregion

       
        private string Validaciones(Tarea_Info info)
        {
            try
            {
                string mensaje = "";
               
                if (info.IdGrupo ==0)
                {
                    mensaje = "El usuario asignado no pertenece a un grupo";
                }
                 if(info.TareaConcurrente)
                {
                    if(info.DiasIntervaloProximaTarea==null)
                        mensaje = "Los dias de intervalo es obligatorio";
                    if (info.FechaFinConcurrencia == null)
                    {
                        info.FechaFinConcurrencia = DateTime.Now.AddYears(1000);
                    }
                    else
                        if (Convert.ToDateTime(info.FechaFinConcurrencia)<info.FechaEntrega.Date)
                        mensaje = "La fecha de expiración de concurrencia debe ser mayor a la fehca de inicio de la tarea";

                }
                return mensaje;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult UploadControl_adjuntoUpload()
        {
            UploadControlExtension.GetUploadedFiles("UploadControl_adjunto", TareaControllerUploadControl_adjuntoSettings.UploadValidationSettings, TareaControllerUploadControl_adjuntoSettings.FileUploadComplete);
            // return PartialView("_GridViewPartial_tarea_det_adjunto", TareaArchivoAdjunto_Info_lis.get_list(Convert.ToDecimal(SessionTareas.IdTransaccionSessionActual)));
            return null;
        }


        public JsonResult Aprobar(int IdTarea= 0, string ObsevacionModificacion="")
        {
            try
            {
                var model = bus_tarea.get_info(IdTarea);
                model.Controller = cl_enumeradores.eController.Tarea;
                model.Accion = cl_enumeradores.eAcciones.Consultar;

                model.ObsevacionModificacion = ObsevacionModificacion;
                model.list_adjuntos = TareaArchivoAdjunto_Info_lis.get_list(Convert.ToDecimal(SessionTareas.IdTransaccionSessionActual));
                model.IdUsuarioModifica = SessionTareas.IdUsuario.ToString();
                model.IdUsuario = SessionTareas.IdUsuario.ToString();

                bus_tarea.CerrarPorSolicitante(model);
                return Json("", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult Rechazar(int IdTarea = 0, string ObsevacionModificacion="")
        {
            try
            {
                var model = bus_tarea.get_info(IdTarea);
                model.Controller = cl_enumeradores.eController.Tarea;
                model.Accion = cl_enumeradores.eAcciones.Consultar;

                model.ObsevacionModificacion = ObsevacionModificacion;
                model.list_adjuntos = TareaArchivoAdjunto_Info_lis.get_list(Convert.ToDecimal(SessionTareas.IdTransaccionSessionActual));
                model.IdUsuarioModifica = SessionTareas.IdUsuario.ToString();
                model.FechaEntrega = model.FechaEntrega;
                model.IdUsuario = SessionTareas.IdUsuario.ToString();

                bus_tarea.RechazarTarea(model);
                return Json("", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }

    public class TareaControllerUploadControl_adjuntoSettings
    {
        public static DevExpress.Web.UploadControlValidationSettings UploadValidationSettings = new DevExpress.Web.UploadControlValidationSettings()
        {
           // AllowedFileExtensions = new string[] { ".xlsx", ".xls", ".doc",  ".pdf", ".docx",".jpg",".png" },
            MaxFileSize = 9000000000
        };
        public static void FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            if (e.UploadedFile.IsValid)
            {
                TareaArchivoAdjunto_Info info_documento = new TareaArchivoAdjunto_Info();
                info_documento.Archivo = e.UploadedFile.FileBytes;
                info_documento.NombreArchivo = e.UploadedFile.FileName;
                info_documento.TipoArchivo = e.UploadedFile.ContentType;
                TareaArchivoAdjunto_Info_lis.AddRow(info_documento);
            }
        }
    }



    #region Tarea Adjunto

    public static class TareaArchivoAdjunto_Info_lis
    {
        static string variable = "TareaArchivoAdjunto_Info";
        public static List<TareaArchivoAdjunto_Info> get_list(decimal IdTransaccionSessionActual)
        {
            if (HttpContext.Current.Session[variable + IdTransaccionSessionActual.ToString()] == null)
            {
                List<TareaArchivoAdjunto_Info> list = new List<TareaArchivoAdjunto_Info>();

                HttpContext.Current.Session[variable + IdTransaccionSessionActual.ToString()] = list;
            }
            var lis = (List<TareaArchivoAdjunto_Info>)HttpContext.Current.Session[variable + IdTransaccionSessionActual.ToString()];
            return (List<TareaArchivoAdjunto_Info>)HttpContext.Current.Session[variable + IdTransaccionSessionActual.ToString()];
        }

        public static void set_list(List<TareaArchivoAdjunto_Info> list, decimal IdTransaccionSessionActual)
        {
            HttpContext.Current.Session[variable + IdTransaccionSessionActual.ToString()] = list;
        }

        public static void AddRow(TareaArchivoAdjunto_Info info_det)
        {
            List<TareaArchivoAdjunto_Info> list = get_list(Convert.ToDecimal(SessionTareas.IdTransaccionSessionActual));
            info_det.Secuencial = list.Count() + 1;
            list.Add(info_det);
        }
        public static void DeleteRow(int Secuancial, decimal IdTransaccionSessionActual)
        {
            List<TareaArchivoAdjunto_Info> list = get_list(IdTransaccionSessionActual);
            list.Remove(list.Where(m => m.Secuencial == Secuancial).First());
        }
        public static void UpdateRow(TareaArchivoAdjunto_Info info_det)
        {
            TareaArchivoAdjunto_Info edited_info = get_list(Convert.ToDecimal(SessionTareas.IdTransaccionSessionActual)).Where(m => m.Secuencial == info_det.Secuencial).First();
            edited_info.NombreArchivo = info_det.NombreArchivo;
            edited_info.Archivo = info_det.Archivo;
        }
    }
    #endregion


}