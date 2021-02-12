using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Servidor.Dominio
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string  Contraseña { get; set; }
        public Empleado UsuarioDeEmpleado { get; set; }
        public TipoUsuario TipoDeUsuario { get; set; }
    }
}
