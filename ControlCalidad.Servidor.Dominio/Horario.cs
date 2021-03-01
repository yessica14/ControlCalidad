using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Servidor.Dominio
{
    public class Horario
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public Turno TurnoHorario { get; set; }
        public List<Hallazgo> ListaDeHallazgos { get; set; }
        public Primera ParesDePrimera { get; set; }
    }
}
