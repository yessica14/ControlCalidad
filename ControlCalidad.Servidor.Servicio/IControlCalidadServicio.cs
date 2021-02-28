using ControlCalidad.Servidor.Servicio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ControlCalidad.Servidor.Servicio
{
    [ServiceContract]
    public interface IControlCalidadServicio
    {
        #region LINEA

        [OperationContract]
        LineaDto[] ObtenerLineas();

        [OperationContract]
        LineaDto[] ObtenerLineasSinEmpleado();

        [OperationContract]
        LineaDto ObtenerLineaPorId(int numero);

        #endregion

        #region COLOR

        [OperationContract]
        ColorDto[] ObtenerColores();
        
        [OperationContract]
        ColorDto ObtenerColorPorId(int id);

        [OperationContract]
        bool AgregarColor(ColorDto color);

        [OperationContract]
        bool ModificarColor(ColorDto color);

        [OperationContract]
        bool EliminarColor(ColorDto color);

        [OperationContract]
        int ObtenerUltimoIdColor();


        #endregion

        #region MODELO

        [OperationContract]
        ModeloDto[] ObtenerTodosLosModelos();

        [OperationContract]
        ModeloDto ObtenerModeloPorSku(int sku);

        [OperationContract]
        int ObtenerUltimoSku();

        [OperationContract]
        bool GuardarModelo(ModeloDto modelo);

        [OperationContract]
        bool ModificarModelo(ModeloDto modelo);

        [OperationContract]
        bool EliminarModelo(ModeloDto modelo);


        #endregion

        #region USUARIO

        [OperationContract]
        UsuarioDto ComprobarLogueo(string nombre, string contraseña);

        [OperationContract]
        UsuarioDto ObtenerUsuarioPorId(int id);

        #endregion

        #region ORDENPRODUCCION

        [OperationContract]
        OrdenProduccionDto[] ObtenerTodasLasOrdenProduccion();

        [OperationContract]
        OrdenProduccionDto ObtenerOpPorId(int id);

        [OperationContract]
        bool AgregarOrdenProduccion(OrdenProduccionDto ordenProduccion, EmpleadoDto empleado);

        [OperationContract]
        bool ModificarOrdenProduccion_Estado(OrdenProduccionDto ordenProduccion, EstadoOPDto nuevoEstadoOPDto);

        [OperationContract]
        bool ModificarOrdenProduccion_Trabajar(OrdenProduccionDto ordenProduccion, EmpleadoDto empleadoDto);

        [OperationContract]
        bool ModificarOrdenProduccion_Abandonar(OrdenProduccionDto ordenProduccion);

        [OperationContract]
        int ObtenerUltimoIdOP();

        [OperationContract]
        OrdenProduccionDto ObtenerOpAsignadoAUnEmpleado(EmpleadoDto empleadoDto);

        #endregion

        #region ESTADO_OP

        [OperationContract]
        EstadoOPDto[] ObtenerNuevosEstadosOp(EstadoOPDto estadoOp);

        #endregion

        #region HALLAZGO

        [OperationContract]
        bool EliminarHallazgo(int idOp, int idHorario, int idHallazgo);

        #endregion

        #region TIPODEFECTO

        [OperationContract]
        DefectoDto[] ObtenerListaDefectos(string tipo);

        #endregion
    }



}
