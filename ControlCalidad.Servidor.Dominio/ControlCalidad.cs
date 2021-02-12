using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Servidor.Dominio
{
    public class ControlCalidad
    {
        public string Cuit { get; set; }
        public string RazonSocial { get; set; }
        public int Telefono { get; set; }

        public List<Empleado> ListaDeEmpleados = new List<Empleado>();
        public List<Usuario> ListaDeUsuarios = new List<Usuario>();

        /*genericos*/
        public List<Color> ListaDeColores = new List<Color>();
        public List<Modelo> ListaDeModelos = new List<Modelo>();
        public List<Linea> ListaDeLineasDeTrabajo = new List<Linea>();
        public List<OrdenProduccion> ListaDeOrdenesDeProduccion = new List<OrdenProduccion>();
        public List<Defecto> ListaDeDefectos = new List<Defecto>();
        public List<Turno> ListaDeTurnos = new List<Turno>();



    }
}
