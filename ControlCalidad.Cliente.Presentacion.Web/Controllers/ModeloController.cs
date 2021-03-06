﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControlCalidad.Cliente.AccesoExterno;
using ControlCalidad.Cliente.AccesoExterno.ControlCalidadServiceReference;
using ControlCalidad.Cliente.Presentacion.Web.Models.Modelo;

namespace ControlCalidad.Cliente.Presentacion.Web.Controllers
{
    public class ModeloController : Controller
    {
        // GET: Modelo
        public ActionResult Index()
        {
            if (Session["Session_Usuario_Id"] == null)
                return RedirectToAction("Login", "Home");

            var model = new IndexViewModel()
            {
                Modelos = Adaptador.ObtenerModelos().ToList()
            };
            return View(model);
        }

        public ActionResult GestionABM(string tipoGestion, string txtSku = "")
        {
            if (Session["Session_Usuario_Id"] == null)
                return RedirectToAction("Login", "Home");

            if (!int.TryParse(txtSku, out int sku))
                RedirectToAction("Login", "Home");

            var _model = new GestionABMViewModel()
            {
                TipoGestion = tipoGestion
            };

            switch (tipoGestion)
            {
                case "ALTA":
                    _model.Modelo = new ModeloDto();
                    _model.Modelo.Sku = Adaptador.ObtenerUltimoSku();
                    break;

                case "MODIFICACION":
                    var modelo = Adaptador.ObtenerModeloPorSku(sku);
                    _model.Modelo = modelo;
                    _model.TxtDenominacion = modelo.Denominacion;
                    _model.TxtObjetivo = modelo.Objetivo.ToString();
                    break;

                default:
                    RedirectToAction("Login", "Home");
                    break;
            }

            return View(_model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GestionABM(GestionABMViewModel model, FormCollection collection)
        {
            if (Session["Session_Usuario_Id"] == null)
                return RedirectToAction("Login", "Home");

            var tipoGestion = collection["nHiddenTipoGestion"].ToString();
            var sku = int.Parse(collection["nHiddenSku"].ToString());

            switch (tipoGestion)
            {
                case "ALTA":
                    model.Modelo = new ModeloDto();
                    model.Modelo.Sku = Adaptador.ObtenerUltimoSku();
                    break;

                case "MODIFICACION":
                    var modelo = Adaptador.ObtenerModeloPorSku(sku);
                    model.Modelo = modelo;
                    break;
            }

            model.TipoGestion = collection["nHiddenTipoGestion"].ToString();

            if (!ModelState.IsValid)
                return View(model);

            model.Modelo.Denominacion = model.TxtDenominacion;
            model.Modelo.Objetivo = int.Parse(model.TxtObjetivo);

            var respuestaServer = false;
            switch (model.TipoGestion)
            {
                case "ALTA":
                    respuestaServer = Adaptador.GuardarModelo(model.Modelo);
                    break;
                case "MODIFICACION":
                    respuestaServer = Adaptador.ModificarModelo(model.Modelo);
                    break;
            }
            
            if (respuestaServer)
                return RedirectToAction("Index", "Modelo");
            else
                return View(model);
        }

        [HttpPost]
        public ActionResult EliminarModelo(FormCollection collection)
        {
            if (Session["Session_Usuario_Id"] == null)
                return RedirectToAction("Login", "Home");

            var sku = int.Parse(collection["nHiddenEliminar"].ToString());
            var modelo = Adaptador.ObtenerModeloPorSku(sku);
            
            var respuestaServidor = Adaptador.EliminarModelo(modelo);

            if (respuestaServidor)
                return RedirectToAction("Index", "Modelo");
            else
                return RedirectToAction("Index", "Articulo");
        }
    }
}