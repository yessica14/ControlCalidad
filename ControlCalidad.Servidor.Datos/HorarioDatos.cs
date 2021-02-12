using ControlCalidad.Servidor.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Servidor.Datos
{
    public class HorarioDatos
    {
        public IEnumerable<Horario> GetHorarios()
        {
            return new List<Horario>()
            {
                new Horario
                {
                    Codigo=1,
                    HoraInicio=new TimeSpan(6,20,00),
                    HoraFin=new TimeSpan(18,30,00)
                },
                new Horario
                {
                    Codigo=2,
                    HoraInicio=new TimeSpan(11,5,0),
                    HoraFin=new TimeSpan(1,30,00)
                },
                 new Horario
                {
                    Codigo=3,
                    HoraInicio=new TimeSpan(6,20,00),
                    HoraFin=new TimeSpan(18,30,00)
                }
            };

        }
    }
}
