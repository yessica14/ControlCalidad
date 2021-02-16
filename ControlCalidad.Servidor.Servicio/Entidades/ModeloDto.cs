using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ControlCalidad.Servidor.Dominio;

namespace ControlCalidad.Servidor.Servicio.Entidades
{
    [DataContract]
    public class ModeloDto
    {
        [DataMember]
        public int Sku { get; set; }
        [DataMember]
        public string Denominacion { get; set; }
        [DataMember]
        public int Objetivo { get; set; }
        [DataMember]
        public ColorDto ColorModelo { get; set; }
    }
}
