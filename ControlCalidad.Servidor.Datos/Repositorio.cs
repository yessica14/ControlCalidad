using ControlCalidad.Servidor.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Servidor.Datos
{
    public class Repositorio
    {
        public static IEnumerable<Linea> GetLineas()
        {
            return new List<Linea>()
            {
               new Linea
               {
                   Numero=1,
                   Descripcion="Linea 1"
               },
                new Linea
               {
                   Numero=2,
                   Descripcion="Linea 2"
               },
                 new Linea
               {
                   Numero=3,
                   Descripcion="Linea 3"
               }

            };

        }



    }
}
