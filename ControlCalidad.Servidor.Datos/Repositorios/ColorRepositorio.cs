﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlCalidad.Servidor.Datos.Persistencia;
using ControlCalidad.Servidor.Dominio;

namespace ControlCalidad.Servidor.Datos.Repositorios
{
    public class ColorRepositorio
    {
        public void CargarColores()
        {
            var empresa = Singleton.getInstancia().ObtenerDatosDeEmpresa();

            empresa.ListaDeColores.Add
            (
                new Color()
                {
                    Codigo = 800,
                    Descripcion = "Azul"
                }
            );
            empresa.ListaDeColores.Add
            (
                new Color()
                {
                    Codigo = 801,
                    Descripcion = "Rojo"
                }
            );
            empresa.ListaDeColores.Add
            (
                new Color()
                {
                    Codigo = 802,
                    Descripcion = "Verde"
                }
            );
            Singleton.getInstancia().AsignarDatosAEmpresa(empresa);
        }

        public int ObtenerUltimoId()
        {

            return Singleton.getInstancia().ObtenerDatosDeEmpresa().ListaDeColores.OrderBy(x => x.Codigo).FirstOrDefault().Codigo + 1;
        }

        public static Color ObtenerColorPorId(int id)
        {
            return Singleton.getInstancia().ObtenerDatosDeEmpresa().ListaDeColores.Where(x => x.Codigo == id).FirstOrDefault();
        }

        public static List<Color> ObtenerTodosLosColores()
        {
            var empresa = Singleton.getInstancia().ObtenerDatosDeEmpresa();
            return empresa.ListaDeColores.OrderBy(x => x.Descripcion).ToList();
        }

        public void AgregarColor(Color color)
        {
            Singleton.getInstancia().ObtenerDatosDeEmpresa().ListaDeColores.Add(color);
        }

        public void ModificarColor(Color color)
        {
            EliminarColor(color);
            AgregarColor(color);
        }

        public void EliminarColor(Color color)
        {
            Singleton.getInstancia().ObtenerDatosDeEmpresa().ListaDeColores.RemoveAll(_color => _color.Codigo == color.Codigo);
        }
    }
}