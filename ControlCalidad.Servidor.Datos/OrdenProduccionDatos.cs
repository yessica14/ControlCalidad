using ControlCalidad.Servidor.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Servidor.Datos
{
   public class OrdenProduccionDatos
    {
        public static IEnumerable<OrdenProduccion> GetOrdenProduccion()
        {
            return new List<OrdenProduccion>()
            {
                new OrdenProduccion
                {
                    Numero=100
                },
                 new OrdenProduccion
                {
                    Numero=101
                },
                  new OrdenProduccion
                {
                    Numero=102
                },

            };

        }
    }
}
