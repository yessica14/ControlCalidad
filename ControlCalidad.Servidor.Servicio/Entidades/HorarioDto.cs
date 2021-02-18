using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Servidor.Servicio.Entidades
{   [DataContract]
    public class HorarioDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public TimeSpan HoraInicio { get; set; }
        [DataMember]
        public TimeSpan HoraFin { get; set; }
        [DataMember]
        public TurnoDto TurnoHorario { get; set; }
        [DataMember]
        public List<HallazgoDto> ListaDeHallazgos { get; set; }
    }
}
