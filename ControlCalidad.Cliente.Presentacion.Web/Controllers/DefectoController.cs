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
                return RedirectToAction("Index", "ControlCalidad", new { mensaje= "Usted no esta trabajando en ninguna OP."});
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

        [HttpPost]
        public ActionResult EliminarHallazgo(FormCollection collection)
        {
            var idOp = int.Parse(collection["nHiddenIdOp"].ToString());
            var idHorario = int.Parse(collection["nHiddenIdHorario"].ToString());
            var idHallazgo = int.Parse(collection["nHiddenIdHallazgo"].ToString());

            Adaptador.EliminarHallazgo(idOp, idHorario, idHallazgo);
            return RedirectToAction("HistorialOp", "Defecto", new { txtOp = idOp.ToString()});
        }

        [HttpPost]
        public ActionResult ObtenerListaDeDefectos(string tipoDefecto)
        {

            var listaDefecto = Adaptador.ObtenerListaDefectos(tipoDefecto);
            string datos = "";

            foreach (var item in listaDefecto)
            {
                datos = datos + ",{\"id\": \"" + item.Numero.ToString() + "\", \"descripcion\": \"" + item.Descripcion + "\"}";
            }

            datos = datos.Substring(1);
            string json = " {\"listaDefectos\":[ " + datos + " ]}";

            return Json(json);
        }

        public ActionResult Hermanado()
        {
            if (Session["Session_Usuario_Id"] == null)
                return RedirectToAction("Login", "Home");

            int idSuperivisorCalidad = int.Parse(Session["Session_Usuario_Id"].ToString());

            var usuarioDto = Adaptador.ObtenerUsuarioPorId(idSuperivisorCalidad);
            var opDto = Adaptador.ObtenerOpAsignadoAUnEmpleado(usuarioDto.UsuarioDeEmpleado);

            if (opDto == null)
                return RedirectToAction("Index", "ControlCalidad", new { mensaje = "Usted no esta trabajando en ninguna OP." });

            Adaptador.RealizarHermanado(opDto.Numero, idSuperivisorCalidad);
            opDto = Adaptador.ObtenerOpAsignadoAUnEmpleado(usuarioDto.UsuarioDeEmpleado);

            var model = new HermanadoViewModel();
            model.OpDto = opDto;

            return View(model);
        }
    }
}