using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FrontendAerolineasNewShore.Services
{
    public interface IService
    {

        Response Send<T>(string url, T objectRequest, string method = "POST");

        WebRequest CrearRequest(string url, string method, string json);

    }
}
