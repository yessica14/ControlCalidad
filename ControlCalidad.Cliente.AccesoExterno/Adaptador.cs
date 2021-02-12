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
                return servicio.GetLineas();
            }      
        }
        /*
        public static void SetLineas(int id, string nobre)
        {
            using (var servicio = new ControlCalidadServiceReference.ControlCalidadServicioClient())
            {
                servicio.SetLineas();
            }
        }
        */
        public static LineaDto[] obtenerLineasDeTrabajosinempleaod()
        {
            using (var servicio = new ControlCalidadServiceReference.ControlCalidadServicioClient())
            {
                return servicio.GetLineas();
            }
        }

    }
}
