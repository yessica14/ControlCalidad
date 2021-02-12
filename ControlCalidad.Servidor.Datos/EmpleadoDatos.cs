using System;
using ControlCalidad.Servidor.Dominio;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Servidor.Datos
{
    public class EmpleadoDatos
    {
        public static IEnumerable<Empleado> GetEmpleados()
        {
            return new List<Empleado>()
            {
                new Empleado
                {
                    Documento=326878,
                    Nombre="yessica",
                    Apellido="gimenez",
                    CorreoElectronico="yessica@gmail.com"

                },
                 new Empleado
                {
                    Documento=326878,
                    Nombre="juan",
                    Apellido="arce",
                    CorreoElectronico="juan@gmail.com"

                },
                  new Empleado
                {
                    Documento=326878,
                    Nombre="david",
                    Apellido="gimenez",
                    CorreoElectronico="david@gmail.com"

                }
            };

        }
    }
}
