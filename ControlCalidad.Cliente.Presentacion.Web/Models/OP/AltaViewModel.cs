using ControlCalidad.Cliente.AccesoExterno.ControlCalidadServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlCalidad.Cliente.Presentacion.Web.Models.OP
{
    public class AltaViewModel
    {
        public List<ModeloDto> ModelosDtos { get; set; }
        public List<LineaDto> LineasDtos { get; set; }
        public OrdenProduccionDto OrdenProduccion { get; set; }

    }
}