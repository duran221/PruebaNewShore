using FrontendAerolineasNewShore.Models;
using FrontendAerolineasNewShore.Services;
using Newtonsoft.Json;
using NLog;
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
        //Servicio que permite resolver las solicitudes realizadas a un recurso http:
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
            if (date < DateTime.Now.Date || (collection["Origin"] == collection["Destination"]) )
            {
                ViewBag.Message = "Por favor verifique que la fecha ingresada sea mayor o igual a la actual y que origen y destino sean distintos";
                return View("~/Views/VuelosDisponibles/Index.cshtml");
            }
            try
            {
                FlightModel model = new FlightModel();
                UpdateModel<FlightModel>(model);
                model.From = date.ToString("yyyy-MM-dd");

                string urlWebService = $"http://testapi.vivaair.com/otatest/api/values";
                //Se envia la petición al Web Service solicitando los datos del usuario creado
                var responseServer = _serviceRequest.Send<FlightModel>(urlWebService, model, "POST");
                var responseJSON = JsonConvert.DeserializeObject(responseServer.Data.ToString()).ToString();
                LinkedList<DataFlightModel> dataFlight = JsonConvert.DeserializeObject<LinkedList<DataFlightModel>>(responseJSON);

                FlightModel flight = new FlightModel();
                flight.DataFlight = dataFlight;
                return View("~/Views/VuelosDisponibles/Index.cshtml", flight);
            }catch(Exception ex)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error(ex, "Ocurrió un error al intentar cargar el recurso externo del API");
                return View("~/Views/VuelosDisponibles/Index.cshtml");
            }
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
                    ViewBag.Message = "El registro del vuelo ha sido exitoso";
                }
                else
                {
                    ViewBag.Message = "Registro no insertado, por favor vuelve ha intentar";
                }
                return View("~/Views/VuelosDisponibles/Index.cshtml");
            }
            catch (Exception ex)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error(ex, "Ha ocurrido un error al intentar insertar el recurso en el Web API");
                return View("~/Views/VuelosDisponibles/Index.cshtml");
            }
        }

    }
}
