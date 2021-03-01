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

            var linea = LineaRepositorio.ObtenerLineaPorId(100);

            empresa.ListaDeOrdenesDeProduccion.Add
           (
               new OrdenProduccion()
               {
                   Numero = 499,
                   ModeloOP = ModeloRepositorio.ObtenerModeloPorSku(1401),
                   ColorCalzado = ColorRepositorio.ObtenerColorPorId(800),
                   EstadoDeOP = EstadoOP.Finalizado,
                   LineaTrabajo = linea,
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
                    LineaTrabajo = linea
                }
            );
            empresa.ListaDeOrdenesDeProduccion.Add
            (
                new OrdenProduccion()
                {
                    Numero = 501,
                    ModeloOP = ModeloRepositorio.ObtenerModeloPorSku(1401),
                    ColorCalzado = ColorRepositorio.ObtenerColorPorId(804),
                    EstadoDeOP = EstadoOP.Finalizado,
                    LineaTrabajo = LineaRepositorio.ObtenerLineaPorId(104)
                }
            );

            #region OP_CARGADA

            // ** litas de hallazgos ** //

            var listaHallazgo_7 = new List<Hallazgo>();
            listaHallazgo_7.Add
            (
                new Hallazgo()
                {
                    Id = 1,
                    Cantidad = 1,
                    HoraHallazgo = new TimeSpan(7, 15, 0),
                    DefectoHallazgo = null,
                    PieHallazgo = Pie.Izquierdo,
                    SupervisorCalidad = EmpleadoRepositorio.BuscarEmpleadoPorId(6)
                }
            );
            listaHallazgo_7.Add
            (
                new Hallazgo()
                {
                    Id = 2,
                    Cantidad = 1,
                    HoraHallazgo = new TimeSpan(7, 32, 0),
                    DefectoHallazgo = null,
                    PieHallazgo = Pie.Derecho,
                    SupervisorCalidad = EmpleadoRepositorio.BuscarEmpleadoPorId(6)
                }
            );
            listaHallazgo_7.Add
            (
                new Hallazgo()
                {
                    Id = 3,
                    Cantidad = 1,
                    HoraHallazgo = new TimeSpan(7, 49, 0),
                    DefectoHallazgo = DefectoRepositorio.ObtenerDefectoPorNumero(1005),
                    PieHallazgo = Pie.Izquierdo,
                    SupervisorCalidad = EmpleadoRepositorio.BuscarEmpleadoPorId(6)
                }
            );
            listaHallazgo_7.Add
            (
                new Hallazgo()
                {
                    Id = 4,
                    Cantidad = 1,
                    HoraHallazgo = new TimeSpan(7, 32, 0),
                    DefectoHallazgo = DefectoRepositorio.ObtenerDefectoPorNumero(1001),
                    PieHallazgo = Pie.Derecho,
                    SupervisorCalidad = EmpleadoRepositorio.BuscarEmpleadoPorId(6)
                }
            );

            var listaHallazgo_9 = new List<Hallazgo>();
            listaHallazgo_9.Add
            (
                new Hallazgo()
                {
                    Id = 5,
                    Cantidad = 1,
                    HoraHallazgo = new TimeSpan(9, 59, 0),
                    DefectoHallazgo = null,
                    PieHallazgo = Pie.Izquierdo,
                    SupervisorCalidad = EmpleadoRepositorio.BuscarEmpleadoPorId(6)
                }
            );
            var listaHallazgo_10 = new List<Hallazgo>();
            listaHallazgo_10.Add
            (
                new Hallazgo()
                {
                    Id = 6,
                    Cantidad = 1,
                    HoraHallazgo = new TimeSpan(10, 1, 0),
                    DefectoHallazgo = DefectoRepositorio.ObtenerDefectoPorNumero(1002),
                    PieHallazgo = Pie.Derecho,
                    SupervisorCalidad = EmpleadoRepositorio.BuscarEmpleadoPorId(6)
                }
            );

            var listaHallazgo_15 = new List<Hallazgo>();
            listaHallazgo_15.Add
            (
                new Hallazgo()
                {
                    Id = 11,
                    Cantidad = 1,
                    HoraHallazgo = new TimeSpan(15, 11, 0),
                    DefectoHallazgo = DefectoRepositorio.ObtenerDefectoPorNumero(1003),
                    PieHallazgo = Pie.Izquierdo,
                    SupervisorCalidad = EmpleadoRepositorio.BuscarEmpleadoPorId(6)
                }
            );
            listaHallazgo_15.Add
            (
                new Hallazgo()
                {
                    Id = 12,
                    Cantidad = 1,
                    HoraHallazgo = new TimeSpan(15, 14, 0),
                    DefectoHallazgo = null,
                    PieHallazgo = Pie.Derecho,
                    SupervisorCalidad = EmpleadoRepositorio.BuscarEmpleadoPorId(6)
                }
            );

            var listaHallazgo_20 = new List<Hallazgo>();
            listaHallazgo_20.Add
            (
                new Hallazgo()
                {
                    Id = 11,
                    Cantidad = 1,
                    HoraHallazgo = new TimeSpan(20, 01, 0),
                    DefectoHallazgo = null,
                    PieHallazgo = Pie.Izquierdo,
                    SupervisorCalidad = EmpleadoRepositorio.BuscarEmpleadoPorId(6)
                }
            );
            listaHallazgo_20.Add
            (
                new Hallazgo()
                {
                    Id = 12,
                    Cantidad = 1,
                    HoraHallazgo = new TimeSpan(20, 05, 0),
                    DefectoHallazgo = DefectoRepositorio.ObtenerDefectoPorNumero(1006),
                    PieHallazgo = Pie.Derecho,
                    SupervisorCalidad = EmpleadoRepositorio.BuscarEmpleadoPorId(6)
                }
            );

            // ** litas de Horarios ** //

            var listaHorario = new List<Horario>();
            listaHorario.Add
            (
                new Horario()
                {
                    Id = 7,
                    Fecha = DateTime.Now,
                    HoraInicio = new TimeSpan(7, 0, 0),
                    HoraFin = new TimeSpan(7, 59, 59),
                    TurnoHorario = TurnoRepositorio.ObtenerTurnoPorCodigo(100),
                    ListaDeHallazgos = listaHallazgo_7
                }
            );
            listaHorario.Add
            (
                new Horario()
                {
                    Id = 9,
                    Fecha = DateTime.Now,
                    HoraInicio = new TimeSpan(9, 0, 0),
                    HoraFin = new TimeSpan(9, 59, 59),
                    TurnoHorario = TurnoRepositorio.ObtenerTurnoPorCodigo(100),
                    ListaDeHallazgos = listaHallazgo_9
                }
            );
            listaHorario.Add
            (
                new Horario()
                {
                    Id = 10,
                    Fecha = DateTime.Now,
                    HoraInicio = new TimeSpan(10, 0, 0),
                    HoraFin = new TimeSpan(10, 59, 59),
                    TurnoHorario = TurnoRepositorio.ObtenerTurnoPorCodigo(100),
                    ListaDeHallazgos = listaHallazgo_10
                }
            );

            listaHorario.Add
            (
                new Horario()
                {
                    Id = 15,
                    Fecha = DateTime.Now,
                    HoraInicio = new TimeSpan(15, 0, 0),
                    HoraFin = new TimeSpan(15, 59, 59),
                    TurnoHorario = TurnoRepositorio.ObtenerTurnoPorCodigo(101),
                    ListaDeHallazgos = listaHallazgo_15
                }
            );

            listaHorario.Add
            (
                new Horario()
                {
                    Id = 20,
                    Fecha = DateTime.Now,
                    HoraInicio = new TimeSpan(20, 0, 0),
                    HoraFin = new TimeSpan(20, 59, 59),
                    TurnoHorario = TurnoRepositorio.ObtenerTurnoPorCodigo(102),
                    ListaDeHallazgos = listaHallazgo_20
                }
            );

            empresa.ListaDeOrdenesDeProduccion.Add
            (
                new OrdenProduccion()
                {
                    Numero = 502,
                    ModeloOP = ModeloRepositorio.ObtenerModeloPorSku(1403),
                    ColorCalzado = ColorRepositorio.ObtenerColorPorId(803),
                    EstadoDeOP = EstadoOP.Iniciado,
                    LineaTrabajo = LineaRepositorio.ObtenerLineaPorId(105),
                    SupervisorCalidad = EmpleadoRepositorio.BuscarEmpleadoPorId(6),
                    ListaDeHorario = listaHorario
                }
            );

            #endregion

        }
        public static List<OrdenProduccion> ObtenerTodasLasOrdenProduccion()
        {
            var empresa = Singleton.getInstancia().ObtenerDatosDeEmpresa();
            return empresa.ListaDeOrdenesDeProduccion.OrderByDescending(x => x.Numero).ToList();
        }

        public static OrdenProduccion ObtenerOrderProduccionPorId(int numero)
        {
            var empresa = Singleton.getInstancia().ObtenerDatosDeEmpresa();
            var op = empresa.ListaDeOrdenesDeProduccion.Where(x => x.Numero == numero).FirstOrDefault();
            return op;
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
