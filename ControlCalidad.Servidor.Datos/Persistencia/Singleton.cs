using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlCalidad.Servidor.Datos.Repositorios;
using ControlCalidad.Servidor.Dominio;

namespace ControlCalidad.Servidor.Datos.Persistencia
{
    public class Singleton
    {
        public static Singleton unicaInstancia;
        private ControlDeCalidad Empresa = null; //123123123
        
        private Usuario sessionDeUsuario;

        private Singleton()
        {
            if (Empresa == null)
            {
                Empresa = new ControlDeCalidad();
            }
        }

        public static Singleton getInstancia()
        {
            if (unicaInstancia == null)
            {
                unicaInstancia = new Singleton();
                var datos = new ControlDeCalidadRepositorio();
                datos.GenerarDatosAutomaticamente();
            }
            return unicaInstancia;
        }

        public ControlDeCalidad ObtenerDatosDeEmpresa() // hace un getter
        {
            return Empresa;
        }

        public void AsignarDatosAEmpresa(ControlDeCalidad controlCalidad) // hace un setter
        {
            Empresa = controlCalidad;
        }

        public Usuario SessionDeUsuario
        {
            get { return sessionDeUsuario; }
            set { sessionDeUsuario = value; }
        }

    }
}
