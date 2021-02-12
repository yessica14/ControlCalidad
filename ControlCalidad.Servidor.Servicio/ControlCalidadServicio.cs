using ControlCalidad.Servidor.Datos;
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
        public LineaDto[] GetLineas()
        {
            return Repositorio
                .GetLineas().Select(l => new LineaDto
                { 
                  Numero = l.Numero,
                  Descripcion = l.Descripcion
                })
                .ToArray();
        }
    }

}
