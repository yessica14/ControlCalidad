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
        public ActionResult Index(string respuestaServer ="")
        {
            if (Session["Session_Usuario_Id"] == null)
                return RedirectToAction("Login", "Home");

            var usuario = Adaptador.ObtenerUsuarioPorId(int.Parse(Session["Session_Usuario_Id"].ToString()));

            var model = new IndexViewModel();
            model.MensajeError = respuestaServer;
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
                    if (model.OrdenProduccionDto.Any(x => x.LineaTrabajo.SupervisorLinea.Id == usuario.Id && x.EstadoDeOP != EstadoOPDto.Finalizado ))
                    {
                        model.BotonNuevaOp = false;
                        model.BotonTrabarEnOp = false;
                        model.BotonModificarOp = true;
                        model.BotonAbandonarOp = false;
                        model.OrdenProduccionDto = model.OrdenProduccionDto.Where(x => x.LineaTrabajo.SupervisorLinea.Id == usuario.Id && x.EstadoDeOP != EstadoOPDto.Finalizado).ToList();
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
                    var ordenes = model.OrdenProduccionDto;
                    if (model.OrdenProduccionDto.Any(x => x.SupervisorCalidad != null && x.SupervisorCalidad.Id == usuario.Id && x.EstadoDeOP != EstadoOPDto.Finalizado) )
                    {
                        model.BotonNuevaOp = false;
                        model.BotonTrabarEnOp = false;
                        model.BotonModificarOp = false;
                        model.BotonAbandonarOp = true;
                        model.OrdenProduccionDto = model.OrdenProduccionDto.Where(x => x.SupervisorCalidad != null && x.SupervisorCalidad.Id == usuario.Id && x.EstadoDeOP != EstadoOPDto.Finalizado).ToList();
                    }
                    else
                    {
                        model.BotonNuevaOp = false;
                        model.BotonTrabarEnOp = true;
                        model.BotonModificarOp = false;
                        model.BotonAbandonarOp = false;
                        model.OrdenProduccionDto = model.OrdenProduccionDto.Where(x => x.SupervisorCalidad != null && x.SupervisorCalidad.Id == usuario.Id || ( x.EstadoDeOP == EstadoOPDto.Iniciado || x.EstadoDeOP == EstadoOPDto.Continuado)).ToList();
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

            DateTime fecha = DateTime.Now.Date;
            DateTime dt = DateTime.Now;
            //var hora = dt.ToLongTimeString();
            var hora = "8:30";

            bool b = Adaptador.ComprobarTurno(hora);
            if(b)
            {
                Adaptador.AgregarOrdenProduccion(ordenProduccion, usuarioDto.UsuarioDeEmpleado, fecha, hora);
            }
            
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

            var numeroOP = int.Parse(idOP);
            EstadoOPDto nuevoEstadoOP;
            DateTime fecha = DateTime.Now.Date;
            DateTime dt = DateTime.Now;
            var hora = dt.ToLongTimeString();

            switch (estadoNuevoOP)
            {
                case "Iniciado":
                default:
                    nuevoEstadoOP = EstadoOPDto.Iniciado;
                    break;
                case "Pausado":
                    nuevoEstadoOP = EstadoOPDto.Pausado;
                    Adaptador.CerrarHorario(numeroOP,hora, fecha);
                    break;
                case "Continuado":
                    nuevoEstadoOP = EstadoOPDto.Continuado;
                    Adaptador.AgregarNuevoHorario(numeroOP,hora, fecha);
                    break;
                case "Finalizado":
                    nuevoEstadoOP = EstadoOPDto.Finalizado;
                    Adaptador.CerrarHorario(numeroOP,hora, fecha);
                    break;
            }

            var opDto = Adaptador.ObtenerOpPorId(int.Parse(idOP));

           
            
            Adaptador.ModificarOrdenProduccion_Estado(opDto, nuevoEstadoOP);

            return RedirectToAction("Index", "OP");
        }

        [HttpPost]
        public ActionResult TrabajarEnOP(FormCollection collection)
        {
            var idOP = collection["nHiddenTrabajarIdOp"].ToString();

            var opDto = Adaptador.ObtenerOpPorId(int.Parse(idOP));

            var idUsuario = int.Parse(Session["Session_Usuario_Id"].ToString());

            var usuario = Adaptador.ObtenerUsuarioPorId(idUsuario);

            Adaptador.ModificarOrdenProduccion_Trabajar(opDto, usuario.UsuarioDeEmpleado);

            return RedirectToAction("Index", "OP");
        }

        [HttpPost]
        public ActionResult AbandonarOP(FormCollection collection)
        {
            var idOP = collection["nHiddenAbandonarIdOp"].ToString();

            var opDto = Adaptador.ObtenerOpPorId(int.Parse(idOP));

            var respuestaServer = Adaptador.ModificarOrdenProduccion_Abandonar(opDto);
            if (respuestaServer)
            {
                return RedirectToAction("Index", "OP");
            }
            else
            {
                return RedirectToAction("Index", "OP", new { @respuestaServer = "No se puede abandonar la OP" } );
            }

        }

    }
}