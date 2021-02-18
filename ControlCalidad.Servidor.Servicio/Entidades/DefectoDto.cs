using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Servidor.Servicio.Entidades
{
    [DataContract]
    public class DefectoDto
    {   [DataMember]
        public int Numero { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public TipoDefectoDto TipoDeDefecto { get; set; }
    }
}
