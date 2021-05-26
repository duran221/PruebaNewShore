using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontendAerolineasNewShore.Services
{
    public class Response
    {
        public int Success { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}