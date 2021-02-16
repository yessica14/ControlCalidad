using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ControlCalidad.Servidor.Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IControlCalidadServicio
    {
        [OperationContract]
        LineaDto[] ObtenerLineas();

        [OperationContract]
        LineaDto[] ObtenerLineasSinEmpleado();

        //[OperationContract]
        //bool CrearOP(OpDto op);


    }
}
