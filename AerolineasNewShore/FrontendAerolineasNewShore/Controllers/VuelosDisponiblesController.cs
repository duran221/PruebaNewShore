using FrontendAerolineasNewShore.Models;
using FrontendAerolineasNewShore.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontendAerolineasNewShore.Controllers
{
    public class VuelosDisponiblesController : Controller
    {

        private readonly IService _serviceRequest;

        public VuelosDisponiblesController(IService service)
        {
            this._serviceRequest = service;
        }

        // GET: VuelosDisponibles
        public ActionResult Index()
        {
            return View();
        }

        // GET: VuelosDisponibles/Details/5
        public ActionResult Details(FormCollection collection)
        {
            
            DateTime date = Convert.ToDateTime(collection["From"]);
            if (date < DateTime.Now.Date)
            {
               
                ViewBag.Message = "La fecha proporcionada debe ser mayor o igual a la fecha actual";
                return View("~/Views/VuelosDisponibles/Index.cshtml");
            }

            FlightModel model = new FlightModel();
            UpdateModel<FlightModel>(model);
            model.From = date.ToString("yyyy-MM-dd");

            string urlWebService = $"http://testapi.vivaair.com/otatest/api/values";

            //Se envia la petición al Web Service solicitando los datos del usuario creado
            var responseServer = _serviceRequest.Send<FlightModel>(urlWebService, model,"POST");
            var responseJSON = JsonConvert.DeserializeObject(responseServer.Data.ToString()).ToString();
            LinkedList<DataFlightModel> dataFlight = JsonConvert.DeserializeObject<LinkedList<DataFlightModel>>(responseJSON);
            
            FlightModel flight = new FlightModel();
            flight.DataFlight = dataFlight;
            return View("~/Views/VuelosDisponibles/Index.cshtml",flight);
        }

        // GET: VuelosDisponibles/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: VuelosDisponibles/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: VuelosDisponibles/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VuelosDisponibles/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: VuelosDisponibles/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VuelosDisponibles/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
