﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Servidor.Dominio
{
    public class Primera
    {
        public TimeSpan Hora { get; set; }
        public int Cantidad{ get; set; }
        public Empleado SupervisorCalidad { get; set; }
    }
}
