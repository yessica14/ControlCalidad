using ControlCalidad.Cliente.AccesoExterno;
using ControlCalidad.Cliente.Presentacion.Web.Models.Informes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlCalidad.Cliente.Presentacion.Web.Controllers
{
    public class InformesController : Controller
    {
        // GET: Informe
        public ActionResult Primera()
        {
            if (Session["Session_Usuario_Id"] == null)
                return RedirectToAction("Login", "Home");

            var usuarioDto = Adaptador.ObtenerUsuarioPorId(int.Parse(Session["Session_Usuario_Id"].ToString()));
            var opDto = Adaptador.ObtenerOpAsignadoAUnEmpleado(usuarioDto.UsuarioDeEmpleado);

            if (opDto == null)
            {
                return RedirectToAction("Index", "ControlCalidad", new { mensaje = "Usted no esta trabajando en ninguna OP." });
            }

            var model = new PrimeraViewModel()
            {
                OpDto = opDto
            };
            return View(model);
        }
    }
}