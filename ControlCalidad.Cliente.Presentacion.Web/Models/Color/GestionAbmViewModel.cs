using ControlCalidad.Cliente.AccesoExterno.ControlCalidadServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControlCalidad.Cliente.Presentacion.Web.Models.Color
{
    public class GestionAbmViewModel
    {
        public ColorDto Color { get; set; }
        public string TipoGestion { get; set; }

        [Required]
        [Display(Name = "Descripcion")]
        public string ValDescripcion { get; set; }
    }
}