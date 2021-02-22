using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControlCalidad.Cliente.AccesoExterno;
using ControlCalidad.Cliente.AccesoExterno.ControlCalidadServiceReference;
using ControlCalidad.Cliente.Presentacion.Web.Models.OP;


namespace ControlCalidad.Cliente.Presentacion.Web.Controllers
{
    public class OPController : Controller
    {
        // GET: OP
        public ActionResult Index()
        {
            if (Session["Session_Usuario_Id"] == null)
                return RedirectToAction("Login", "Home");

            var model = new IndexViewModel
            {
                ordenProduccionDto= Adaptador.ObtenerTodasLasOrdenProduccion().ToList()
            };
            return View(model);
          
        }

        public ActionResult Alta()
        {
            if (Session["Session_Usuario_Id"] == null)
                return RedirectToAction("Login", "Home");

            var nuevaOP = new OrdenProduccionDto();
            nuevaOP.Numero = Adaptador.ObtenerUltimoIdOP();
            
            var model = new AltaViewModel()
            {
                LineasDtos = Adaptador.ObtenerLineasSinEmpleado().ToList(),
                ModelosDtos = Adaptador.ObtenerModelos().ToList(),
                OrdenProduccion = nuevaOP
            };

            return View(model);

        }
    }
}