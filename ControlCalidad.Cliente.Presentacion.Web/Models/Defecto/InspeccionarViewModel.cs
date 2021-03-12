using ControlCalidad.Cliente.AccesoExterno.ControlCalidadServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlCalidad.Cliente.Presentacion.Web.Models.Defecto
{
    public class InspeccionarViewModel
    {
        public OrdenProduccionDto OpDto { get; set; }
        public List<TurnoDto> ListaTurnos { get; set; }
        public List<DefectoDto> ListaDefectosObservados { get; set; }
        public List<DefectoDto> ListaDefectosReproceso { get; set; }
        public List<TimeSpan> listaHora { get; set; }
        public DateTime Fecha { get; set; }
    }
}