using ControlCalidad.Servidor.Dominio;
using ControlCalidad.Servidor.Servicio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Servidor.Servicio.Entidades
{   
    [DataContract]
    public class LineaDto
    {
        [DataMember]
        public int Numero { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public EmpleadoDto SupervisorLinea { get; set; }
    }
}
