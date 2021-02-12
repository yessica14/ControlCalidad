using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Servidor.Servicio
{   [DataContract]
    public class LineaDto
    {
        [DataMember]
        public int Numero { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
    }
}
