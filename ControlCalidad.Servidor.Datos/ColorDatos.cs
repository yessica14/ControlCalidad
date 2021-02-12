using ControlCalidad.Servidor.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Servidor.Datos
{
    public class ColorDatos
    {
        public IEnumerable<Color> getColores()
        {
            return new List<Color>
            {
              new Color
              {
                  Codigo=1258,
                  Descripcion="Rojo"
              },
               new Color
              {
                  Codigo=1259,
                  Descripcion="Verde"
              },
                new Color
              {
                  Codigo=1238,
                  Descripcion="Azul"
              },

            };
        }
    }
}
