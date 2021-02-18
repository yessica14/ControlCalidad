using ControlCalidad.Cliente.AccesoExterno;
using ControlCalidad.Cliente.Presentacion.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlCalidad.Cliente.Presentacion.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            var model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string ReturnUrl, string esInvitado)
        {
            if (!ModelState.IsValid)
                return View(model);

            var usuarioDto = Adaptador.ComprobarLogueo(model.Nick, model.Password);
            
            if (usuarioDto == null)
            {
                model.ErrorLogin = "El nombre y/o la contraseña no son correctos o el usuario no existe";
                return View(model);
            }

            Session["Session_Usuario_Id"] = usuarioDto.Id;
            
            return RedirectToAction("Index", "ControlCalidad");
        }
    }
}