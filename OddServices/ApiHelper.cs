using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OddServices
{
    public class ApiHelper
    {
        public static async Task<object> CallServiceAsync<T>(string url, object requestBodyObject, string method) where T : class
        {
            // Initialize an HttpWebRequest for the current URL.
            var webReq = (HttpWebRequest)WebRequest.Create(url);
            webReq.Method = method;
            webReq.Accept = "application/json";

            //Serialize request object as JSON and write to request body
            if (requestBodyObject != null)
            {
                var requestBody = JsonConvert.SerializeObject(requestBodyObject);
                webReq.ContentLength = requestBody.Length;
                var streamWriter = new StreamWriter(webReq.GetRequestStream(), Encoding.ASCII);
                streamWriter.Write(requestBody);
                streamWriter.Close();
            }

            var response = await webReq.GetResponseAsync();

            if (response == null)
            {
                return default;
            }

            var streamReader = new StreamReader(response.GetResponseStream());

            var responseContent = streamReader.ReadToEnd().Trim();

            var jsonObject = JsonConvert.DeserializeObject<T>(responseContent);

            return jsonObject;
        }
    }
}