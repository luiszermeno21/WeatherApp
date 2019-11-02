using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using Proxy.Models;

namespace Proxy.Services
{
    public class CProxy : IProxy
    {
        private RestClient _client;
        private string appid = "b1e34d4d55487b41db609a28e5854900";
        private string metrics = "metric";

        public CProxy()
        {
            _client = new RestClient("http://api.openweathermap.org/data/2.5/");
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
    }
}