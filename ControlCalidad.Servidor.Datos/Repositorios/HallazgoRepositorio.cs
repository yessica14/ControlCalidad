using ControlCalidad.Servidor.Datos.Persistencia;
using ControlCalidad.Servidor.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Servidor.Datos.Repositorios
{
    public class HallazgoRepositorio
    {
        public void CargarHallazgo()
        {
            var empresa = Singleton.getInstancia().ObtenerDatosDeEmpresa();
            
        }

    }
}
