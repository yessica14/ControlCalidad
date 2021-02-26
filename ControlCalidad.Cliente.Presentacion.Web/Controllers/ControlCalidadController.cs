using ControlCalidad.Cliente.Presentacion.Web.Models.ControlCalidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlCalidad.Cliente.Presentacion.Web.Controllers
{
    public class ControlCalidadController : Controller
    {
        // GET: ControlCalidad
        public ActionResult Index(string mensaje = "")
        {
            if (Session["Session_Usuario_Id"] == null)
                return RedirectToAction("Login", "Home");

            var model = new IndexViewModel()
            {
                Mensaje = mensaje
            };
            return View(model);
        }
    }
}