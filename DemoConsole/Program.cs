using System;
using System.IO;
using RestSharp;

namespace DemoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Obteniendo imagenes de NASA...");

            using var writer = File.OpenWrite("imagen.jpg");

            var client = new RestClient("https://api.nasa.gov");
            var request = new RestRequest("planetary/earth/imagery/?lon=-64.481&lat=-32.165&date=2020-03-01&cloud_score=False&api_key=X2Gv8aiujUd1rXOk8XCDcmgIWCo9j3LVUVzAIWbd&dim=0.08", Method.GET);

            request.ResponseWriter = responseStream =>
            {
                using (responseStream)
                {
                    responseStream.CopyTo(writer);
                }
            };
            var response = client.DownloadData(request);

            Console.WriteLine("Se guardo imagen.jpg");
          
          
        
        }
    }
}
