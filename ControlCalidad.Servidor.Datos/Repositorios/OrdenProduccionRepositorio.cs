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

            //empresa.ListaDeOrdenesDeProduccion.Add
            //(
            //    new OrdenProduccion()
            //    {
            //        Numero = 500,
            //        ModeloOP = ModeloRepositorio.ObtenerModeloPorSku(1400),
            //        ColorCalzado = ColorRepositorio.ObtenerColorPorId(802),
            //        EstadoDeOP = EstadoOP.Iniciado,
            //        LineaTrabajo = linea
            //    }
            //);
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

            var listaHallazgo_7A10 = new List<Hallazgo>();
            listaHallazgo_7A10.Add
            (
                new Hallazgo()
                {
                    Id = 1,
                    Cantidad = 1,
                    HoraHallazgo = new TimeSpan(7, 15, 0),
                    DefectoHallazgo = DefectoRepositorio.ObtenerDefectoPorNumero(1004),
                    PieHallazgo = Pie.Izquierdo,
                    SupervisorCalidad = EmpleadoRepositorio.BuscarEmpleadoPorId(6)
                }
            );
            listaHallazgo_7A10.Add
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
            listaHallazgo_7A10.Add
            (
                new Hallazgo()
                {
                    Id = 3,
                    Cantidad = 1,
                    HoraHallazgo = new TimeSpan(7, 49, 0),
                    DefectoHallazgo = DefectoRepositorio.ObtenerDefectoPorNumero(1004),
                    PieHallazgo = Pie.Izquierdo,
                    SupervisorCalidad = EmpleadoRepositorio.BuscarEmpleadoPorId(6)
                }
            );
            listaHallazgo_7A10.Add
            (
                new Hallazgo()
                {
                    Id = 3,
                    Cantidad = -1,
                    HoraHallazgo = new TimeSpan(7, 51, 0),
                    DefectoHallazgo = DefectoRepositorio.ObtenerDefectoPorNumero(1004),
                    PieHallazgo = Pie.Izquierdo,
                    SupervisorCalidad = EmpleadoRepositorio.BuscarEmpleadoPorId(6)
                }
            );
            listaHallazgo_7A10.Add
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

            //var listaHallazgo_9 = new List<Hallazgo>();
            listaHallazgo_7A10.Add
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
           
            //var listaHallazgo_10 = new List<Hallazgo>();
            listaHallazgo_7A10.Add
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
           

            var listaHallazgo_15A15 = new List<Hallazgo>();
            listaHallazgo_15A15.Add
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
            listaHallazgo_15A15.Add
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

            var listaHallazgo_20A22 = new List<Hallazgo>();
            listaHallazgo_20A22.Add
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
            listaHallazgo_20A22.Add
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
            listaHallazgo_20A22.Add
            (
                new Hallazgo()
                {
                    Id = 13,
                    Cantidad = 1,
                    HoraHallazgo = new TimeSpan(22, 05, 0),
                    DefectoHallazgo = null,
                    PieHallazgo = Pie.Izquierdo,
                    SupervisorCalidad = EmpleadoRepositorio.BuscarEmpleadoPorId(6)
                }
            );
            listaHallazgo_20A22.Add
            (
                new Hallazgo()
                {
                    Id = 14,
                    Cantidad = 1,
                    HoraHallazgo = new TimeSpan(22, 15, 0),
                    DefectoHallazgo = DefectoRepositorio.ObtenerDefectoPorNumero(1006),
                    PieHallazgo = Pie.Derecho,
                    SupervisorCalidad = EmpleadoRepositorio.BuscarEmpleadoPorId(6)
                }
            );

            // lista de Primera de 8 a 9//
            var listaPrimera8A9 = new List<Primera>();
            listaPrimera8A9.Add
            (
                new Primera()
                {
                    Hora = new TimeSpan(8,0,0),
                    Cantidad = 2,
                    SupervisorCalidad = EmpleadoRepositorio.BuscarEmpleadoPorId(6)
                }
            );
            listaPrimera8A9.Add
            (
                new Primera()
                {
                    Hora = new TimeSpan(9, 0, 0),
                    Cantidad = 3,
                    SupervisorCalidad = EmpleadoRepositorio.BuscarEmpleadoPorId(6)
                }
            );

            // lista de Primera de 15 a 15//
            var listaPrimera15A15 = new List<Primera>();
            listaPrimera15A15.Add
            (
                new Primera()
                {
                    Hora = new TimeSpan(15, 0, 0),
                    Cantidad = 2,
                    SupervisorCalidad = EmpleadoRepositorio.BuscarEmpleadoPorId(6)
                }
            );

            // lista de Primera de 21 a 22//
            var listaPrimera21A22 = new List<Primera>();
            listaPrimera21A22.Add
            (
                new Primera()
                {
                    Hora = new TimeSpan(21, 0, 0),
                    Cantidad = 5,
                    SupervisorCalidad = EmpleadoRepositorio.BuscarEmpleadoPorId(6)
                }
            );
            listaPrimera21A22.Add
            (
                new Primera()
                {
                    Hora = new TimeSpan(22, 0, 0),
                    Cantidad = 1,
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
                    HoraFin = new TimeSpan(10, 59, 59),
                    TurnoHorario = TurnoRepositorio.ObtenerTurnoPorCodigo(100),
                    ListaDeHallazgos = listaHallazgo_7A10,
                    ListaDePrimera = listaPrimera8A9
                }
            );

            listaHorario.Add
            (
                new Horario()
                {
                    Id = 15,
                    Fecha = DateTime.Now,
                    HoraInicio = new TimeSpan(15, 0, 0),
                    HoraFin = null,
                    TurnoHorario = TurnoRepositorio.ObtenerTurnoPorCodigo(101),
                    ListaDeHallazgos = listaHallazgo_15A15,
                    ListaDePrimera = listaPrimera15A15
                }
            );

            listaHorario.Add
            (
                new Horario()
                {
                    Id = 20,
                    Fecha = DateTime.Now,
                    HoraInicio = new TimeSpan(20, 0, 0),
                    HoraFin = new TimeSpan(22, 59, 59),
                    TurnoHorario = TurnoRepositorio.ObtenerTurnoPorCodigo(102),
                    ListaDeHallazgos = listaHallazgo_20A22,
                    ListaDePrimera = listaPrimera21A22
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
