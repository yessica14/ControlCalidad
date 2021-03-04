using ControlCalidad.Servidor.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Servidor.Datos.Repositorios
{
    public class PrimeraRepositorio
    {
        public static void RealizarHermanado(int idOp, Empleado superivisorCalidad)
        {
            var op = OrdenProduccionRepositorio.ObtenerOrderProduccionPorId(idOp);

            foreach (var horario in op.ListaDeHorario)
            {
                int cantIzqBueno = 0;
                int cantDerBueno = 0;
                int cantParHorario = 0;

                foreach (var hallazgo in horario.ListaDeHallazgos)
                {
                    if (hallazgo.DefectoHallazgo == null && hallazgo.PieHallazgo == Pie.Izquierdo)
                    {
                        cantIzqBueno = cantIzqBueno + 1;
                    }
                    if (hallazgo.DefectoHallazgo == null && hallazgo.PieHallazgo == Pie.Derecho)
                    {
                        cantDerBueno = cantDerBueno + 1;
                    }
                }

                if (cantIzqBueno < cantDerBueno)
                {
                    cantParHorario = cantIzqBueno;
                }
                else
                {
                    cantParHorario = cantDerBueno;
                }

            }

        }
    }
}
