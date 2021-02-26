using ControlCalidad.Servidor.Datos.Persistencia;
using ControlCalidad.Servidor.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Servidor.Datos.Repositorios
{
    class TurnoRepositorio
    {
        public void CargarTurnos()
        {
            var empresa = Singleton.getInstancia().ObtenerDatosDeEmpresa();

            empresa.ListaDeTurnos.Add
            (
                new Turno()
                {
                    Codigo = 100,
                    nombre = "Mañana",
                    HoraInicio = new TimeSpan(6, 0, 0),
                    HoraFin = new TimeSpan(12, 59, 59)
                }
            );
            empresa.ListaDeTurnos.Add
           (
               new Turno()
               {
                   Codigo = 101,
                   nombre = "Tarde",
                   HoraInicio = new TimeSpan(13, 0, 0),
                   HoraFin = new TimeSpan(18, 59, 59)
               }
           );
            empresa.ListaDeTurnos.Add
           (
               new Turno()
               {
                   Codigo = 102,
                   nombre = "Noche",
                   HoraInicio = new TimeSpan(19, 0, 0),
                   HoraFin = new TimeSpan(23, 59, 59)
               }
           );

        }

        public static Turno ObtenerTurnoPorCodigo(int codigo)
        {
            var empresa = Singleton.getInstancia().ObtenerDatosDeEmpresa();
            return empresa.ListaDeTurnos.Where(x => x.Codigo == codigo).FirstOrDefault();
        }
    }
}
