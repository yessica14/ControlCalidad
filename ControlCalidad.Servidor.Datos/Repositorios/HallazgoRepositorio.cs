using ControlCalidad.Servidor.Datos.Persistencia;
using ControlCalidad.Servidor.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Servidor.Datos.Repositorios
{
    public class HallazgoRepositorio
    {
        public void CargarHallazgo()
        {
            var empresa = Singleton.getInstancia().ObtenerDatosDeEmpresa();
            
        }

        public static void AgregarHallazgo(int NumeroOp, Hallazgo hallazgo)
        {
            var empresa = Singleton.getInstancia().ObtenerDatosDeEmpresa();
           
            Singleton.getInstancia().AsignarDatosAEmpresa(empresa);

        }

        public static void ModificarHallazgo(OrdenProduccion op, Hallazgo hallazgo)
        {
        }

        public static void EliminarHallazgo(int idOp, int idHorario, int idHallazgo)
        {
            var opDom = OrdenProduccionRepositorio.ObtenerOrderProduccionPorId(idOp);
            opDom.ListaDeHorario.ForEach(hor =>
            {
                if (hor.Id == idHorario)
                    hor.ListaDeHallazgos.RemoveAll(hal => hal.Id == idHallazgo);
            });

            OrdenProduccionRepositorio.ModificarOrdenProduccion(opDom);
        }

    }
}
