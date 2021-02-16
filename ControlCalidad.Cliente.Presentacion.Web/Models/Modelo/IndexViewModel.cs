using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ControlCalidad.Cliente.AccesoExterno.ControlCalidadServiceReference;

namespace ControlCalidad.Cliente.Presentacion.Web.Models.Modelo
{
    public class IndexViewModel
    {
        public List<ModeloDto> Modelos { get; set; }
    }
}