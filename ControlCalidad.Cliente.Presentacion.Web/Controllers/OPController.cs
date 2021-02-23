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

            var usuario = Adaptador.ObtenerUsuarioPorId(int.Parse(Session["Session_Usuario_Id"].ToString()));

            var model = new IndexViewModel();
            model.OrdenProduccionDto = Adaptador.ObtenerTodasLasOrdenProduccion().ToList();

            switch (usuario.TipoDeUsuario)
            {
                case TipoUsuarioDto.Administrador:
                    model.BotonNuevaOp = false;
                    model.BotonTrabarEnOp = false;
                    model.BotonModificarOp = false;
                    model.BotonAbandonarOp = false;
                    break;

                case TipoUsuarioDto.SupervisorLinea:
                    if (model.OrdenProduccionDto.Any(x => x.LineaTrabajo.SupervisorLinea.Id == usuario.Id))
                    {
                        model.BotonNuevaOp = false;
                        model.BotonTrabarEnOp = false;
                        model.BotonModificarOp = true;
                        model.BotonAbandonarOp = false;
                        model.OrdenProduccionDto = model.OrdenProduccionDto.Where(x => x.LineaTrabajo.SupervisorLinea.Id == usuario.Id).ToList();
                    }
                    else
                    {
                        model.BotonNuevaOp = true;
                        model.BotonTrabarEnOp = false;
                        model.BotonModificarOp = false;
                        model.BotonAbandonarOp = false;
                    }
                    break;

                case TipoUsuarioDto.SupervisorCalidad:
                    if (model.OrdenProduccionDto.Any(x => x.SupervisorCalidad != null && x.SupervisorCalidad.Id == usuario.Id && x.EstadoDeOP != EstadoOPDto.Finalizado) )
                    {
                        model.BotonNuevaOp = false;
                        model.BotonTrabarEnOp = false;
                        model.BotonModificarOp = false;
                        model.BotonAbandonarOp = true;
                        model.OrdenProduccionDto = model.OrdenProduccionDto.Where(x => x.SupervisorCalidad != null && x.SupervisorCalidad.Id == usuario.Id).ToList();
                    }
                    else
                    {
                        model.BotonNuevaOp = false;
                        model.BotonTrabarEnOp = true;
                        model.BotonModificarOp = false;
                        model.BotonAbandonarOp = false;
                    }
                    break;

                default:
                    break;
            }

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
                ColoresDtos = Adaptador.ObtenerColores().ToList(),
                OrdenProduccion = nuevaOP
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alta(FormCollection collection)
        {
            if (Session["Session_Usuario_Id"] == null)
                return RedirectToAction("Login", "Home");

            var txtLinea = collection["nSelectLinea"].ToString();
            var txtModelo = collection["nSelectModelo"].ToString();
            var txtColor = collection["nSelectColor"].ToString();

            var ordenProduccion = new OrdenProduccionDto();
            ordenProduccion.Numero = Adaptador.ObtenerUltimoIdOP();
            ordenProduccion.EstadoDeOP = EstadoOPDto.Iniciado;

            ordenProduccion.ModeloOP = Adaptador.ObtenerModeloPorSku(int.Parse(txtModelo));
            ordenProduccion.LineaTrabajo = Adaptador.ObtenerLineaPorId(int.Parse(txtLinea));
            ordenProduccion.ColorCalzado = Adaptador.ObtenerColorPorId(int.Parse(txtColor));

            var usuarioDto = Adaptador.ObtenerUsuarioPorId(int.Parse(Session["Session_Usuario_Id"].ToString()));

            Adaptador.AgregarOrdenProduccion(ordenProduccion, usuarioDto.UsuarioDeEmpleado);

            return RedirectToAction("Index", "OP");
        }

        [HttpPost]
        public ActionResult ObtenerEstadosOps(FormCollection collection)
        {
            var idOP = collection["id"].ToString();
            var opDto = Adaptador.ObtenerOpPorId(int.Parse(idOP));

            var nuevosEstados = Adaptador.ObtenerNuevosEstadosOp(opDto.EstadoDeOP).ToList();

            string datos = "";
            foreach (var item in nuevosEstados)
            {
                datos = datos + ",\"" + item.ToString() + "\"";
            }
            datos = datos.Substring(1);
            
            string json = "{\"nuevosEstadosOp\": [" + datos + "]}";

            return Json(json);
        }

        [HttpPost]
        public ActionResult ModificarEstadoOP(FormCollection collection)
        {
            var idOP = collection["nHiddenModicarIdOp"].ToString();
            var estadoNuevoOP = collection["nSelectModicarOp"].ToString();

            EstadoOPDto estadoOP = EstadoOPDto.Iniciado;
            switch (estadoNuevoOP)
            {
                case "Iniciado":
                    estadoOP = EstadoOPDto.Iniciado;
                    break;
                case "Pausado":
                    estadoOP = EstadoOPDto.Pausado;
                    break;
                case "Continuado":
                    estadoOP = EstadoOPDto.Continuado;
                    break;
                case "Finalizado":
                    estadoOP = EstadoOPDto.Finalizado;
                    break;
            }

            var opDto = Adaptador.ObtenerOpPorId(int.Parse(idOP));

            Adaptador.ModificarOrdenProduccion_Estado(opDto, estadoOP);

            return RedirectToAction("Index", "OP");
        }

        [HttpPost]
        public ActionResult TrabajarEnOP(FormCollection collection)
        {
            var idOP = collection["nHiddenTrabajarIdOp"].ToString();

            var opDto = Adaptador.ObtenerOpPorId(int.Parse(idOP));

            //Adaptador.ModificarOrdenProduccion_Trabajar();

            return RedirectToAction("Index", "OP");
        }

        [HttpPost]
        public ActionResult AbandonarOP(FormCollection collection)
        {
            var idOP = collection["nHiddenAbandonarIdOp"].ToString();

            var opDto = Adaptador.ObtenerOpPorId(int.Parse(idOP));

            Adaptador.ModificarOrdenProduccion_Abandonar(opDto);

            return RedirectToAction("Index", "OP");
        }

    }
}