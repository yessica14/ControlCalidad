using ControlCalidad.Servidor.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Servidor.Datos
{
    public class ModeloDatos
    {
        public static IEnumerable<Modelo> GetModelos()
        {
            return new List<Modelo>()
            {
                new Modelo
                {
                    Sku=25,
                    Denominacion= "zapato",
                },
                new Modelo
                {
                    Sku=26,
                    Denominacion= "zapatilla",
                },
                new Modelo
                {
                    Sku=27,
                    Denominacion= "zapato",
                },
            };
        }
    }
}
