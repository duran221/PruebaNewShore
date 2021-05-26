using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontendAerolineasNewShore.Models
{
    public class FlightModel
    {
        public Dictionary<string, string> FlightsName { get; set; }

        [Required]
        [Display(Name = "Origen")]
        public string Origin { get; set; }

        [Required]
        [Display(Name = "Destino")]
        public string Destination { get; set; }

        [Required]
        [Display(Name = "Fecha De Vuelo")]
        public string From { get; set; }
        public LinkedList<DataFlightModel> DataFlight { get; set; }

        public DataFlightModel FlightInsert { get; set; }

        public FlightModel()
        {
            this.FlightsName = new Dictionary<string, string>();
            this.LoadDictionary();
        }


        /// <summary>
        /// Carga el diccionario con las equivalencias para ser mostrados en la tabla de resultados:
        /// </summary>
        private void LoadDictionary()
        {
            this.FlightsName.Add("MDE", "Medellín");
            this.FlightsName.Add("BOG", "Bogotá");
            this.FlightsName.Add("CTG", "Cartagena");
            this.FlightsName.Add("PEI", "Pereira");
        }

    }
}