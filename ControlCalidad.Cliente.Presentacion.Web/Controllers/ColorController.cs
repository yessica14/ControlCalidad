using ControlCalidad.Cliente.Presentacion.Web.Models.Color;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlCalidad.Cliente.Presentacion.Web.Controllers
{
    public class ColorController : Controller
    {
        // GET: Color
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult ListaColores()
        {
            var model = new ListaColoresViewModel();
            return View(model);
        }

        public ActionResult EditarColor()
        {
            var model = new EditarColoresViewModel(); 
            return View(model);
        }
    }
}