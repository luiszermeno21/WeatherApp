using System.Collections.Generic;

namespace Proxy.Models
{
    public class Main
    {
        public double temp { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int sea_level { get; set; }
        public int grnd_level { get; set; }
        public int humidity { get; set; }
        public double temp_kf { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public int deg { get; set; }
    }

    public class Sys
    {
        public string pod { get; set; }
    }

    public class Rain
    {
        public double _invalid_name_3h { get; set; }
    }

    public class Lista
    {
        private int dt { get; set; }
        private List<Weather> weather { get; set; }
        private Clouds clouds { get; set; }
        private Wind wind { get; set; }
        private Sys sys { get; set; }
        private string dt_txt { get; set; }
        private Rain rain { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        private Coord coord { get; set; }
        public string country { get; set; }
        private int population { get; set; }
        public int timezone { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
        public double temp { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
    }

    public class Coord
    {
        public double lat { get; set; }
        public double lon { get; set; }
    }

    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public Coord coord { get; set; }
        public string country { get; set; }
        public int population { get; set; }
        public int timezone { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    public class RootObject
    {
        public string cod { get; set; }
        public int message { get; set; }
        public int cnt { get; set; }
        public List<Lista> list { get; set; }
        public City city { get; set; }
    }

    public class Perfil
    {
        public int idperfil { get; set; }
        public string usuario { get; set; }
        public string contraseña { get; set; }
    }
}