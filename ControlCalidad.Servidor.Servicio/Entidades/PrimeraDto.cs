using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Servidor.Servicio.Entidades
{
    [DataContract]
    public class PrimeraDto
    {
        [DataMember]
        public int Hora { get; set; }
        [DataMember]
        public int Cantidad { get; set; }
        [DataMember]
        public EmpleadoDto SupervisorCalidad { get; set; }
    }
}
