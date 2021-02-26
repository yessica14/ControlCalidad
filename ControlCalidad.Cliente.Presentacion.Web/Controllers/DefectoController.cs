using ControlCalidad.Cliente.AccesoExterno;
using ControlCalidad.Cliente.AccesoExterno.ControlCalidadServiceReference;
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
            if (Session["Session_Usuario_Id"] == null)
                return RedirectToAction("Login", "Home");

            var usuarioDto = Adaptador.ObtenerUsuarioPorId(int.Parse(Session["Session_Usuario_Id"].ToString()));
            var opDto = Adaptador.ObtenerOpAsignadoAUnEmpleado(usuarioDto.UsuarioDeEmpleado);

            if(opDto == null)
            {
                return RedirectToAction("Index", "ControlCalidad");
            }

            var model = new InspeccionarViewModel();

            model.OpDto = opDto;
            model.ListaDefecto = new List<DefectoDto>();
            model.Fecha = DateTime.Now;
            
            return View(model);
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