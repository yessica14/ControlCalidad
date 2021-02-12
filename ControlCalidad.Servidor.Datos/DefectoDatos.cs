using ControlCalidad.Servidor.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Servidor.Datos
{
    public class DefectoDatos
    {
        public static IEnumerable<Defecto> GetDefectos()
        {
            return new List<Defecto>()
            {
                new Defecto
                {
                  Numero=1,
                  Descripcion="Mal cocido"
                },
                 new Defecto
                {
                  Numero=2,
                  Descripcion="Mal cocido"
                },
                  new Defecto
                {
                  Numero=3,
                  Descripcion="Mal cocido"
                },

            };
        }
    }
}
