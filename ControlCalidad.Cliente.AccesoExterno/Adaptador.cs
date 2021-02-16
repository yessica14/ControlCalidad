using ControlCalidad.Cliente.AccesoExterno.ControlCalidadServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Cliente.AccesoExterno
{
    public class Adaptador
    {
        public static LineaDto[] GetLineas()
        { 
            using(var servicio = new ControlCalidadServiceReference.ControlCalidadServicioClient())
            {
                return servicio.ObtenerLineas();
            }
        }

        public static LineaDto[] ObtenerLineasSinEmpleado()
        {
            using (var servicio = new ControlCalidadServiceReference.ControlCalidadServicioClient())
            {
                return servicio.ObtenerLineasSinEmpleado();
            }
        }

    }
}
