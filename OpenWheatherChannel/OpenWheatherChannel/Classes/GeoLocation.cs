using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace OpenWheatherChannel.Classes
{
    class GeoLocation
    {
        public async Task<Geocoordinate> GetCurrentGeoCoordinates()
        {
            var geolocator = new Geolocator { DesiredAccuracy = PositionAccuracy.Default };
            Geoposition position = await geolocator.GetGeopositionAsync();
            return position.Coordinate;
        }
    }
}
