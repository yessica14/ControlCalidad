using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ControlCalidad.Servidor.Servicio.Entidades
{
    [DataContract]
    public class UsuarioDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Contraseña { get; set; }
        [DataMember]
        public EmpleadoDto UsuarioDeEmpleado { get; set; }
        [DataMember]
        public TipoUsuarioDto TipoDeUsuario { get; set; }
    }
}
