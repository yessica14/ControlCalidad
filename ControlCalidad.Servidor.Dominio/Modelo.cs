using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Servidor.Dominio
{
    public class Modelo
    {
        public int Sku { get; set; }
        public string Denominacion { get; set; }
        public int Objetivo { get; set; }
        public Color ColorModelo { get; set; }
    }
}