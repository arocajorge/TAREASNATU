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
    
    public class TareaController : Controller
    {
        #region Variables
        Tarea_det_Bus bus_tarea_det = new Tarea_det_Bus();
        Tarea_det_Info_lis Lis_Tarea_det_Info_lis = new Tarea_det_Info_lis();
        Tarea_Bus bus_tarea = new Tarea_Bus();
        Grupo_Bus bus_grupo = new Grupo_Bus();
        Usuario_Bus bus_usuario = new Usuario_Bus();
        Estado_Bus bus_estado = new Estado_Bus();
        TareaArchivoAdjunto_Bus bus_adjunto = new TareaArchivoAdjunto_Bus();
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
        public ActionResult GridViewPartial_Tarea(DateTime? fecha_ini, DateTime? fecha_fin)
        {
            List<Tarea_Info> model = new List<Tarea_Info>();
            ViewBag.fecha_ini = fecha_ini == null ? DateTime.Now.Date.AddMonths(-1) : fecha_ini;
            ViewBag.fecha_fin = fecha_fin == null ? DateTime.Now.Date : fecha_fin;
            model = bus_tarea.get_lis(ViewBag.fecha_ini, ViewBag.fecha_fin);
            return PartialView("_GridViewPartial_tarea", model);
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartial_Tarea_det()
        {
            cargar_combo_detalle();
            Tarea_Info model = new Tarea_Info();
            model.list_detalle = Lis_Tarea_det_Info_lis.get_list(Convert.ToDecimal(SessionTareas.IdTransaccionSessionActual));
            return PartialView("_GridViewPartial_Tarea_det", model);
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
            #region Validar Session
            if (string.IsNullOrEmpty(SessionTareas.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionTareas.IdTransaccionSession = (Convert.ToDecimal(SessionTareas.IdTransaccionSession) + 1).ToString();
            SessionTareas.IdTransaccionSessionActual = SessionTareas.IdTransaccionSession;
            #endregion

            Tarea_Info model = new Tarea_Info()
            {
                FechaInicio = DateTime.Now,
                FechaCulmina = DateTime.Now,
                IdUsuarioSolicitante = SessionTareas.IdUsuario.ToString(),
                IdEstadoPrioridad=2,
                EstadoActual=1,
                AprobadoSolicitado=true,
                IdTransaccionSession = Convert.ToDecimal(SessionTareas.IdTransaccionSessionActual),

            };
            Lis_Tarea_det_Info_lis.set_list(new List<Tarea_det_Info>(),model.IdTransaccionSession);
            cargar_combo();
            return View(model);
        }

        [HttpPost]
        public ActionResult Nuevo(Tarea_Info model)
        {
            var grupo = bus_grupo.get_info(model.IdGrupo);
            model.IdUsuarioAsignado = grupo.IdUsuario;


            string mensaje = "";
            model.list_detalle = Lis_Tarea_det_Info_lis.get_list(model.IdTransaccionSession);
            model.list_adjuntos = TareaArchivoAdjunto_Info_lis.get_list(model.IdTransaccionSession);
            model.IdUsuario = SessionTareas.IdUsuario.ToString();
            if (model.list_detalle == null &&(model.IdUsuarioSolicitante==model.IdUsuarioAsignado))
            {
                cargar_combo();
                ViewBag.mensaje = "La tarea debe tener un detalle";
                return View(model);
            }
            else
            {
                if (model.list_detalle.Count() == 0)
                {
                    cargar_combo();
                    ViewBag.mensaje = "La tarea debe tener un detalle";
                    return View(model);
                }
            }
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
            return RedirectToAction("Index");
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
            model.list_detalle = bus_tarea_det.get_lis(IdTarea);
            Lis_Tarea_det_Info_lis.set_list(model.list_detalle, model.IdTransaccionSession);
            model.list_adjuntos = bus_adjunto.get_lis(IdTarea);
            TareaArchivoAdjunto_Info_lis.set_list(model.list_adjuntos, model.IdTransaccionSession);
            cargar_combo();
            if (model == null)
                return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost]
        public ActionResult Modificar(Tarea_Info model)
        {
            var grupo = bus_grupo.get_info(model.IdGrupo);
            model.IdUsuarioAsignado = grupo.IdUsuario;
            string mensaje = "";
            model.list_detalle = Lis_Tarea_det_Info_lis.get_list(model.IdTransaccionSession);
            model.list_adjuntos = TareaArchivoAdjunto_Info_lis.get_list(model.IdTransaccionSession);
            model.IdUsuarioModifica = SessionTareas.IdUsuario.ToString();
            if (model.list_detalle == null)
            {
                cargar_combo();
                ViewBag.mensaje = "El Tarea debe tener almenos un usuario miembro del Tarea";
                return View(model);
            }
            else
            {
                if (model.list_detalle.Count() == 0)
                {
                    cargar_combo();
                    ViewBag.mensaje = "El Tarea debe tener almenos un usuario miembro del Tarea";
                    return View(model);
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
            return RedirectToAction("Index");
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
            model.list_detalle = bus_tarea_det.get_lis(IdTarea);
            Lis_Tarea_det_Info_lis.set_list(model.list_detalle, model.IdTransaccionSession);
            model.list_adjuntos = bus_adjunto.get_lis(IdTarea);
            TareaArchivoAdjunto_Info_lis.set_list(model.list_adjuntos, model.IdTransaccionSession);
            cargar_combo();
            if (model == null)
                return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost]
        public ActionResult Anular(Tarea_Info model)
        {
            if (!bus_tarea.anularDB(model))
            {
                cargar_combo();

                return View(model);
            }
            return RedirectToAction("Index");
        }

        public FileResult DolowarFille(decimal IdTarea, int Secuencial)
        {
           var info= bus_adjunto.get_info(IdTarea, Secuencial);
            return File(info.Archivo, "application/pdf", info.NombreArchivo);
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

                var list_grupo = bus_grupo.get_lis();
                ViewBag.list_grupo = list_grupo;

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

        #region funciones del detalle
        [HttpPost, ValidateInput(false)]
        public ActionResult EditingAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Tarea_det_Info info_det)
        {
            if (ModelState.IsValid)
                Lis_Tarea_det_Info_lis.AddRow(info_det, Convert.ToDecimal(SessionTareas.IdTransaccionSessionActual));
            Tarea_Info model = new Tarea_Info();
            model.list_detalle = Lis_Tarea_det_Info_lis.get_list(Convert.ToDecimal(SessionTareas.IdTransaccionSessionActual));
            cargar_combo_detalle();
            return PartialView("_GridViewPartial_tarea_det", model);
        }

        public ActionResult EditingUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Tarea_det_Info info_det)
        {
            if (ModelState.IsValid)
                Lis_Tarea_det_Info_lis.UpdateRow(info_det, Convert.ToDecimal(SessionTareas.IdTransaccionSessionActual));
            Tarea_Info model = new Tarea_Info();
            model.list_detalle = Lis_Tarea_det_Info_lis.get_list(Convert.ToDecimal(SessionTareas.IdTransaccionSessionActual));
            cargar_combo_detalle();
            return PartialView("_GridViewPartial_tarea_det", model);
        }

        public ActionResult EditingDelete([ModelBinder(typeof(DevExpressEditorsBinder))] Tarea_det_Info info_det)
        {
            Lis_Tarea_det_Info_lis.DeleteRow(info_det.Secuancial, Convert.ToDecimal(SessionTareas.IdTransaccionSessionActual));
            Tarea_Info model = new Tarea_Info();
            model.list_detalle = Lis_Tarea_det_Info_lis.get_list(Convert.ToDecimal(SessionTareas.IdTransaccionSessionActual));
            cargar_combo_detalle();
            return PartialView("_GridViewPartial_tarea_det", model);
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
                if(info.FechaCulmina.Date<info.FechaInicio.Date)
                {
                    mensaje = "Fecha inicio no puede ser mayor que fecha fin";
                }

                foreach (var item in info.list_detalle)
                {
                    if (item.FechaFin.Date < item.FechaInicio.Date)
                    {
                        mensaje = "Las fecha de: "+item.Descripcion+", no son correctas";
                    }
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
            return PartialView("_GridViewPartial_tarea_det_adjunto", TareaArchivoAdjunto_Info_lis.get_list(Convert.ToDecimal(SessionTareas.IdTransaccionSessionActual)));

        }
    }
    public class TareaControllerUploadControl_adjuntoSettings
    {
        public static DevExpress.Web.UploadControlValidationSettings UploadValidationSettings = new DevExpress.Web.UploadControlValidationSettings()
        {
            AllowedFileExtensions = new string[] { ".xlsx", ".xls", ".doc",  ".pdf", ".docx" },
            MaxFileSize = 400000000
        };
        public static void FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            if (e.UploadedFile.IsValid)
            {
                TareaArchivoAdjunto_Info info_documento = new TareaArchivoAdjunto_Info();
                info_documento.Archivo = e.UploadedFile.FileBytes;
                info_documento.NombreArchivo = e.UploadedFile.FileName;
                TareaArchivoAdjunto_Info_lis.AddRow(info_documento);
            }
        }
    }


    #region Tarea detalle

    public class Tarea_det_Info_lis
    {
        string variable = "";
        public List<Tarea_det_Info> get_list(decimal IdTransaccionSessionActual)
        {
            if (HttpContext.Current.Session[variable + IdTransaccionSessionActual.ToString()] == null)
            {
                List<Tarea_det_Info> list = new List<Tarea_det_Info>();

                HttpContext.Current.Session[variable + IdTransaccionSessionActual.ToString()] = list;
            }
            return (List<Tarea_det_Info>)HttpContext.Current.Session[variable + IdTransaccionSessionActual.ToString()];
        }

        public void set_list(List<Tarea_det_Info> list, decimal IdTransaccionSessionActual)
        {
            HttpContext.Current.Session[variable + IdTransaccionSessionActual.ToString()] = list;
        }

        public void AddRow(Tarea_det_Info info_det, decimal IdTransaccionSessionActual)
        {
            List<Tarea_det_Info> list = get_list(IdTransaccionSessionActual);
            info_det.Secuancial = list.Count() + 1;
            list.Add(info_det);
        }
        public void DeleteRow(int Secuancial, decimal IdTransaccionSessionActual)
        {
            List<Tarea_det_Info> list = get_list(IdTransaccionSessionActual);
            list.Remove(list.Where(m => m.Secuancial == Secuancial).First());
        }
        public void UpdateRow(Tarea_det_Info info_det, decimal IdTransaccionSessionActual)
        {
            Tarea_det_Info edited_info = get_list(IdTransaccionSessionActual).Where(m => m.Secuancial == info_det.Secuancial).First();
            edited_info.FechaFin = info_det.FechaFin;
            edited_info.FechaInicio = info_det.FechaInicio;
            edited_info.Descripcion = info_det.Descripcion;
            edited_info.NumHoras = info_det.NumHoras;
            
        }
    }

    #endregion

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