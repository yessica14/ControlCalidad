using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Servidor.Servicio.Entidades
{
    [DataContract]
    public class OrdenProduccionDto
    {
        [DataMember]
        public int Numero { get; set; }
        [DataMember]
        public int ParesPrimeraParHermanado { get; set; }
        [DataMember]
        public int ParesSegundaPorHermanado { get; set; }
        [DataMember]
        public EstadoOPDto EstadoDeOP { get; set; }
        [DataMember]
        public ModeloDto ModeloOP { get; set; }
        [DataMember]
        public ColorDto ColorCalzado { get; set; }
        [DataMember]
        public LineaDto LineaTrabajo { get; set; }
        [DataMember]
        public EmpleadoDto SupervisorCalidad { get; set; }

    }
}
