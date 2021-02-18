using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Servidor.Servicio.Entidades
{
    [DataContract]
   public class TurnoDto
    {
        [DataMember]
        public int Codigo { get; set; }
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public TimeSpan HoraInicio { get; set; }
        [DataMember]
        public TimeSpan HoraFin { get; set; }
    }
}
