using ControlCalidad.Servidor.Datos;
using ControlCalidad.Servidor.Datos.Repositorios;
using ControlCalidad.Servidor.Dominio;
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
        #region LINEA

        public LineaDto[] ObtenerLineas()
        {
            var lineasDom = LineaRepositorio.ObtenerLineas();
            var lineasDto = new List<LineaDto>();

            foreach (var item in lineasDom)
            {
                var lineaDto = Linea_DeDomADto(item);
                lineasDto.Add(lineaDto);
            }
            return lineasDto.ToArray();
        }

        public LineaDto[] ObtenerLineasSinEmpleado()
        {
            var lineasDom = LineaRepositorio.ObtenerLineasSinEmpleado();
            var lineasDto = new List<LineaDto>();
            foreach (var item in lineasDom)
            {
                var lineaDto = Linea_DeDomADto(item);
                lineasDto.Add(lineaDto);
            }
            return lineasDto.ToArray();


        }

        public LineaDto ObtenerLineaPorId(int numero)
        {
            var lineaDom = LineaRepositorio.ObtenerLineaPorId(numero);
            var lineaDto = Linea_DeDomADto(lineaDom);

            return lineaDto;
        }

        #endregion

        #region COLOR

        public ColorDto[] ObtenerColores()
        {
            var listaDom = ColorRepositorio.ObtenerTodosLosColores();
            var listaDto = new List<ColorDto>();

            foreach (var item in listaDom)
            {
                var colorDto = Color_DeDomADto(item);
                listaDto.Add(colorDto);
            }
            return listaDto.ToArray();

        }

        public ColorDto ObtenerColorPorId(int id)
        {
            var color = ColorRepositorio.ObtenerColorPorId(id);
            return Color_DeDomADto(color);
        }

        public bool AgregarColor(ColorDto colorDto)
        {
            var colorDom = new Color();
            colorDom.Codigo = colorDto.Codigo;
            colorDom.Descripcion = colorDto.Descripcion;

            ColorRepositorio.AgregarColor(colorDom);

            return true;
        }

        public bool ModificarColor(ColorDto colorDto)
        {
            var colorDom = new Color();
            colorDom.Codigo = colorDto.Codigo;
            colorDom.Descripcion = colorDto.Descripcion;

            ColorRepositorio.ModificarColor(colorDom);

            return true;
        }

        public bool EliminarColor(ColorDto _color)
        {
            try
            {
                var color = ColorRepositorio.ObtenerColorPorId(_color.Codigo);
                ColorRepositorio.EliminarColor(color);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int ObtenerUltimoIdColor()
        {
            return ColorRepositorio.ObtenerUltimoId();
        }


        #endregion

        #region MODELO

        public ModeloDto[] ObtenerTodosLosModelos()
        {
            var listaDom = ModeloRepositorio.ObtenerTodosLosModelos();

            var listaDto = new List<ModeloDto>();

            foreach (var item in listaDom)
            {
                var modeloDto = Modelo_DeDomADto(item);
                listaDto.Add(modeloDto);
            }

            return listaDto.ToArray();
        }

        public ModeloDto ObtenerModeloPorSku(int sku)
        {
            var _modeloDom = ModeloRepositorio.ObtenerModeloPorSku(sku);
            var modeloDto = Modelo_DeDomADto(_modeloDom);
            return (modeloDto);
        }

        public int ObtenerUltimoSku()
        {
            return ModeloRepositorio.ObtenerUltimoSku();
        }

        public bool GuardarModelo(ModeloDto _modeloDto)
        {
            try
            {
                var modeloDom = new Modelo()
                {
                    Sku = _modeloDto.Sku,
                    Denominacion = _modeloDto.Denominacion,
                    Objetivo = _modeloDto.Objetivo
                };

                ModeloRepositorio.AgregarModelo(modeloDom);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ModificarModelo(ModeloDto _modelo)
        {
            try
            {
                var modelo = ModeloRepositorio.ObtenerModeloPorSku(_modelo.Sku);

                modelo.Denominacion = _modelo.Denominacion;
                modelo.Objetivo = _modelo.Objetivo;

                ModeloRepositorio.ModificarModelo(modelo);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EliminarModelo(ModeloDto _modelo)
        {
            try
            {
                var modelo = ModeloRepositorio.ObtenerModeloPorSku(_modelo.Sku);
                ModeloRepositorio.EliminarModelo(modelo);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region USUARIO

        public UsuarioDto ComprobarLogueo(string nombre, string contraseña)
        {
            var usuarioDom = UsuarioRepositorio.ComprobarLogueo(nombre, contraseña);
            var usuarioDto = Usuario_DeDomADto(usuarioDom);

            return (usuarioDto);
        }

        public UsuarioDto ObtenerUsuarioPorId(int id)
        {
            var usuarioDom = UsuarioRepositorio.ObtenerUsuarioPorId(id);

            var usuarioDto = Usuario_DeDomADto(usuarioDom);

            return (usuarioDto);
        }

        #endregion

        #region ORDEN_PRODUCCION

        public OrdenProduccionDto[] ObtenerTodasLasOrdenProduccion()
        {
            var listaDom = OrdenProduccionRepositorio.ObtenerTodasLasOrdenProduccion();

            var listaDto = new List<OrdenProduccionDto>();

            foreach (var item in listaDom)
            {
                var ordenProduccionDto = OrdenProduccion_DeDomADto(item);
                listaDto.Add(ordenProduccionDto);
            }

            return listaDto.ToArray();
        }

        public OrdenProduccionDto ObtenerOpPorId(int id)
        {
            var opDom = OrdenProduccionRepositorio.ObtenerOrderProduccionPorId(id);
            var opDto = OrdenProduccion_DeDomADto(opDom);
            return (opDto);
        }

        public bool AgregarOrdenProduccion(OrdenProduccionDto ordenProduccionDto, EmpleadoDto empleadoDto)
        {
            var ordenProduccionDom = new OrdenProduccion();

            ordenProduccionDom.Numero = ordenProduccionDto.Numero;
            

            switch (ordenProduccionDto.EstadoDeOP)
            {
                case EstadoOPDto.Iniciado:
                    ordenProduccionDom.EstadoDeOP = EstadoOP.Iniciado;
                    break;
                case EstadoOPDto.Pausado:
                    ordenProduccionDom.EstadoDeOP = EstadoOP.Pausado;
                    break;
                case EstadoOPDto.Continuado:
                    break;
                case EstadoOPDto.Finalizado:
                    break;
                default:
                    break;
            }

            ordenProduccionDom.ModeloOP = ModeloRepositorio.ObtenerModeloPorSku(ordenProduccionDto.ModeloOP.Sku);
            ordenProduccionDom.ColorCalzado = ColorRepositorio.ObtenerColorPorId(ordenProduccionDto.ColorCalzado.Codigo);
            ordenProduccionDom.LineaTrabajo = LineaRepositorio.ObtenerLineaPorId(ordenProduccionDto.LineaTrabajo.Numero);

            ordenProduccionDom.LineaTrabajo.SupervisorLinea = EmpleadoRepositorio.BuscarEmpleadoPorId(empleadoDto.Id);

            LineaRepositorio.ModificarLinea(ordenProduccionDom.LineaTrabajo);

            OrdenProduccionRepositorio.AgregarOrdenproduccion(ordenProduccionDom);

            var ordenes = OrdenProduccionRepositorio.ObtenerTodasLasOrdenProduccion();

            return true;
        }

        public bool ModificarOrdenProduccion_Estado(OrdenProduccionDto ordenProduccionDto, EstadoOPDto nuevoEstadoOPDto)
        {
            var ordenProduccionDom = OrdenProduccionRepositorio.ObtenerOrderProduccionPorId(ordenProduccionDto.Numero);

            switch (nuevoEstadoOPDto)
            {
                case EstadoOPDto.Iniciado:
                    ordenProduccionDom.EstadoDeOP = EstadoOP.Iniciado;
                    break;
                case EstadoOPDto.Pausado:
                    ordenProduccionDom.EstadoDeOP = EstadoOP.Pausado;
                    break;
                case EstadoOPDto.Continuado:
                    ordenProduccionDom.EstadoDeOP = EstadoOP.Continuado;
                    break;
                case EstadoOPDto.Finalizado:

                    var lineaAModif = new Linea()
                    {
                        Numero = ordenProduccionDom.LineaTrabajo.Numero,
                        Descripcion = ordenProduccionDom.LineaTrabajo.Descripcion,
                        SupervisorLinea = null
                    };
                    
                    LineaRepositorio.ModificarLinea(lineaAModif);

                    ordenProduccionDom.EstadoDeOP = EstadoOP.Finalizado;

                    break;
                default:
                    break;
            }
            OrdenProduccionRepositorio.ModificarOrdenProduccion(ordenProduccionDom);

            return true;
        }

        public bool ModificarOrdenProduccion_Trabajar(OrdenProduccionDto ordenProduccionDto, EmpleadoDto empleadoDto)
        {
            var ordenProduccionDom = OrdenProduccionRepositorio.ObtenerOrderProduccionPorId(ordenProduccionDto.Numero);
            var empleadoDom = EmpleadoRepositorio.BuscarEmpleadoPorId(empleadoDto.Id);
            ordenProduccionDom.SupervisorCalidad = empleadoDom;
            OrdenProduccionRepositorio.ModificarOrdenProduccion(ordenProduccionDom);

            var lista = OrdenProduccionRepositorio.ObtenerTodasLasOrdenProduccion();

            return true;
        }

        public bool ModificarOrdenProduccion_Abandonar(OrdenProduccionDto ordenProduccionDto)
        {
            var ordenProduccionDom = OrdenProduccionRepositorio.ObtenerOrderProduccionPorId(ordenProduccionDto.Numero);
            if (ordenProduccionDom.EstadoDeOP == EstadoOP.Pausado)
            {
                ordenProduccionDom.SupervisorCalidad = null;
                OrdenProduccionRepositorio.ModificarOrdenProduccion(ordenProduccionDom);
                return true;
            }
            return false;
            
        }

        public int ObtenerUltimoIdOP() 
        {
            return OrdenProduccionRepositorio.ObtenerUltimoId();
        }

        public OrdenProduccionDto ObtenerOpAsignadoAUnEmpleado(EmpleadoDto empleadoDto)
        {
            var listaDom = OrdenProduccionRepositorio.ObtenerTodasLasOrdenProduccion();

            foreach (var item in listaDom)
            {
                if (item.SupervisorCalidad != null && item.SupervisorCalidad.Id == empleadoDto.Id && item.EstadoDeOP != EstadoOP.Pausado && item.EstadoDeOP != EstadoOP.Finalizado)
                {
                    var ordenProduccionDto = OrdenProduccion_DeDomADto(item);
                    return ordenProduccionDto;
                }
            }

            return null;
        }

        #endregion

        #region ESTADO_OP

        public EstadoOPDto[] ObtenerNuevosEstadosOp(EstadoOPDto estadoOp)
        {
            switch (estadoOp)
            {
                case EstadoOPDto.Iniciado:
                    return new EstadoOPDto[]{ EstadoOPDto.Pausado, EstadoOPDto.Finalizado};
                case EstadoOPDto.Pausado:
                    return new EstadoOPDto[] { EstadoOPDto.Continuado, EstadoOPDto.Finalizado };
                case EstadoOPDto.Continuado:
                    return new EstadoOPDto[] { EstadoOPDto.Pausado, EstadoOPDto.Finalizado };
                case EstadoOPDto.Finalizado:
                    return new EstadoOPDto[] { };
                default:
                    return new EstadoOPDto[] { };
            }
        }

        #endregion

        #region DEFECTO

        #endregion

        #region TURNO

        #endregion

        #region HORARIO

        #endregion

        #region De_Domino_A_Dto

        private EmpleadoDto Empleado_DeDomADto(Empleado empleadoDom)
        {
            if (empleadoDom == null)
                return null;

            var empleadoDto = new EmpleadoDto();
            empleadoDto.Id = empleadoDom.Id;
            empleadoDto.Documento = empleadoDom.Documento;
            empleadoDto.Nombre = empleadoDom.Nombre;
            empleadoDto.Apellido = empleadoDom.Apellido;
            empleadoDto.CorreoElectronico = empleadoDom.CorreoElectronico;
            empleadoDto.Usuario = Usuario_DeDomADto(empleadoDom.UsuarioEmpleado);
            
            return (empleadoDto);
        }

        private UsuarioDto Usuario_DeDomADto(Usuario usuarioDom)
        {
            if (usuarioDom == null)
                return null;

            var usuarioDto = new UsuarioDto();
            usuarioDto.Id = usuarioDom.Id;
            usuarioDto.Nombre = usuarioDom.Nombre;
            usuarioDto.Contraseña = usuarioDom.Contraseña;
            if (usuarioDom.UsuarioDeEmpleado != null)
            {
                usuarioDto.UsuarioDeEmpleado = Empleado_DeDomADto(usuarioDom.UsuarioDeEmpleado);
            }
            else
                usuarioDto.UsuarioDeEmpleado = null;

            switch (usuarioDom.TipoDeUsuario)
            {
                case TipoUsuario.Administrador:
                    usuarioDto.TipoDeUsuario = TipoUsuarioDto.Administrador;
                    break;
                case TipoUsuario.SupervisorLinea:
                    usuarioDto.TipoDeUsuario = TipoUsuarioDto.SupervisorLinea;
                    break;
                case TipoUsuario.SupervisorCalidad:
                    usuarioDto.TipoDeUsuario = TipoUsuarioDto.SupervisorCalidad;
                    break;
                default:
                    usuarioDto.TipoDeUsuario = TipoUsuarioDto.Administrador;
                    break;
            }

            return (usuarioDto);
        }

        private ModeloDto Modelo_DeDomADto(Modelo modeloDom)
        {
            if (modeloDom == null)
                return null;

            var modeloDto = new ModeloDto();
            modeloDto.Sku = modeloDom.Sku;
            modeloDto.Denominacion = modeloDom.Denominacion;
            modeloDto.Objetivo = modeloDom.Objetivo;

            return (modeloDto);
        }

        private ColorDto Color_DeDomADto(Color colorDom)
        {
            if (colorDom == null)
                return null;

            var colorDto = new ColorDto();
            colorDto.Codigo = colorDom.Codigo;
            colorDto.Descripcion = colorDom.Descripcion;
            return (colorDto);
        }

        private LineaDto Linea_DeDomADto(Linea lineaDom)
        {
            if (lineaDom == null)
                return null;

            var lineaDto = new LineaDto();
            lineaDto.Numero = lineaDom.Numero;
            lineaDto.Descripcion = lineaDom.Descripcion;
            lineaDto.SupervisorLinea = Empleado_DeDomADto(lineaDom.SupervisorLinea);

            return (lineaDto);
        }

        private OrdenProduccionDto OrdenProduccion_DeDomADto(OrdenProduccion opDom)
        {
            if (opDom == null)
                return null;

            var opDto = new OrdenProduccionDto();
            opDto.Numero = opDom.Numero;
            opDto.ParesPrimeraParHermanado = opDom.ParesPrimeraParHermanado;
            opDto.ParesSegundaPorHermanado = opDom.ParesSegundaPorHermanado;
            switch (opDom.EstadoDeOP)
            {
                case EstadoOP.Iniciado:
                    opDto.EstadoDeOP = EstadoOPDto.Iniciado;
                    break;
                case EstadoOP.Pausado:
                    opDto.EstadoDeOP = EstadoOPDto.Pausado;
                    break;
                case EstadoOP.Continuado:
                    opDto.EstadoDeOP = EstadoOPDto.Continuado;
                    break;
                case EstadoOP.Finalizado:
                    opDto.EstadoDeOP = EstadoOPDto.Finalizado;
                    break;
                default:
                    opDto.EstadoDeOP = EstadoOPDto.Iniciado;
                    break;
            }
            opDto.ModeloOP = Modelo_DeDomADto(opDom.ModeloOP);
            opDto.ColorCalzado = Color_DeDomADto(opDom.ColorCalzado);
            opDto.LineaTrabajo = Linea_DeDomADto(opDom.LineaTrabajo);
            opDto.ListaDeHorario = null; // falta implementar!
            opDto.SupervisorCalidad = Empleado_DeDomADto(opDom.SupervisorCalidad);

            return (opDto);
        }
    }
    
    #endregion
}
