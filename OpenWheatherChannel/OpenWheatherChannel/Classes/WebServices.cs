using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Web.Http;

namespace OpenWheatherChannel.Classes
{
    class WebServices
    {
        private string appid = "e0985bfa3a9b3c04c582df36689d51f8";
        private string CURRENTWEATHERBYGEOCOORDINATES = "http://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&appid={2}";

        public async Task<WeatherResponse> GetCurrentWheatherByGeoCoordinates(double lat, double lon)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, new Uri(String.Format(CURRENTWEATHERBYGEOCOORDINATES, lat, lon, appid)));
                var httpResponse = await new HttpClient().SendRequestAsync(request);
                httpResponse.EnsureSuccessStatusCode();
                var response = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WeatherResponse>(response) ;
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
                return null;
            }

        }

    }
}
