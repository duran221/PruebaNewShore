using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Business.IServices;
using Business.Services;
using Newtonsoft.Json.Linq;

namespace APIAerolineasNewShore.Controllers
{
    public class FlightController : ApiController
    {
        private readonly IControlFlight _serviceFlight;
        public FlightController(IControlFlight service)
        {
            this._serviceFlight = service;
        }


        // POST: api/Flight
        [System.Web.Http.HttpPost]
        public IHttpActionResult Post(JObject dataFlight)
        {
            bool condition = this._serviceFlight.InsertFlight(dataFlight);
            if (condition)
            {
                return Ok("201");
            }
            else
            {
                return BadRequest();
            }

        }

      
    }
}
