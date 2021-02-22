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
            return LineaRepositorio
                .ObtenerLineas().Select(l => new LineaDto
                {
                    Numero = l.Numero,
                    Descripcion = l.Descripcion,
                    SupervisorLinea = Empleado_DeDomADto(l.SupervisorLinea)
                })
                .ToArray();
        }

        public LineaDto[] ObtenerLineasSinEmpleado()
        {
            return LineaRepositorio
                .ObtenerLineasSinEmpleado().Select(l => new LineaDto
                {
                    Numero = l.Numero,
                    Descripcion = l.Descripcion
                })
                .ToArray();
        }

        #endregion

        #region COLOR

        public ColorDto[] ObtenerColores()
        {
            var listaDom = ColorRepositorio.ObtenerTodosLosColores();
            var listaDto = new List<ColorDto>();

            foreach (var item in listaDom)
            {
                var colorDto = new ColorDto();

                colorDto.Codigo = item.Codigo;
                colorDto.Descripcion = item.Descripcion;

                listaDto.Add(colorDto);
            }

            return listaDto.ToArray();

        }

        public ColorDto ObtenerColorPorId(int id)
        {
            var color = ColorRepositorio.ObtenerColorPorId(id);
            return new ColorDto()
            {
                Codigo = color.Codigo,
                Descripcion = color.Descripcion
            };
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
                var modeloDto = new ModeloDto();

                modeloDto.Sku = item.Sku;
                modeloDto.Denominacion = item.Denominacion;
                modeloDto.Objetivo = item.Objetivo;

                var colorDto = new ColorDto();
                colorDto.Codigo = item.ColorModelo.Codigo;
                colorDto.Descripcion = item.ColorModelo.Descripcion;

                modeloDto.ColorModelo = colorDto;

                listaDto.Add(modeloDto);
            }

            return listaDto.ToArray();

        }

        public ModeloDto ObtenerModeloPorSku(int sku)
        {
            var _modelo = ModeloRepositorio.ObtenerModeloPorSku(sku);

            return new ModeloDto
            {
                Sku = _modelo.Sku,
                Denominacion = _modelo.Denominacion,
                Objetivo = _modelo.Objetivo,
                ColorModelo = new ColorDto()
                {
                    Codigo = _modelo.ColorModelo.Codigo,
                    Descripcion = _modelo.ColorModelo.Descripcion
                }
            };
        }

        public int ObtenerUltimoSku()
        {
            return ModeloRepositorio.ObtenerUltimoSku();
        }

        public bool GuardarModelo(ModeloDto _modelo)
        {
            try
            {
                var modelo = new Modelo()
                {
                    Sku = _modelo.Sku,
                    Denominacion = _modelo.Denominacion,
                    Objetivo = _modelo.Objetivo,
                    ColorModelo = ColorRepositorio.ObtenerColorPorId(_modelo.ColorModelo.Codigo)
                };
                ModeloRepositorio.AgregarModelo(modelo);
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
                modelo.ColorModelo = ColorRepositorio.ObtenerColorPorId(_modelo.ColorModelo.Codigo);

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

            if (usuarioDom == null)
                return null;

            object tipoUsuarioDto;
            switch (usuarioDom.TipoDeUsuario)
            {
                case TipoUsuario.Administrador:
                    tipoUsuarioDto = TipoUsuarioDto.Administrador;
                    break;
                case TipoUsuario.SupervisorLinea:
                    tipoUsuarioDto = TipoUsuarioDto.SupervisorLinea;
                    break;
                case TipoUsuario.SupervisorCalidad:
                    tipoUsuarioDto = TipoUsuarioDto.SupervisorCalidad;
                    break;
                default:
                    tipoUsuarioDto = TipoUsuarioDto.Administrador;
                    break;
            }

            var usuarioDto = new UsuarioDto()
            {
                Id = usuarioDom.Id,
                Nombre = usuarioDom.Nombre,
                Contraseña = usuarioDom.Contraseña,
                TipoDeUsuario = (TipoUsuarioDto)tipoUsuarioDto,
                UsuarioDeEmpleado = new EmpleadoDto()
                {
                    Id = usuarioDom.UsuarioDeEmpleado.Id,
                    Documento = usuarioDom.UsuarioDeEmpleado.Documento,
                    Nombre = usuarioDom.UsuarioDeEmpleado.Nombre,
                    Apellido = usuarioDom.UsuarioDeEmpleado.Apellido,
                    CorreoElectronico = usuarioDom.UsuarioDeEmpleado.CorreoElectronico,
                }
            };

            return (usuarioDto);
        }

        public UsuarioDto ObtenerUsuarioPorId(int id)
        {
            var usuarioDom = UsuarioRepositorio.ObtenerUsuarioPorId(id);

            object tipoUsuarioDto;
            switch (usuarioDom.TipoDeUsuario)
            {
                case TipoUsuario.Administrador:
                    tipoUsuarioDto = TipoUsuarioDto.Administrador;
                    break;
                case TipoUsuario.SupervisorLinea:
                    tipoUsuarioDto = TipoUsuarioDto.SupervisorLinea;
                    break;
                case TipoUsuario.SupervisorCalidad:
                    tipoUsuarioDto = TipoUsuarioDto.SupervisorCalidad;
                    break;
                default:
                    tipoUsuarioDto = TipoUsuarioDto.Administrador;
                    break;
            }

            var usuarioDto = new UsuarioDto()
            {
                Id = usuarioDom.Id,
                Nombre = usuarioDom.Nombre,
                Contraseña = usuarioDom.Contraseña,
                TipoDeUsuario = (TipoUsuarioDto)tipoUsuarioDto,
                UsuarioDeEmpleado = new EmpleadoDto()
                {
                    Id = usuarioDom.UsuarioDeEmpleado.Id,
                    Documento = usuarioDom.UsuarioDeEmpleado.Documento,
                    Nombre = usuarioDom.UsuarioDeEmpleado.Nombre,
                    Apellido = usuarioDom.UsuarioDeEmpleado.Apellido,
                    CorreoElectronico = usuarioDom.UsuarioDeEmpleado.CorreoElectronico,
                }
            };

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
                var ordenProduccionDto = new OrdenProduccionDto();
                ordenProduccionDto.Numero = item.Numero;
                ordenProduccionDto.ParesPrimeraParHermanado = item.ParesPrimeraParHermanado;
                ordenProduccionDto.ParesSegundaPorHermanado = item.ParesSegundaPorHermanado;
                object estadoOPDto;
                switch (item.EstadoDeOP)
                {
                    case EstadoOP.Iniciado:
                    default:
                        estadoOPDto = EstadoOPDto.Iniciado;
                        break;
                    case EstadoOP.Pausado:
                        estadoOPDto = EstadoOPDto.Pausado;
                        break;
                    case EstadoOP.Continuado:
                        estadoOPDto = EstadoOPDto.Continuado;
                        break;
                    case EstadoOP.Finalizado:
                        estadoOPDto = EstadoOPDto.Finalizado;
                        break;
                }
                ordenProduccionDto.EstadoDeOP = (EstadoOPDto)estadoOPDto;
                ordenProduccionDto.ModeloOP = Modelo_DeDomADto(item.ModeloOP);
                ordenProduccionDto.ColorCalzado = Color_DeDomADto(item.ColorCalzado);
                ordenProduccionDto.LineaTrabajo = Linea_DeDomADto(item.LineaTrabajo);
                ordenProduccionDto.ListaDeHorario = null; // falta implementarrr
                ordenProduccionDto.SupervisorCalidad = Empleado_DeDomADto(item.SupervisorCalidad);

                listaDto.Add(ordenProduccionDto);
            }

            return listaDto.ToArray();

        }


        public bool AgregarOrdenProduccion(OrdenProduccionDto ordenProduccionDto)
        {
            var ordenProduccionDom = new OrdenProduccion();

            ordenProduccionDom.Numero = ordenProduccionDto.Numero;
            ordenProduccionDom.EstadoDeOP = ordenProduccionDom.EstadoDeOP;
            ordenProduccionDom.LineaTrabajo.Descripcion = ordenProduccionDto.LineaTrabajo.Descripcion;
            ordenProduccionDom.SupervisorCalidad.Nombre = ordenProduccionDom.SupervisorCalidad.Nombre;
            ordenProduccionDom.SupervisorCalidad.Apellido = ordenProduccionDto.SupervisorCalidad.Apellido;

            OrdenProduccionRepositorio.AgregarOrdenproduccion(ordenProduccionDom);

            return true;
        }
    
        public int ObtenerUltimoIdOP() 
        {
            return OrdenProduccionRepositorio.ObtenerUltimoId();
        }
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
            modeloDto.ColorModelo = Color_DeDomADto(modeloDom.ColorModelo);
            
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
