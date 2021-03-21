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

        public bool AgregarOrdenProduccion(OrdenProduccionDto ordenProduccionDto, EmpleadoDto empleadoDto, DateTime fecha, string hora)
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

            TimeSpan time = TimeSpan.Parse(hora);
            var listaHorario = new List<Horario>();

            var horario = new Horario();

            horario.Fecha = fecha;
            horario.HoraInicio = time;
            listaHorario.Add(horario);
            ordenProduccionDom.ListaDeHorario = listaHorario;

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

        public DefectoDto[] ObtenerListaDefectos(string tipo)
        {
            var listaDto = new List<DefectoDto>();
            var listaDom = new List<Defecto>();
            
            if(tipo == "reproceso")
            {
                var tipoDef = TipoDefecto.Reproceso;
                listaDom = DefectoRepositorio.ObtenerDefectoPorTipoDefecto(tipoDef); 

            }
            else
            {
                var tipoDef = TipoDefecto.Observado;
                listaDom = DefectoRepositorio.ObtenerDefectoPorTipoDefecto(tipoDef);
            }

            foreach (var item in listaDom)
            {
                var defecto = Defecto_DeDomADto(item);
                listaDto.Add(defecto);
            }

            return listaDto.ToArray();
        }

        public DefectoDto[] ObtenerTodosLosDefectos()
        {
            var listaDto = new List<DefectoDto>();
            var listaDom = new List<Defecto>();
            listaDom = DefectoRepositorio.ObtenerTodosLosDefectos();

            foreach (var item in listaDom)
            {
                var defecto = Defecto_DeDomADto(item);
                listaDto.Add(defecto);
            }

            return listaDto.ToArray();
        }

        public DefectoDto ObtenerDefectoPorNumero(int numero)
        {
             var defectoDom = DefectoRepositorio.ObtenerDefectoPorNumero(numero);
             var defectoDto = Defecto_DeDomADto(defectoDom);

             return defectoDto;
        }
        #endregion

        #region TURNO

        public TurnoDto[] ObtenerTurnos()
        {
            var listaDom = TurnoRepositorio.ObtenerTurnos();
            var listaDto = new List<TurnoDto>();

            foreach (var item in listaDom)
            {
                var turnoDto = Turno_DeDomADto(item);
                listaDto.Add(turnoDto);
            }
            return listaDto.ToArray();

        }

        public bool ComprobarTurno(string hora)
        {
            bool b = TurnoRepositorio.ComprobarTurno(hora);
            return b;
        }

        #endregion

        #region HORARIO

        #endregion

        #region HALLAZGO

        public bool EliminarHallazgo(int idOp, int idHorario, int idHallazgo)
        {
            HallazgoRepositorio.EliminarHallazgo(idOp, idHorario, idHallazgo);
            return true;
        }

        public bool RealizarHermanado(int idOp, int idSuperivisorLinea)
        {
            var empleado = EmpleadoRepositorio.BuscarEmpleadoPorId(idSuperivisorLinea);
            PrimeraRepositorio.RealizarHermanado(idOp, empleado);
            return true;
        }

        public bool AgregarHallazgo(int NumeroOp, HallazgoDto hallazgo, int NumeroDef)
        {
            var Op = OrdenProduccionRepositorio.ObtenerOrderProduccionPorId(NumeroOp);
            var hallazgoDom = new Hallazgo();
            hallazgoDom.Cantidad= hallazgo.Cantidad;
            hallazgoDom.HoraHallazgo = hallazgo.HoraHallazgo;
            
            if(PieDto.Derecho == hallazgo.PieHallazgo)
            {
                hallazgoDom.PieHallazgo = Pie.Derecho;
            }
            else
            {
                hallazgoDom.PieHallazgo = Pie.Izquierdo;
            }
            hallazgoDom.DefectoHallazgo = DefectoRepositorio.ObtenerDefectoPorNumero(NumeroDef);

            
            //hallazgoDom.SupervisorCalidad.Documento = hallazgo.SupervisorCalidad.Documento;
            //hallazgoDom.SupervisorCalidad.Nombre = hallazgo.SupervisorCalidad.Nombre;
            //hallazgoDom.SupervisorCalidad.Apellido = hallazgo.SupervisorCalidad.Apellido;
            //hallazgoDom.SupervisorCalidad.CorreoElectronico = hallazgo.SupervisorCalidad.CorreoElectronico;

            foreach (var item in Op.ListaDeHorario)
            {
                if(item.HoraFin == null)
                {
                    item.ListaDeHallazgos.Add(hallazgoDom);
                }
            }

            OrdenProduccionRepositorio.ModificarOrdenProduccion(Op);
            
            return true;
        }

        #endregion

        #region HORARIO

        public bool CerrarHorario(int numeroOP, string hora, DateTime fecha)
        {
            var ordenProduccionDom = OrdenProduccionRepositorio.ObtenerOrderProduccionPorId(numeroOP);
            TimeSpan horaActual = TimeSpan.Parse(hora);
            var hora_ = horaActual.Hours;

            foreach (var item in ordenProduccionDom.ListaDeHorario)  // 9- 23   13 - 23    22 - 23
            {
                if (item.HoraFin == null)
                { 
                    item.HoraFin = horaActual;
                    item.Fecha = fecha;
                }
            }
            OrdenProduccionRepositorio.ModificarOrdenProduccion(ordenProduccionDom);
            return true;
        }
        public bool AgregarNuevoHorario(int numeroOP, string hora, DateTime fecha)
        {
            var ordenProduccionDom = OrdenProduccionRepositorio.ObtenerOrderProduccionPorId(numeroOP);

            TimeSpan horaActual = TimeSpan.Parse(hora);
           
            var horario = new Horario();
            horario.HoraInicio = horaActual; 
            horario.Fecha = fecha;
            ordenProduccionDom.ListaDeHorario.Add(horario);

            OrdenProduccionRepositorio.ModificarOrdenProduccion(ordenProduccionDom);
            return true;
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
            if (opDom.ListaDeHorario == null)
                opDto.ListaDeHorario = null; // falta implementar!
            else
            {
                opDto.ListaDeHorario = new List<HorarioDto>();
                foreach (var item in opDom.ListaDeHorario)
                {
                    var horarioDto = Horario_DeDomADto(item);
                    opDto.ListaDeHorario.Add(horarioDto);
                }
            }
            opDto.SupervisorCalidad = Empleado_DeDomADto(opDom.SupervisorCalidad);

            return (opDto);
        }

        private HorarioDto Horario_DeDomADto(Horario horarioDom)
        {
            if (horarioDom == null)
                return null;

            var horarioDto = new HorarioDto();
            horarioDto.Id = horarioDom.Id;
            horarioDto.Fecha = horarioDom.Fecha;
            horarioDto.HoraInicio = horarioDom.HoraInicio;
            horarioDto.HoraFin = horarioDom.HoraFin == null ? (TimeSpan?)null : horarioDom.HoraFin.Value;
            horarioDto.TurnoHorario = Turno_DeDomADto(horarioDom.TurnoHorario);

            if (horarioDom.ListaDeHallazgos == null)
                horarioDto.ListaDeHallazgos = null;
            else
            {
                horarioDto.ListaDeHallazgos = new List<HallazgoDto>();
                foreach (var item in horarioDom.ListaDeHallazgos)
                {
                    var hallazgoDto = Hallazgo_DeDomADto(item);
                    horarioDto.ListaDeHallazgos.Add(hallazgoDto);
                }
            }

            if (horarioDom.ListaDePrimera == null)
                horarioDto.ListaDePrimera = null;
            else
            {
                horarioDto.ListaDePrimera = new List<PrimeraDto>();
                foreach (var item in horarioDom.ListaDePrimera)
                {
                    var primeraDto = Primera_DeDomADto(item);
                    horarioDto.ListaDePrimera.Add(primeraDto);
                }
            }

            return (horarioDto);
        }

        private TurnoDto Turno_DeDomADto(Turno turnoDom)
        {
            if (turnoDom == null)
                return null;

            var turnoDto = new TurnoDto();
            turnoDto.Codigo = turnoDom.Codigo;
            turnoDto.nombre = turnoDom.nombre;
            turnoDto.HoraInicio = turnoDom.HoraInicio;
            turnoDto.HoraFin = turnoDom.HoraFin;

            return (turnoDto);
        }

        private HallazgoDto Hallazgo_DeDomADto(Hallazgo hallazgoDom)
        {
            if (hallazgoDom == null)
                return null;

            var hallazgoDto = new HallazgoDto();
            hallazgoDto.Id = hallazgoDom.Id;
            hallazgoDto.Cantidad = hallazgoDom.Cantidad;
            hallazgoDto.HoraHallazgo = hallazgoDom.HoraHallazgo;
            hallazgoDto.DefectoHallazgo = Defecto_DeDomADto(hallazgoDom.DefectoHallazgo);
            switch (hallazgoDom.PieHallazgo)
            {
                case Pie.Izquierdo:
                    hallazgoDto.PieHallazgo = PieDto.Izquierdo;
                    break;
                case Pie.Derecho:
                    hallazgoDto.PieHallazgo = PieDto.Derecho;
                    break;
            }
            hallazgoDto.SupervisorCalidad = Empleado_DeDomADto(hallazgoDom.SupervisorCalidad);

            return (hallazgoDto);
        }

        private DefectoDto Defecto_DeDomADto(Defecto defectoDom)
        {
            if (defectoDom == null)
                return null;

            var defectoDto = new DefectoDto();
            defectoDto.Numero = defectoDom.Numero;
            defectoDto.Descripcion = defectoDom.Descripcion;
            switch (defectoDom.TipoDeDefecto)
            {
                case TipoDefecto.Reproceso:
                    defectoDto.TipoDeDefecto = TipoDefectoDto.Reproceso;
                    break;
                case TipoDefecto.Observado:
                    defectoDto.TipoDeDefecto = TipoDefectoDto.Observado;
                    break;
            }

            return (defectoDto);
        }

        private PrimeraDto Primera_DeDomADto(Primera primeraDom)
        {
            if (primeraDom == null)
                return null;

            var primeraDto = new PrimeraDto();
            primeraDto.Hora = primeraDom.Hora;
            primeraDto.Cantidad = primeraDom.Cantidad;
            primeraDto.SupervisorCalidad = Empleado_DeDomADto(primeraDom.SupervisorCalidad);

            return (primeraDto);
        }


    }
    
    #endregion
}
