using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using Proxy.Models;
using Newtonsoft.Json.Linq;

namespace Proxy.Services
{
    public class CProxy : IProxy
    {
        private RestClient _client;
        private RestClient _client2;
        private string appid = "807e039bd90c3a40ac224637ffd000fb";
        private string metrics = "metric";

        public CProxy()
        {
            _client = new RestClient("http://api.openweathermap.org/data/2.5/");
            _client2 = new RestClient("https://restcountries.eu/rest/v2/all");
        }

        public Lista weather(string ciudad)
        {
            var request = new RestRequest($"weather?q={ciudad}&APPID={appid}&units={metrics}");
            var response = _client.Get<Lista>(request);
            return response.Data;
        }

        public RootObject forecast(string ciudad)
        {
            var request = new RestRequest($"forecast?q={ciudad}&APPID={appid}&units={metrics}");
            var response = _client.Get<RootObject>(request);
            return response.Data;
        }

        public List<RootObject> paises()
        {
            List<RootObject> listita = new List<RootObject>();
            var request = new RestRequest();
            var restresponse = _client2.Get(request);
            var response = restresponse.Content;
            var objects = JArray.Parse(response);

            foreach (JObject r in objects)
            {
                RootObject aux = new RootObject();
                aux.name = (string)r["name"];
                aux.capital = (string)r["capital"];
                aux.region = (string)r["region"];
                listita.Add(aux);
            }
            return listita;
        }
    }
}