using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlCalidad.Servidor.Datos.Persistencia;
using ControlCalidad.Servidor.Dominio;

namespace ControlCalidad.Servidor.Datos.Repositorios
{
    public class ModeloRepositorio
    {
        //private ColorRepositorio colorRepositorio = new ColorRepositorio();
        public void CargarModelos()
        {
            var empresa = Singleton.getInstancia().ObtenerDatosDeEmpresa();
            empresa.ListaDeModelos.Add(
                new Modelo()
                {
                    Sku = 1400,
                    Denominacion = "zapatilla nine",
                    Objetivo = 30
                }
            );
            empresa.ListaDeModelos.Add(
                new Modelo()
                {
                    Sku = 1401,
                    Denominacion = "zapato nine",
                    Objetivo = 40
                }
            );
            empresa.ListaDeModelos.Add(
                new Modelo()
                {
                    Sku = 1402,
                    Denominacion = "zapatilla adidas",
                    Objetivo = 50
                }
            );
            empresa.ListaDeModelos.Add(
                new Modelo()
                {
                    Sku = 1403,
                    Denominacion = "zapatilla toper",
                    Objetivo = 50
                }
            );
            Singleton.getInstancia().AsignarDatosAEmpresa(empresa);
        }

        public static int ObtenerUltimoSku()
        {
            var empresa = Singleton.getInstancia().ObtenerDatosDeEmpresa();

            Modelo modelo = empresa.ListaDeModelos.OrderByDescending(x => x.Sku).FirstOrDefault();
            int sku = modelo.Sku;
            return sku + 1;
        }

        public static Modelo ObtenerModeloPorSku(int sku)
        {
            var empresa = Singleton.getInstancia().ObtenerDatosDeEmpresa();
            var modelo = empresa.ListaDeModelos.Where(x => x.Sku == sku).FirstOrDefault();
            return modelo;
        }

        public static List<Modelo> ObtenerTodosLosModelos()
        {
            var empresa = Singleton.getInstancia().ObtenerDatosDeEmpresa();
            return empresa.ListaDeModelos.OrderByDescending(x => x.Sku).ToList();
        }

        public static void AgregarModelo(Modelo modelo)
        {
            Singleton.getInstancia().ObtenerDatosDeEmpresa().ListaDeModelos.Add(modelo);
        }

        public static void ModificarModelo(Modelo modelo)
        {
            EliminarModelo(modelo);
            AgregarModelo(modelo);
        }

        public static void EliminarModelo(Modelo modelo)
        {
            var empresa = Singleton.getInstancia().ObtenerDatosDeEmpresa();
            empresa.ListaDeModelos.RemoveAll(x => x.Sku == modelo.Sku);
        }
    }
}
