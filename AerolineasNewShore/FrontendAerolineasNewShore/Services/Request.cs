using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace FrontendAerolineasNewShore.Services
{
    public class Request : IService
    {     

        public  Response Send<T>(string url, T objectRequest, string method = "POST")
        {
            Response responseApi = new Response();
            try
            {

                //serializamos el objeto en una cadena JSON: 
                string json = JsonConvert.SerializeObject(objectRequest);

                WebRequest request = CrearRequest(url, method, json);
                //Se envia la petición http al web service y se obtiene una referencia de la respuesta:
                var httpResponse = (HttpWebResponse)request.GetResponse();

                string result = LeerArchivo(httpResponse);
                responseApi.Success = 200;
                //y aquí va nuestra respuesta, la cual es lo que nos regrese el sitio solicitado
                responseApi.Data = result;
            }
            catch (Exception e)
            {
                responseApi.Success = 0;
                //en caso de error lo manejamos en el mensaje
                responseApi.Message = e.Message;
            }

            return responseApi;
        }

        public WebRequest CrearRequest(string url, string method, string json)
        {
            //Instanciación del objeto que me permite realizar la petición a el web service (http).
            WebRequest request = WebRequest.Create(url);
            //headers
            request.Method = method;
            request.PreAuthenticate = true;
            request.ContentType = "application/json;charset=utf-8'";
            request.Timeout = 9000000; //esto es opcional
                                       //Se escribe el objeto JSON en el objeto request:
            request = EscribirArchivo(json, request);

            return request;
        }

        private  WebRequest EscribirArchivo(string json, WebRequest request)
        {
            if (json != "null")
            {
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    //Cerrando la escritura del archivo:
                    streamWriter.Flush();
                }
            }

            return request;
        }

        private  string LeerArchivo(HttpWebResponse httpResponse)
        {
            string result;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            return result;
        }
    }
}