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

            string mensaje = "error intencial!!";
            //var usuario = _blogArticuloServicio.ObtenerUsuarioPorNickYPass(model.Nick, model.Password, ref mensaje);

            if (!string.IsNullOrEmpty(mensaje))
            {
                model.ErrorLogin = mensaje;
                return View(model);
            }
            Session["Session_Usuario_Id"] = 0;
            return RedirectToAction("Index", "ControlCalidad");
        }
    }
}