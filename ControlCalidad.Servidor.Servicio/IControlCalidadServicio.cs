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
    }



}
