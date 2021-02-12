using ControlCalidad.Servidor.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Servidor.Datos
{
    public class TurnoDatos
    {
        public IEnumerable<Turno> GetTurnos()
        {
            return new List<Turno>()
            {
                new Turno
                {
                  Codigo=1,
                  nombre="mañana",
                  HoraInicio=new TimeSpan(8,0,0),
                  HoraFin=new TimeSpan(12,0,0),

                },
                new Turno
                {
                  Codigo=2,
                  nombre="tarde",
                  HoraInicio=new TimeSpan(12,0,1),
                   HoraFin=new TimeSpan(18,0,0),
                },
                new Turno
                {
                  Codigo=3,
                  nombre="noche",
                  HoraInicio=new TimeSpan(18,0,1),
                  HoraFin=new TimeSpan(00,0,0),
                },

            };
        }
    }
}
