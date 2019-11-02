using System;
using System.Collections.Generic;
using System.Text;
using Proxy.Models;
using DataAccessLayer;

namespace BusinnesLogicLayer.Services
{
    public class ClimaService
    {
        private readonly ADSSingleton _dataService;

        public ClimaService(string connectionString)
        {
            _dataService = ADSSingleton.GetInstance(connectionString);
        }

        public List<Lista> GetCity(string nombre)
        {
            return _dataService.GetCity(nombre);
        }

        public string AddCity(Lista ciudad)
        {
            try
            {
                return _dataService.AddCity(ciudad) ? "City Added Successfully" : "Error Adding City";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string DeleteCity(string nombre)
        {
            try
            {
                return _dataService.DeleteCity(nombre) ? "City Delete Successfully" : "Error in deleteing City";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
