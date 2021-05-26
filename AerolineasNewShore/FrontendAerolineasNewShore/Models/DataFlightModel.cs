using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontendAerolineasNewShore.Models
{
    public class DataFlightModel
    {
        public string DepartureDate { get; set; }
        public string DepartureStation { get; set; }
        public string ArrivalStation { get; set; }
        public string FlightNumber { get; set; }
        public decimal Price { get; set; }
        public string  Currency { get; set; }
    }
}