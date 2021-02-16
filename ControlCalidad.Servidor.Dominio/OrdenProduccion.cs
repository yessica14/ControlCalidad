using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Servidor.Dominio
{
    public class OrdenProduccion
    {
        public int Numero { get; set; }
        public int ParesPrimeraParHermanado { get; set; }
        public int ParesSegundaPorHermanado { get; set; }

        public EstadoOP EstadoDeOP { get; set; }
        public Modelo ModeloOP { get; set; }
        public Color ColorCalzado { get; set; }
        public Linea LineaTrabajo { get; set; }
        public List<Horario> ListaDeHorario { get; set; }
        public Empleado SupervisorCalidad { get; set; }
      
    }
}
