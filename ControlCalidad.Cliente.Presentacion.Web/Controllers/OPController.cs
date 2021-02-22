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
                OrdenProduccion = nuevaOP
            };

            return View(model);

        }
    }
}