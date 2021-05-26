using Newtonsoft.Json;
using NLog;
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
        /// <summary>
        /// Genera una petición a un recurso en la red usando HTTP:
        /// </summary>
        /// <typeparam name="T">Objeto genérico con la carga útil de la petición</typeparam>
        /// <param name="url">URI del recurso solicitado</param>
        /// <param name="objectRequest"></param>
        /// <param name="method">POST-GET-DELETE-PUT</param>
        /// <returns>Objeto Response con la información obtenida desde el servicio</returns>
        public  Response Send<T>(string url, T objectRequest, string method = "POST")
        {
            Response responseApi = new Response();
            try
            {

                string json = JsonConvert.SerializeObject(objectRequest);

                WebRequest request = CrearRequest(url, method, json);
                //Se envia la petición http al web service y se obtiene una referencia de la respuesta:
                var httpResponse = (HttpWebResponse)request.GetResponse();

                string result = LeerArchivo(httpResponse);
                responseApi.Success = 200;
                responseApi.Data = result;
            }
            catch (Exception ex)
            {
                responseApi.Success = 500;
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error(ex, "Ocurrió un error al intentar solicitar el recurso HTTP");
                responseApi.Message = ex.Message;
            }

            return responseApi;
        }

        /// <summary>
        /// Construye una petición HTTP
        /// </summary>
        public WebRequest CrearRequest(string url, string method, string json)
        {
            //Instanciación del objeto que me permite realizar la petición a el web service (http).
            WebRequest request = WebRequest.Create(url);
            //headers
            request.Method = method;
            request.PreAuthenticate = true;
            request.ContentType = "application/json;charset=utf-8'";
            request.Timeout = 9000000; //Tiempo máximo en espera a una respuesta
                                    
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