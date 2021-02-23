using System;
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
            empresa.ListaDeColores.Add
            (
                new Color()
                {
                    Codigo = 803,
                    Descripcion = "Gris"
                }
            );
            empresa.ListaDeColores.Add
            (
                new Color()
                {
                    Codigo = 804,
                    Descripcion = "Negro"
                }
            );
            Singleton.getInstancia().AsignarDatosAEmpresa(empresa);
        }

        public static int ObtenerUltimoId()
        {

            return Singleton.getInstancia().ObtenerDatosDeEmpresa().ListaDeColores.OrderByDescending(x => x.Codigo).FirstOrDefault().Codigo + 1;
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

        public static void AgregarColor(Color color)
        {
            Singleton.getInstancia().ObtenerDatosDeEmpresa().ListaDeColores.Add(color);
        }

        public static void ModificarColor(Color color)
        {
            EliminarColor(color);
            AgregarColor(color);
        }

        public static void EliminarColor(Color color)
        {
            Singleton.getInstancia().ObtenerDatosDeEmpresa().ListaDeColores.RemoveAll(_color => _color.Codigo == color.Codigo);
        }
    }
}
