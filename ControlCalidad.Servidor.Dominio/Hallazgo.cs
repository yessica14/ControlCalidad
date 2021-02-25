using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Servidor.Dominio
{
    public class Hallazgo
    {
        public int Cantidad { get; set; }
        public TimeSpan HoraHallazgo { get; set; }
        public Defecto DefectoHallazgo { get; set; }
        public Pie PieHallazgo { get; set; }
        public Empleado SupervisorCalidad { get; set; }

    }
}
