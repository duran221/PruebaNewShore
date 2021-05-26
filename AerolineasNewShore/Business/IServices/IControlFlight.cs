using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models;
using Newtonsoft.Json.Linq;

namespace Business.IServices
{
    public interface IControlFlight
    {

        bool InsertFlight(JObject flight);
    }
}
