using System;
using System.Collections.Generic;
using System.Text;
using Proxy.Models;

namespace Proxy.Services
{
    public interface IProxy
    {
        Lista weather(string name);
        RootObject forecast(string name);
        List<RootObject> paises();
    }
}