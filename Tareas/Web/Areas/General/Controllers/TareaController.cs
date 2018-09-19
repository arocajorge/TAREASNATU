using Bus;
using DevExpress.Web.Mvc;
using Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Helps;
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
        #endregion

        #region Index
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_Tarea()
        {
            List<Tarea_Info> model = new List<Tarea_Info>();
            model = bus_tarea.get_lis();
            return PartialView("_GridViewPartial_tarea", model);
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartial_Tarea_det()
        {
            cargar_combo();
            Tarea_Info model = new Tarea_Info();
            model.list_detalle = Lis_Tarea_det_Info_lis.get_list();
            return PartialView("_GridViewPartial_Tarea_det", model);
        }
        public ActionResult GridViewPartial_tarea_det_adjunto()
        {
            cargar_combo();
            Tarea_Info model = new Tarea_Info();
            model.list_adjuntos = TareaArchivoAdjunto_Info_lis.get_list();
            return PartialView("_GridViewPartial_tarea_det_adjunto", model);
        }

        
        #endregion

        #region Acciones

        public ActionResult Nuevo()
        {
            Tarea_Info model = new Tarea_Info()
            {
                FechaInicio = DateTime.Now,
                FechaCulmina = DateTime.Now.AddDays(7),
                IdUsuarioSolicitante = SessionTareas.IdUsuario.ToString()

            };
            Lis_Tarea_det_Info_lis.set_list(new List<Tarea_det_Info>());
            cargar_combo();
            return View(model);
        }

        [HttpPost]
        public ActionResult Nuevo(Tarea_Info model)
        {
            model.list_detalle = Lis_Tarea_det_Info_lis.get_list();
            model.IdUsuario = SessionTareas.IdUsuario.ToString();
            if (model.list_detalle == null)
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
            if (!bus_tarea.guardarDB(model))
            {
                cargar_combo();
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Modificar(int IdTarea = 0)
        {
            Tarea_Info model = bus_tarea.get_info(IdTarea);
            model.list_detalle = bus_tarea_det.get_lis(IdTarea);
            Lis_Tarea_det_Info_lis.set_list(model.list_detalle);
            cargar_combo();
            if (model == null)
                return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost]
        public ActionResult Modificar(Tarea_Info model)
        {
            model.list_detalle = Lis_Tarea_det_Info_lis.get_list();
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
            if (!bus_tarea.modificarDB(model))
            {
                cargar_combo();
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Anular(decimal IdTarea = 0)
        {
            Tarea_Info model = bus_tarea.get_info(IdTarea);
            model.list_detalle = bus_tarea_det.get_lis(IdTarea);
            Lis_Tarea_det_Info_lis.set_list(model.list_detalle);
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
        #endregion

        #region cargar combo
        public void cargar_combo()
        {
            try
            {
                var list_tarea = bus_tarea.get_lis();
                ViewBag.list_tarea = list_tarea;

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
        #endregion

        #region funciones del detalle
        [HttpPost, ValidateInput(false)]
        public ActionResult EditingAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Tarea_det_Info info_det)
        {
            if (ModelState.IsValid)
                Lis_Tarea_det_Info_lis.AddRow(info_det);
            Tarea_Info model = new Tarea_Info();
            model.list_detalle = Lis_Tarea_det_Info_lis.get_list();
            cargar_combo();
            return PartialView("_GridViewPartial_tarea_det", model);
        }

        public ActionResult EditingUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Tarea_det_Info info_det)
        {
            if (ModelState.IsValid)
                Lis_Tarea_det_Info_lis.AddRow(info_det);
            Tarea_Info model = new Tarea_Info();
            model.list_detalle = Lis_Tarea_det_Info_lis.get_list();
            cargar_combo();
            return PartialView("_GridViewPartial_tarea_det", model);
        }

        public ActionResult EditingDelete([ModelBinder(typeof(DevExpressEditorsBinder))] Tarea_det_Info info_det)
        {
            Lis_Tarea_det_Info_lis.DeleteRow(info_det.Secuancial);
            Tarea_Info model = new Tarea_Info();
            model.list_detalle = Lis_Tarea_det_Info_lis.get_list();
            cargar_combo();
            return PartialView("_GridViewPartial_tarea_det", model);
        }

        #endregion

        #region funciones de los adjuntos
        public ActionResult EditingDelete_adjunto([ModelBinder(typeof(DevExpressEditorsBinder))] TareaArchivoAdjunto_Info info_det)
        {
            TareaArchivoAdjunto_Info_lis.DeleteRow(info_det.Secuencial);
            Tarea_Info model = new Tarea_Info();
            model.list_adjuntos = TareaArchivoAdjunto_Info_lis.get_list();
            return PartialView("_GridViewPartial_tarea_det_adjunto", model);
        }
        #endregion
        public ActionResult UploadControl_adjuntoUpload()
        {
            UploadControlExtension.GetUploadedFiles("UploadControl_adjunto", TareaControllerUploadControl_adjuntoSettings.UploadValidationSettings, TareaControllerUploadControl_adjuntoSettings.FileUploadComplete);
            return PartialView("_GridViewPartial_tarea_det_adjunto", TareaArchivoAdjunto_Info_lis.get_list());

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
                info_documento.tamanio_file = e.UploadedFile.FileBytes;
                info_documento.NombreArchivo = e.UploadedFile.FileName;
                TareaArchivoAdjunto_Info_lis.AddRow(info_documento);
            }
        }
    }



    public class Tarea_det_Info_lis
    {
        public List<Tarea_det_Info> get_list()
        {
            if (HttpContext.Current.Session["Tarea_det_Info"] == null)
            {
                List<Tarea_det_Info> list = new List<Tarea_det_Info>();

                HttpContext.Current.Session["Tarea_det_Info"] = list;
            }
            return (List<Tarea_det_Info>)HttpContext.Current.Session["Tarea_det_Info"];
        }

        public void set_list(List<Tarea_det_Info> list)
        {
            HttpContext.Current.Session["Tarea_det_Info"] = list;
        }

        public void AddRow(Tarea_det_Info info_det)
        {
            List<Tarea_det_Info> list = get_list();
            info_det.Secuancial = list.Count() + 1;
            list.Add(info_det);
        }
        public void DeleteRow(int Secuancial)
        {
            List<Tarea_det_Info> list = get_list();
            list.Remove(list.Where(m => m.Secuancial == Secuancial).First());
        }
        public void UpdateRow(Tarea_det_Info info_det)
        {
            Tarea_det_Info edited_info = get_list().Where(m => m.Secuancial == info_det.Secuancial).First();
            edited_info.FechaFin = info_det.FechaFin;
            edited_info.FechaInicio = info_det.FechaInicio;
            edited_info.Descripcion = info_det.Descripcion;
            edited_info.OrdenEjecuacion = info_det.OrdenEjecuacion;
        }
    }



    public static class TareaArchivoAdjunto_Info_lis
    {
        public static List<TareaArchivoAdjunto_Info> get_list()
        {
            if (HttpContext.Current.Session["TareaArchivoAdjunto_Info"] == null)
            {
                List<TareaArchivoAdjunto_Info> list = new List<TareaArchivoAdjunto_Info>();

                HttpContext.Current.Session["TareaArchivoAdjunto_Info"] = list;
            }
            var lis= (List<TareaArchivoAdjunto_Info>)HttpContext.Current.Session["TareaArchivoAdjunto_Info"];
            return (List<TareaArchivoAdjunto_Info>)HttpContext.Current.Session["TareaArchivoAdjunto_Info"];
        }

        public static void set_list(List<TareaArchivoAdjunto_Info> list)
        {
            HttpContext.Current.Session["TareaArchivoAdjunto_Info"] = list;
        }

        public static void AddRow(TareaArchivoAdjunto_Info info_det)
        {
            List<TareaArchivoAdjunto_Info> list = get_list();
            info_det.Secuencial = list.Count() + 1;
            list.Add(info_det);
        }
        public static void DeleteRow(int Secuancial)
        {
            List<TareaArchivoAdjunto_Info> list = get_list();
            list.Remove(list.Where(m => m.Secuencial == Secuancial).First());
        }
        public static void UpdateRow(TareaArchivoAdjunto_Info info_det)
        {
            TareaArchivoAdjunto_Info edited_info = get_list().Where(m => m.Secuencial == info_det.Secuencial).First();
            edited_info.NombreArchivo = info_det.NombreArchivo;
            edited_info.tamanio_file = info_det.tamanio_file;
        }
    }


}