using ControlCalidad.Servidor.Datos;
using ControlCalidad.Servidor.Datos.Repositorios;
using ControlCalidad.Servidor.Servicio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ControlCalidad.Servidor.Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    public class ControlCalidadServicio : IControlCalidadServicio
    {
        public LineaDto[] ObtenerLineas()
        {
            return LineaRepositorio
                .ObtenerLineas().Select(l => new LineaDto
                {
                    Numero = l.Numero,
                    Descripcion = l.Descripcion,
                    SupervisorLinea = l.SupervisorLinea
                })
                .ToArray();
        }

        public LineaDto[] ObtenerLineasSinEmpleado()
        {
            return LineaRepositorio
                .ObtenerLineasSinEmpleado().Select(l => new LineaDto
                {
                    Numero = l.Numero,
                    Descripcion = l.Descripcion
                    /*,
                    SupervisorLinea = l.SupervisorLinea != null ? new EmpleadoDto
                    {
                        Id = l.SupervisorLinea.Id,
                        Documento = l.SupervisorLinea.Documento,
                        Nombre = l.SupervisorLinea.Nombre,
                        Apellido = l.SupervisorLinea.Apellido,
                        CorreoElectronico = l.SupervisorLinea.CorreoElectronico
                    } : null
                    */
                })
                .ToArray();
        }

    }

}
