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

        public static LineaDto ObtenerLineaPorId(int numero)
        {
            using (var servidor = new ControlCalidadServiceReference.ControlCalidadServicioClient())
            {
                return servidor.ObtenerLineaPorId(numero);
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
        public static bool AgregarColor(ColorDto color)
        {
            using (var servidor = new ControlCalidadServiceReference.ControlCalidadServicioClient())
            {
                return servidor.AgregarColor(color);
            }
        }

        public static bool ModificarColor(ColorDto color)
        {
            using (var servidor = new ControlCalidadServiceReference.ControlCalidadServicioClient())
            {
                return servidor.ModificarColor(color);
            }
        }

        public static bool EliminarColor(ColorDto color)
        {
            using (var servidor = new ControlCalidadServiceReference.ControlCalidadServicioClient())
            {
                return servidor.EliminarColor(color);
            }
        }

        public static int ObtenerUltimoIdColor()
        {
            using (var servidor = new ControlCalidadServiceReference.ControlCalidadServicioClient())
            {
                return servidor.ObtenerUltimoIdColor();
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

        #region USUARIO

        public static UsuarioDto ComprobarLogueo(string nombre, string contraseña)
        {
            using (var servidor = new ControlCalidadServiceReference.ControlCalidadServicioClient())
            {
                return servidor.ComprobarLogueo(nombre, contraseña);
            }
        }

        public static UsuarioDto ObtenerUsuarioPorId(int id)
        {
            using (var servidor = new ControlCalidadServiceReference.ControlCalidadServicioClient())
            {
                return servidor.ObtenerUsuarioPorId(id);
            }
        }

        #endregion

        #region ORDENPRODUCCION

        public static OrdenProduccionDto[] ObtenerTodasLasOrdenProduccion()
        {
            using (var servidor = new ControlCalidadServiceReference.ControlCalidadServicioClient())
            {
                return servidor.ObtenerTodasLasOrdenProduccion();
            }
        }

        public static OrdenProduccionDto ObtenerOpPorId(int id)
        {
            using (var servidor = new ControlCalidadServiceReference.ControlCalidadServicioClient())
            {
                return servidor.ObtenerOpPorId(id);
            }
        }

        public static bool AgregarOrdenProduccion(OrdenProduccionDto ordenProduccionDto, EmpleadoDto empleado)
        {
            using (var servidor = new ControlCalidadServiceReference.ControlCalidadServicioClient())
            {
                return servidor.AgregarOrdenProduccion(ordenProduccionDto, empleado);
            }
        }

        public static bool ModificarOrdenProduccion_Estado(OrdenProduccionDto ordenProduccionDto, EstadoOPDto estadoDto)
        {
            using (var servidor = new ControlCalidadServiceReference.ControlCalidadServicioClient())
            {
                return servidor.ModificarOrdenProduccion_Estado(ordenProduccionDto, estadoDto);
            }
        }

        public static bool ModificarOrdenProduccion_Trabajar(OrdenProduccionDto ordenProduccionDto, EmpleadoDto empleadoDto)
        {
            using (var servidor = new ControlCalidadServiceReference.ControlCalidadServicioClient())
            {
                return servidor.ModificarOrdenProduccion_Trabajar(ordenProduccionDto, empleadoDto);
            }
        }

        public static bool ModificarOrdenProduccion_Abandonar(OrdenProduccionDto ordenProduccionDto)
        {
            using (var servidor = new ControlCalidadServiceReference.ControlCalidadServicioClient())
            {
                return servidor.ModificarOrdenProduccion_Abandonar(ordenProduccionDto);
            }
        }

        public static int ObtenerUltimoIdOP()
        {
            using (var servidor = new ControlCalidadServiceReference.ControlCalidadServicioClient())
            {
                return servidor.ObtenerUltimoIdOP();
            }
        }

        public static OrdenProduccionDto ObtenerOpAsignadoAUnEmpleado(EmpleadoDto empleadoDto)
        {
            using (var servidor = new ControlCalidadServiceReference.ControlCalidadServicioClient())
            {
                return servidor.ObtenerOpAsignadoAUnEmpleado(empleadoDto);
            }
        }

        #endregion

        #region ESTADO_OP

        public static EstadoOPDto[] ObtenerNuevosEstadosOp(EstadoOPDto estadoActual)
        {
            using (var servidor = new ControlCalidadServiceReference.ControlCalidadServicioClient())
            {
                return servidor.ObtenerNuevosEstadosOp(estadoActual);
            }
        }

        #endregion

        #region HALLAZGO

        public static bool EliminarHallazgo(int idOp, int idHorario, int idHallazgo)
        {
            using (var servidor = new ControlCalidadServiceReference.ControlCalidadServicioClient())
            {
                return servidor.EliminarHallazgo(idOp, idHorario, idHallazgo);
            }
        }

        public static bool RealizarHermanado(int idOp, int idSupervisorCalidad)
        {
            using (var servidor = new ControlCalidadServiceReference.ControlCalidadServicioClient())
            {
                return servidor.RealizarHermanado(idOp, idSupervisorCalidad);
            }
        }

        #endregion

        #region TipoDefecto

        public static DefectoDto[] ObtenerListaDefectos(string tipo)
        {
            using (var servidor = new ControlCalidadServiceReference.ControlCalidadServicioClient())
            {
                return servidor.ObtenerListaDefectos(tipo);
            }

        }
        #endregion
    }
}
