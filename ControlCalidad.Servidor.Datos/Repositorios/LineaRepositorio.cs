﻿using ControlCalidad.Servidor.Datos.Persistencia;
using ControlCalidad.Servidor.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Servidor.Datos.Repositorios
{
    public class LineaRepositorio
    {
        private EmpleadoRepositorio empleadoServicio = new EmpleadoRepositorio();
        public void CargarLineas()
        {
            var empresa = Singleton.getInstancia().ObtenerDatosDeEmpresa();
            empresa.ListaDeLineas.Add
            (
                new Linea()
                {
                    Numero = 100,
                    Descripcion = "Linea Trabajo 100",
                    SupervisorLinea = empleadoServicio.BuscarEmpleadoPorId(1)
                }
            );
            empresa.ListaDeLineas.Add
            (
                new Linea()
                {
                    Numero = 101,
                    Descripcion = "Linea Trabajo 101"

                }
            );
            empresa.ListaDeLineas.Add
            (
                new Linea()
                {
                    Numero = 102,
                    Descripcion = "Linea Trabajo 102"
                }
            );
            empresa.ListaDeLineas.Add
            (
                new Linea()
                {
                    Numero = 103,
                    Descripcion = "Linea Trabajo 103"
                }
            );
            empresa.ListaDeLineas.Add
            (
                new Linea()
                {
                    Numero = 104,
                    Descripcion = "Linea Trabajo 104",
                    SupervisorLinea = empleadoServicio.BuscarEmpleadoPorId(4)
                }
            );
            empresa.ListaDeLineas.Add
            (
                new Linea()
                {
                    Numero = 105,
                    Descripcion = "Linea Trabajo 105",
                    SupervisorLinea = empleadoServicio.BuscarEmpleadoPorId(4)
                }
            );
            Singleton.getInstancia().AsignarDatosAEmpresa(empresa);
        }

        public Linea ObtenerLineaPorId(int numero)
        {
            var empresa = Singleton.getInstancia().ObtenerDatosDeEmpresa();
            return empresa.ListaDeLineas.Where(x => x.Numero == numero).FirstOrDefault();
        }

        public static List<Linea> ObtenerLineas()
        {
            var empresa = Singleton.getInstancia().ObtenerDatosDeEmpresa();
            return empresa.ListaDeLineas.ToList();// no lo hace 

            //return empresa.ListaDeLineasDeTrabajo.Where(y => y.Empleado == null).OrderBy(x => x.Numero).ToList();
        }

        public static List<Linea> ObtenerLineasSinEmpleado()
        {
            var empresa = Singleton.getInstancia().ObtenerDatosDeEmpresa();
            return empresa.ListaDeLineas.Where(y => y.SupervisorLinea == null).ToList();// no lo hace 

            //return empresa.ListaDeLineasDeTrabajo.Where(y => y.Empleado == null).OrderBy(x => x.Numero).ToList();
        }

        public void AgregarLinea(Linea linea)
        {
            Singleton.getInstancia().ObtenerDatosDeEmpresa().ListaDeLineas.Add(linea);
        }

        public void ModificarLinea(Linea linea)
        {
            EliminarLinea(linea);
            AgregarLinea(linea);
        }

        public void EliminarLinea(Linea linea)
        {
            Singleton.getInstancia().ObtenerDatosDeEmpresa().ListaDeLineas.RemoveAll(x => x.Numero == linea.Numero);
        }
    }
}
