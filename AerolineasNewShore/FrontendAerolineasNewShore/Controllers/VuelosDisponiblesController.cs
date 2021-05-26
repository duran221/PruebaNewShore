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
        private readonly string URLAPI = "http://localhost:50430/api";

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
            if (date < DateTime.Now.Date && (collection["Origin"] == collection["Destination"]) )
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

      

        // POST: VuelosDisponibles/Create
        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            try
            {
                
                DataFlightModel flightData = new DataFlightModel()
                {
                    DepartureDate = form["FlightInsert.DepartureDate"],
                    DepartureStation = form["FlightInsert.DepartureStation"],
                    ArrivalStation = form["FlightInsert.ArrivalStation"],
                    Currency = form["FlightInsert.Currency"],
                    FlightNumber = form["FlightInsert.FlightNumber"],
                    Price = decimal.Parse(form["FlightInsert.Price"])

                };

                var urlAction = $"{this.URLAPI}/Flight/Post";
                var responseServer = _serviceRequest.Send<DataFlightModel>(urlAction, flightData);
                string codeResponse = responseServer.Data.ToString().Replace("\"", "");

                if (codeResponse.Equals("201"))
                {
                    ViewBag.Message = "El registro ha sido exitoso";
                    return View("~/Views/VuelosDisponibles/Index.cshtml");
                }
                else
                {
                    ViewBag.Message = "El registro no creado, aségurese de que su email no esté previamente registrado o que su documento";
                }

                return View("~/Views/VuelosDisponibles/Index.cshtml");

                // TODO: Add insert logic here
            }
            catch (Exception ex)
            {
                return View("~/Views/VuelosDisponibles/Index.cshtml");

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
