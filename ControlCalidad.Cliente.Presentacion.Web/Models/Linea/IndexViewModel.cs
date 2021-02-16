using ControlCalidad.Cliente.AccesoExterno.ControlCalidadServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlCalidad.Cliente.Presentacion.Web.Models.Linea
{
    public class IndexViewModel
    {
        public List<LineaDto> Lineas { get; set; }
    }
}