using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlCalidad.Servidor.Datos.Persistencia;
using ControlCalidad.Servidor.Dominio;

namespace ControlCalidad.Servidor.Datos.Repositorios
{
    public class ControlDeCalidadRepositorio
    {
        private ControlDeCalidad empresa = Singleton.getInstancia().ObtenerDatosDeEmpresa();

        private EmpleadoRepositorio empleadoServicio = new EmpleadoRepositorio();
        private LineaRepositorio lineaServicio = new LineaRepositorio();

        public void GenerarDatosAutomaticamente()
        {
            empleadoServicio.CargarEmpleados();
            lineaServicio.CargarLineas();
        }
    }
}
