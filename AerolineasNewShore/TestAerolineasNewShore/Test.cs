using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Business.IServices;
using Business.Services;
using Newtonsoft.Json.Linq;

namespace TestAerolineasNewShore
{
    [TestFixture]
    class Test
    {

        /// <summary>
        /// Prueba Unitaria realizada al método InsertFlight de la capa de Negocio del Web Service: 
        /// </summary>
        [Test]
        public void Checkdetails()
        {
            JObject flightMock = JObject.FromObject(new {
                DepartureStation = "BOG",
                ArrivalStation= "MDE",
                DepartureDate= DateTime.Now,
                Price= 8604,
                Currency= "COP"
            });
       

        IControlFlight control = new ControlFlight();
        bool condition=control.InsertFlight(flightMock);
            
        Assert.IsTrue(condition);
        }
    }
}
