using ControlCalidad.Servidor.Datos.Persistencia;
using ControlCalidad.Servidor.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Servidor.Datos.Repositorios
{
    public class OrdenProduccionRepositorio
    {

        public void CargarOrdenesProduccionServicio()
        {
            var empresa = Singleton.getInstancia().ObtenerDatosDeEmpresa();
            empresa.ListaDeOrdenesDeProduccion.Add
           (
               new OrdenProduccion()
               {
                   Numero = 499,
                   ModeloOP = ModeloRepositorio.ObtenerModeloPorSku(1401),
                   ColorCalzado = ColorRepositorio.ObtenerColorPorId(800),
                   EstadoDeOP = EstadoOP.Finalizado,
                   LineaTrabajo = LineaRepositorio.ObtenerLineaPorId(100),
                   SupervisorCalidad = EmpleadoRepositorio.BuscarEmpleadoPorId(2)
               }
           );

            empresa.ListaDeOrdenesDeProduccion.Add
            (
                new OrdenProduccion()
                {
                    Numero = 500,
                    ModeloOP = ModeloRepositorio.ObtenerModeloPorSku(1400),
                    ColorCalzado = ColorRepositorio.ObtenerColorPorId(802),
                    EstadoDeOP = EstadoOP.Iniciado,
                    LineaTrabajo = LineaRepositorio.ObtenerLineaPorId(100)
                }
            );
            empresa.ListaDeOrdenesDeProduccion.Add
            (
                new OrdenProduccion()
                {
                    Numero = 501,
                    ModeloOP = ModeloRepositorio.ObtenerModeloPorSku(1401),
                    ColorCalzado = ColorRepositorio.ObtenerColorPorId(804),
                    EstadoDeOP = EstadoOP.Pausado,
                    LineaTrabajo = LineaRepositorio.ObtenerLineaPorId(104)
                }
            );

        }
        public static List<OrdenProduccion> ObtenerTodasLasOrdenProduccion()
        {
            var empresa = Singleton.getInstancia().ObtenerDatosDeEmpresa();
            return empresa.ListaDeOrdenesDeProduccion.OrderByDescending(x => x.Numero).ToList();
        }
        public static int ObtenerUltimoId()
        {
            var empresa = Singleton.getInstancia().ObtenerDatosDeEmpresa();
            int id = empresa.ListaDeOrdenesDeProduccion.OrderByDescending(x => x.Numero).FirstOrDefault().Numero + 1;
            return id;
        }
        public static void AgregarOrdenproduccion(OrdenProduccion ordenProduccion)
        {
            Singleton.getInstancia().ObtenerDatosDeEmpresa().ListaDeOrdenesDeProduccion.Add(ordenProduccion);
        }
        public static void ModificarOrdenProduccion(OrdenProduccion ordenProduccion)
        {
            EliminarOrdenProduccion(ordenProduccion);
            AgregarOrdenproduccion(ordenProduccion);
        }
        public static void EliminarOrdenProduccion(OrdenProduccion ordenProduccion)
        {
            Singleton.getInstancia().ObtenerDatosDeEmpresa().ListaDeOrdenesDeProduccion.RemoveAll(op => op.Numero == ordenProduccion.Numero);
        }
    }
}
