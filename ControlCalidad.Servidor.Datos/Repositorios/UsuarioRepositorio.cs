using ControlCalidad.Servidor.Datos.Persistencia;
using ControlCalidad.Servidor.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Servidor.Datos.Repositorios
{
    public class UsuarioRepositorio
    {
        public void CargarUsuarios()
        {
            var empresa = Singleton.getInstancia().ObtenerDatosDeEmpresa();
            empresa.ListaDeUsuarios.Add
            (
                new Usuario()
                {
                    Id = 1,
                    Nombre = "gimenezy",
                    Contraseña = "123",
                    UsuarioDeEmpleado = EmpleadoRepositorio.BuscarEmpleadoPorId(1),
                    TipoDeUsuario = TipoUsuario.SupervisorLinea
                }
            );
            empresa.ListaDeUsuarios.Add
            (
                new Usuario()
                {
                    Id = 2,
                    Nombre = "gramajoj",
                    Contraseña = "123",
                    UsuarioDeEmpleado = EmpleadoRepositorio.BuscarEmpleadoPorId(2),
                    TipoDeUsuario = TipoUsuario.SupervisorCalidad
                }
            );
            empresa.ListaDeUsuarios.Add
            (
                new Usuario()
                {
                    Id = 3,
                    Nombre = "zampa",
                    Contraseña = "123",
                    UsuarioDeEmpleado = EmpleadoRepositorio.BuscarEmpleadoPorId(3),
                    TipoDeUsuario = TipoUsuario.Administrador
                }
            );
            empresa.ListaDeUsuarios.Add
            (
                new Usuario()
                {
                    Id = 4,
                    Nombre = "aguilard",
                    Contraseña = "123",
                    UsuarioDeEmpleado = EmpleadoRepositorio.BuscarEmpleadoPorId(4),
                    TipoDeUsuario = TipoUsuario.SupervisorLinea
                }
            );
            empresa.ListaDeUsuarios.Add
            (
                new Usuario()
                {
                    Id = 5,
                    Nombre = "arcem",
                    Contraseña = "123",
                    UsuarioDeEmpleado = EmpleadoRepositorio.BuscarEmpleadoPorId(5),
                    TipoDeUsuario = TipoUsuario.SupervisorLinea
                }
            );
            Singleton.getInstancia().AsignarDatosAEmpresa(empresa);
        }

        public static Usuario ComprobarLogueo(string nombre, string contraseña)
        {
            var empresa = Singleton.getInstancia().ObtenerDatosDeEmpresa();

            var usuarioLogueado = empresa.ListaDeUsuarios.Where(x => x.Nombre == nombre && x.Contraseña == contraseña).FirstOrDefault();

            if (usuarioLogueado != null)
            {
                Singleton.getInstancia().SessionDeUsuario = usuarioLogueado;
                return usuarioLogueado;
            }

            return null;
        }

        public static Usuario ObtenerUsuarioPorId(int id)
        {
            var empresa = Singleton.getInstancia().ObtenerDatosDeEmpresa();
            var usuario = empresa.ListaDeUsuarios.Where(x => x.Id == id).FirstOrDefault();
            return usuario;
        }

    }
}
