using ControlCalidad.Cliente.AccesoExterno.ControlCalidadServiceReference;
using ControlCalidad.Cliente.Presentacion.Web.Extenciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControlCalidad.Cliente.Presentacion.Web.Models.Modelo
{
    public class GestionABMViewModel
    {
        public ModeloDto Modelo { get; set; }
        public List<ColorDto> Colores { get; set; }
        public string TipoGestion { get; set; }

        [Required]
        [Display(Name = "Denominacion")]
        public string TxtDenominacion { get; set; }
        [Required]
        [Display(Name = "Objetivo")]
        public string TxtObjetivo { get; set; }

        public GestionABMViewModel()
        {
            Modelo = new ModeloDto();
            Colores = new List<ColorDto>();
        }
    }
}