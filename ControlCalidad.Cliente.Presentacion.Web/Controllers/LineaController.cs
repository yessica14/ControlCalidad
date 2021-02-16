using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControlCalidad.Cliente.AccesoExterno;
using ControlCalidad.Cliente.Presentacion.Web.Models.Linea;

namespace ControlCalidad.Cliente.Presentacion.Web.Controllers
{
    public class LineaController : Controller
    {
        // GET: Linea
        public ActionResult Index()
        {
            var model = new IndexViewModel()
            {
                Lineas = Adaptador.GetLineas().ToList()
            };

            return View(model);
        }
    }
}