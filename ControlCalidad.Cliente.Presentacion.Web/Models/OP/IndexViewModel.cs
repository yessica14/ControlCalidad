using ControlCalidad.Cliente.AccesoExterno.ControlCalidadServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlCalidad.Cliente.Presentacion.Web.Models.OP
{
    public class IndexViewModel
    {
        public bool BotonNuevaOp { get; set; }
        public bool BotonTrabarEnOp { get; set; }
        public bool BotonModificarOp { get; set; }
        public bool BotonAbandonarOp { get; set; }
        public string MensajeError { get; set; }

        public List<OrdenProduccionDto> OrdenProduccionDto { get; set; }
    }
}