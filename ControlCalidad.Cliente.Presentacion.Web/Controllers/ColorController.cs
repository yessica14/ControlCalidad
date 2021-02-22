using ControlCalidad.Cliente.AccesoExterno;
using ControlCalidad.Cliente.AccesoExterno.ControlCalidadServiceReference;
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
            if (Session["Session_Usuario_Id"] == null)
                return RedirectToAction("Login", "Home");

            var model = new IndexViewModel();
            model.ListaColores = Adaptador.ObtenerColores().ToList();
            return View(model);
        }
        
        [HttpPost]
        public ActionResult EliminarColor(FormCollection collection)
        {
            if (Session["Session_Usuario_Id"] == null)
                return RedirectToAction("Login", "Home");

            var colorDto = new ColorDto();
            colorDto.Codigo = int.Parse(collection["nHiddenEliminar"].ToString());
            var respuestaServer = Adaptador.EliminarColor(colorDto);

            return RedirectToAction("Index", "Color");
        }

        [HttpGet]
        public ActionResult GestionABM(string tipoGestion, string txtCodigo = "")
        {
            if (Session["Session_Usuario_Id"] == null)
                return RedirectToAction("Login", "Home");

            var model = new GestionAbmViewModel();
            model.TipoGestion = tipoGestion;

            switch (tipoGestion)
            {
                case "ALTA":
                    var colorDto = new ColorDto();
                    colorDto.Codigo = Adaptador.ObtenerUltimoIdColor();

                    model.Color = colorDto;

                    break;

                case "MODIFICACION":

                    var colorDtoServer = Adaptador.ObtenerColorPorId(int.Parse(txtCodigo));
                    model.Color = colorDtoServer;
                    model.ValDescripcion = colorDtoServer.Descripcion;
                    break;

                default:
                    RedirectToAction("Login", "Home");
                    break;
            }
          
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GestionABM(GestionAbmViewModel model, FormCollection collection)
        {
            if (Session["Session_Usuario_Id"] == null)
                return RedirectToAction("Login", "Home");

            model.TipoGestion = collection["nHiddenTipoGestion"].ToString();

            switch (model.TipoGestion)
            {
                case "ALTA":
                    var colorDto = new ColorDto();
                    colorDto.Codigo = Adaptador.ObtenerUltimoIdColor();

                    model.Color = colorDto;

                    break;

                case "MODIFICACION":

                    var colorDtoServer = Adaptador.ObtenerColorPorId(int.Parse(collection["nHiddenCodigo"].ToString()));
                    model.Color = colorDtoServer;
                    //model.ValDescripcion = colorDtoServer.Descripcion;
                    break;

                default:
                    RedirectToAction("Login", "Home");
                    break;
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Color.Descripcion = model.ValDescripcion;

            switch (model.TipoGestion)
            {
                case "ALTA":
                    Adaptador.AgregarColor(model.Color);
                    break;

                case "MODIFICACION":
                    Adaptador.ModificarColor(model.Color);
                    break;

                default:
                    RedirectToAction("Login", "Home");
                    break;
            }


            return RedirectToAction("Index", "Color");
        }

    }

}