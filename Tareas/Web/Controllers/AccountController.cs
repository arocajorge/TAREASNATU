using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using Web.Models;
using Info;
using Bus;
using Web.Helps;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        Usuario_Bus bus_usuario = new Usuario_Bus();

        [AllowAnonymous]
        public ActionResult Login()
        {
            Usuario_Info model = new Usuario_Info();
            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Usuario_Info model)
        {
            var infousuario = bus_usuario.get_info(model.IdUsuario);
            SessionTareas.TipoUsuario = infousuario.TipoUsuario.ToString();

            bool usuario_clave_exist = bus_usuario.validar_login(model.IdUsuario, model.Clave);
            if (usuario_clave_exist)
            {
                SessionTareas.IdUsuario = model.IdUsuario;

                SessionTareas.IdTransaccionSession = 1 + "000000000";
                SessionTareas.IdTransaccionSessionActual = SessionTareas.IdTransaccionSession;
                return RedirectToAction("CargaLaboral", "MisTareas", new  {@Area="General" });
            }
            ViewBag.mensaje = "Credenciales incorrectas";
            return View(model);
        }
     
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            return RedirectToAction("Login");
        }

        public ActionResult CambiarContrasena(string IdUsuario = "")
        {
            Usuario_Info model = new Usuario_Info { IdUsuario = IdUsuario };
            return View(model);
        }
        [HttpPost]
        public ActionResult CambiarContrasena(Usuario_Info model)
        {
            model.Clave = string.IsNullOrEmpty(model.Clave) ? "" : model.Clave.Trim();
            model.new_clave = string.IsNullOrEmpty(model.new_clave) ? "" : model.new_clave.Trim();
            if (model.Clave == model.new_clave)
            {
                ViewBag.mensaje = "La nueva contraseña no debe ser igual a la anterior";
                return View(model);
            }
            if (!bus_usuario.modificarDB(model.IdUsuario, model.Clave, model.new_clave))
            {
                ViewBag.mensaje = "Credenciales incorrectas, por favor corrija";
                return View(model);
            }
            return RedirectToAction("Login");
        }


    }
}