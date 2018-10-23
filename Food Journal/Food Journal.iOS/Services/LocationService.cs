using CoreLocation;
using Food_Journal.Shared.Models;
using System.Threading.Tasks;

namespace Food_Journal.Shared.Services
{
    public class LocationService : ILocationService
    {
        public LocationService()
        {
            _locationManager = new CLLocationManager();
            _locationManager.RequestWhenInUseAuthorization();
            _locationManager.DesiredAccuracy = 1;
        }

        readonly CLLocationManager _locationManager;
        TaskCompletionSource<CLLocation> _requestLocationTaskCompletionSource;

        public async Task<Location?> GetCurrentLocation()
        {
            if (!HasLocationPermissions()) { return null; }

            _requestLocationTaskCompletionSource = new TaskCompletionSource<CLLocation>();

            _locationManager.UpdatedLocation += _LocationManagerOnUpdatedLocation;
            _locationManager.RequestLocation();

            var clLocation = await _requestLocationTaskCompletionSource.Task;
            return new Location(clLocation.Coordinate.Longitude, clLocation.Coordinate.Latitude);
        }

        public bool HasLocationPermissions()
        {
            return CLLocationManager.LocationServicesEnabled;
        }

        void _LocationManagerOnUpdatedLocation(object sender, CLLocationUpdatedEventArgs e)
        {
            _requestLocationTaskCompletionSource.SetResult(e.NewLocation);
        }
    }
}