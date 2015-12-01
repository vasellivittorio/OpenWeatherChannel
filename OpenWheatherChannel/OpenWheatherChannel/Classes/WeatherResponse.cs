using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWheatherChannel.Classes
{

    public class WeatherResponse
    {

        public Weather[] weather { get; set; }
        public Main main { get; set; }

        public int dt { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
        public string Temperature
        {
            get
            {
                return (Convert.ToInt32(main.temp-272.15)).ToString() + "° C";
            }
        }
    }

    

    public class Main
    {
        public float temp { get; set; }
        public float humidity { get; set; }
        public float pressure { get; set; }
        public float temp_min { get; set; }
        public float temp_max { get; set; }
    }



    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
}
