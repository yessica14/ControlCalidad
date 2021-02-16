using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Servidor.Servicio.Entidades
{
    [DataContract]
    public class EmpleadoDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int Documento { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Apellido { get; set; }
        [DataMember]
        public string CorreoElectronico { get; set; }
    }
}
