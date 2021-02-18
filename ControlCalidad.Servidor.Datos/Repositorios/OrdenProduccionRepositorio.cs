﻿using ControlCalidad.Servidor.Datos.Persistencia;
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
        private ModeloRepositorio modeloRepositorio = new ModeloRepositorio();
        private LineaRepositorio lineaRepositorio = new LineaRepositorio();
        private EmpleadoRepositorio empleadoRepositorio = new EmpleadoRepositorio();
        private TurnoRepositorio turnoRepositorio = new TurnoRepositorio();

        public void CargarOrdenesProduccionServicio()
        {
            var empresa = Singleton.getInstancia().ObtenerDatosDeEmpresa();
            empresa.ListaDeOrdenesDeProduccion.Add
           (
               new OrdenProduccion()
               {
                   Numero = 499,
                   ModeloOP = ModeloRepositorio.ObtenerModeloPorSku(1401),
                   EstadoDeOP = EstadoOP.Finalizado,
                   LineaTrabajo = lineaRepositorio.ObtenerLineaPorId(100),

               }
           );

            empresa.ListaDeOrdenesDeProduccion.Add
            (
                new OrdenProduccion()
                {
                    Numero = 499,
                    ModeloOP = ModeloRepositorio.ObtenerModeloPorSku(1400),
                    EstadoDeOP = EstadoOP.Iniciado,
                    LineaTrabajo = lineaRepositorio.ObtenerLineaPorId(100),
                }
            );
            empresa.ListaDeOrdenesDeProduccion.Add
            (
                new OrdenProduccion()
                {
                    Numero = 501,
                    ModeloOP = ModeloRepositorio.ObtenerModeloPorSku(1401),
                    EstadoDeOP = EstadoOP.Pausado,
                    LineaTrabajo = lineaRepositorio.ObtenerLineaPorId(104),
                }
            );

        }
        public static List<OrdenProduccion> ObtenerTodasLasOrdenProduccion()
        {
            var empresa = Singleton.getInstancia().ObtenerDatosDeEmpresa();
            return empresa.ListaDeOrdenesDeProduccion;
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
