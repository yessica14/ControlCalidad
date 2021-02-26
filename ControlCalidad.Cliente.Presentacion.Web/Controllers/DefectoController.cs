using ControlCalidad.Cliente.AccesoExterno;
using ControlCalidad.Cliente.Presentacion.Web.Models.Defecto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlCalidad.Cliente.Presentacion.Web.Controllers
{
    public class DefectoController : Controller
    {
        // GET: Defecto
        public ActionResult Inspeccionar()
        {
            return View();
        }

        public ActionResult HistorialOp(string txtOp)
        {
            if (Session["Session_Usuario_Id"] == null)
                return RedirectToAction("Login", "Home");

            int idOp = int.Parse(txtOp);
            var op = Adaptador.ObtenerOpPorId(idOp);

            var model = new HistorialOpViewModel()
            {
                OrdenProduccion = op
            };

            return View(model);
        }
    }
}