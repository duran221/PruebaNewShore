using Business.IServices;
using Entity.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ControlFlight : IControlFlight
    {

        /// <summary>
        /// Inserta los datos de un Vuelo en base de datos
        /// </summary>
        /// <param name="flight">JSON con la información del vuelo</param>
        /// <returns>True si la inserción fué exitosa, false de lo contrario</returns>
        public bool InsertFlight(JObject flight)
        {
            using (Context db = new Context())
            {
                try
                {
                    var responseJSON = JsonConvert.DeserializeObject(flight.ToString()).ToString();
                    Flight dataFlight = JsonConvert.DeserializeObject<Flight>(responseJSON);
                    db.Flight.Add(dataFlight);
                    db.SaveChanges();

                    return true;

                }catch(Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
