using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Servidor.Servicio.Entidades
{
    [DataContract]
    class ControlDeCalidadDto
    {
        [DataMember]
        public string Cuit { get; set; }
        [DataMember]
        public string RazonSocial { get; set; }
        [DataMember]
        public int Telefono { get; set; }

        [DataMember]
        public List<EmpleadoDto> ListaDeEmpleados = new List<EmpleadoDto>();

        [DataMember]
        public List<UsuarioDto> ListaDeUsuarios = new List<UsuarioDto>();

        /*genericos*/
        [DataMember]
        public List<ColorDto> ListaDeColores = new List<ColorDto>();

        [DataMember]
        public List<ModeloDto> ListaDeModelos = new List<ModeloDto>();

        [DataMember]
        public List<LineaDto> ListaDeLineas = new List<LineaDto>();

        [DataMember]
        public List<OrdenProduccionDto> ListaDeOrdenesDeProduccion = new List<OrdenProduccionDto>();

        [DataMember]
        public List<DefectoDto> ListaDeDefectos = new List<DefectoDto>();

        [DataMember]
        public List<TurnoDto> ListaDeTurnos = new List<TurnoDto>();

        [DataMember]
        public List<HallazgoDto> ListaDeHallazgos = new List<HallazgoDto>();

    }
}
