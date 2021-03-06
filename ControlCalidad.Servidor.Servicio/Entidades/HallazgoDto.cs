﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Servidor.Servicio.Entidades
{
    [DataContract]
    public class HallazgoDto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int Cantidad { get; set; }
        [DataMember]
        public TimeSpan HoraHallazgo { get; set; }
        [DataMember]
        public DefectoDto DefectoHallazgo { get; set; }
        [DataMember]
        public PieDto PieHallazgo { get; set; }
        [DataMember]
        public EmpleadoDto SupervisorCalidad { get; set; }
    }
}
