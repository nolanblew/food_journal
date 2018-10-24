using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Food_Journal.Shared.Models;

namespace Food_Journal.Shared.Services
{
    public class LocationService : ILocationService
    {
        public LocationService()
        {
            _geolocator = new Geolocator
            {
                DesiredAccuracy = PositionAccuracy.Default,
            };
        }

        readonly Geolocator _geolocator;

        public async Task<Location?> GetCurrentLocation()
        {
            var access = (await Geolocator.RequestAccessAsync()) == GeolocationAccessStatus.Allowed;
            if (!access) { return null; }

            var location = await _geolocator.GetGeopositionAsync(TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(1));
            if (location == null) { return null; }

            return new Location(location.Coordinate.Point.Position.Longitude, location.Coordinate.Point.Position.Latitude);
        }

        public bool HasLocationPermissions()
        {
            return true;
        }
    }
}
