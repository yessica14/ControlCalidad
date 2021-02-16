﻿using ControlCalidad.Servidor.Datos;
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
                    SupervisorLinea = l.SupervisorLinea
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
            return ColorRepositorio
                .ObtenerTodosLosColores().Select(c => new ColorDto
                {
                    Codigo = c.Codigo,
                    Descripcion = c.Descripcion
                })
                .ToArray();
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

        #endregion


        #region MODELO

        public ModeloDto[] ObtenerTodosLosModelos()
        {
            return ModeloRepositorio
                .ObtenerTodosLosModelos().Select(m => new ModeloDto
                {
                    Sku = m.Sku,
                    Denominacion = m.Denominacion,
                    Objetivo = m.Objetivo,
                    ColorModelo = new ColorDto()
                    {
                        Codigo = m.ColorModelo.Codigo,
                        Descripcion = m.ColorModelo.Descripcion
                    }
                })
                .ToArray();
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

    }

}
