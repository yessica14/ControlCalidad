using ControlCalidad.Cliente.AccesoExterno.ControlCalidadServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Cliente.AccesoExterno
{
    public class Adaptador
    {
        #region LINEA
        public static LineaDto[] GetLineas()
        { 
            using(var servidor = new ControlCalidadServiceReference.ControlCalidadServicioClient())
            {
                return servidor.ObtenerLineas();
            }
        }

        public static LineaDto[] ObtenerLineasSinEmpleado()
        {
            using (var servidor = new ControlCalidadServiceReference.ControlCalidadServicioClient())
            {
                return servidor.ObtenerLineasSinEmpleado();
            }
        }

        #endregion

        #region COLOR

        public static ColorDto[] ObtenerColores()
        {
            using (var servidor = new ControlCalidadServiceReference.ControlCalidadServicioClient())
            {
                return servidor.ObtenerColores();
            }
        }

        public static ColorDto ObtenerColorPorId(int id)
        {
            using (var servidor = new ControlCalidadServiceReference.ControlCalidadServicioClient())
            {
                return servidor.ObtenerColorPorId(id);
            }
        }

        #endregion

        #region MODELO

        public static ModeloDto[] ObtenerModelos()
        {
            using (var servidor = new ControlCalidadServiceReference.ControlCalidadServicioClient())
            {
                return servidor.ObtenerTodosLosModelos();
            }
        }

        public static ModeloDto ObtenerModeloPorSku(int sku)
        {
            using (var servidor = new ControlCalidadServiceReference.ControlCalidadServicioClient())
            {
                return servidor.ObtenerModeloPorSku(sku);
            }
        }

        public static int ObtenerUltimoSku()
        {
            using (var servidor = new ControlCalidadServiceReference.ControlCalidadServicioClient())
            {
                return servidor.ObtenerUltimoSku();
            }
        }

        public static bool GuardarModelo(ModeloDto modelo)
        {
            using (var servidor = new ControlCalidadServiceReference.ControlCalidadServicioClient())
            {
                return servidor.GuardarModelo(modelo);
            }
        }

        public static bool ModificarModelo(ModeloDto modelo)
        {
            using (var servidor = new ControlCalidadServiceReference.ControlCalidadServicioClient())
            {
                return servidor.ModificarModelo(modelo);
            }
        }

        public static bool EliminarModelo(ModeloDto modelo)
        {
            using (var servidor = new ControlCalidadServiceReference.ControlCalidadServicioClient())
            {
                return servidor.EliminarModelo(modelo);
            }
        }

        #endregion
    }
}
