using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ControlCalidad.Cliente.AccesoExterno.ControlCalidadServiceReference;
using System.ComponentModel.DataAnnotations;

namespace ControlCalidad.Cliente.Presentacion.Web.Models
{
    public class HomeViewModel
    {
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Nick")]
        public string Nick { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "ErrorLogin")]
        public string ErrorLogin { get; set; }

        public LoginViewModel()
        {
            ErrorLogin = "";
        }
    }
}