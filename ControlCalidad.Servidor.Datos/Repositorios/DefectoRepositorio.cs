﻿using ControlCalidad.Servidor.Datos.Persistencia;
using ControlCalidad.Servidor.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Servidor.Datos.Repositorios
{
    public class DefectoRepositorio
    {
        public void CargarDefectos()
        {
            var empresa = Singleton.getInstancia().ObtenerDatosDeEmpresa();

            empresa.ListaDeDefectos.Add
            (
                new Defecto()
                {
                    Numero = 1000,
                    Descripcion = "Mal pegado",
                    TipoDeDefecto = TipoDefecto.Reproceso
                }
            );
            empresa.ListaDeDefectos.Add
            (
                new Defecto()
                {
                    Numero = 1001,
                    Descripcion = "Altura Talon",
                    TipoDeDefecto = TipoDefecto.Reproceso
                }
            );
            empresa.ListaDeDefectos.Add
            (
                new Defecto()
                {
                    Numero = 1002,
                    Descripcion = "Falla Costura",
                    TipoDeDefecto = TipoDefecto.Reproceso
                }
            );
            empresa.ListaDeDefectos.Add
            (
                new Defecto()
                {
                    Numero = 1003,
                    Descripcion = "Serigrafia",
                    TipoDeDefecto = TipoDefecto.Reproceso
                }
            );
            empresa.ListaDeDefectos.Add
            (
                new Defecto()
                {
                    Numero = 1004,
                    Descripcion = "Suciedad",
                    TipoDeDefecto = TipoDefecto.Observado
                }
            );
            empresa.ListaDeDefectos.Add
            (
                new Defecto()
                {
                    Numero = 1005,
                    Descripcion = "Mal Trenzado",
                    TipoDeDefecto = TipoDefecto.Observado
                }
            );
            empresa.ListaDeDefectos.Add
            (
                new Defecto()
                {
                    Numero = 1006,
                    Descripcion = "Sin Protector",
                    TipoDeDefecto = TipoDefecto.Observado
                }
            );
        }

        public static Defecto ObtenerDefectoPorNumero(int numero)
        {
            var empresa = Singleton.getInstancia().ObtenerDatosDeEmpresa();
            return empresa.ListaDeDefectos.Where(x => x.Numero == numero).FirstOrDefault();
        }
        
        public static List<Defecto> ObtenerDefectoPorTipoDefecto(TipoDefecto tipoDefecto)
        {
            var empresa = Singleton.getInstancia().ObtenerDatosDeEmpresa();
            var listaDefecto = new List<Defecto>();
            foreach (var item in empresa.ListaDeDefectos)
            {
                if(item.TipoDeDefecto == tipoDefecto)
                {
                    listaDefecto.Add(item);
                }
            }
            return listaDefecto;
        }

        public static List<Defecto> ObtenerTodosLosDefectos()
        {
            var empresa = Singleton.getInstancia().ObtenerDatosDeEmpresa();
            var listaDefecto = new List<Defecto>();
            foreach (var item in empresa.ListaDeDefectos)
            {
                listaDefecto.Add(item);
            }
            return listaDefecto;
        }


    }
}
