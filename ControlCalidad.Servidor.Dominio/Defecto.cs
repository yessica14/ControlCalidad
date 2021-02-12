using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Servidor.Dominio
{
    public class Defecto
    {
        public int Numero { get; set; }
        public string Descripcion { get; set; }
        public TipoDefecto TipoDeDefecto { get; set; }
    }
}
