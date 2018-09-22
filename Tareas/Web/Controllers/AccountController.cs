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
       
        [AllowAnonymous]
        public ActionResult Login()
        {
            Session.Contents.RemoveAll();
            Usuario_Info model = new Usuario_Info();
            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Usuario_Info model)
        {

            Usuario_Bus bus_usuario = new Usuario_Bus();
            bool usuario_clave_exist = bus_usuario.validar_login(model.IdUsuario, model.Clave);
            if (usuario_clave_exist)
            {
                SessionTareas.IdUsuario = model.IdUsuario;

                SessionTareas.IdTransaccionSession = 1 + "000000000";
                SessionTareas.IdTransaccionSessionActual = SessionTareas.IdTransaccionSession;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.mensaje = "Credenciales incorrectas";
            return View(model);
        }
     
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session.Contents.RemoveAll();
            return RedirectToAction("Login");
        }
        
    }
}