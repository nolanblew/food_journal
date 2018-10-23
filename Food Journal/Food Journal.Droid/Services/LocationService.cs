using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Gms.Common;
using Android.Gms.Location;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;
using Food_Journal.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Journal.Shared.Services
{
    public class LocationService : ILocationService
    {
        public LocationService()
        {
            _fusedLocationProviderClient = LocationServices.GetFusedLocationProviderClient(Application.Context);
        }

        readonly FusedLocationProviderClient _fusedLocationProviderClient;

        public async Task<Shared.Models.Location?> GetCurrentLocation()
        {
            if (!HasLocationPermissions())
            {
                throw new UnauthorizedAccessException();
            }

            var androidLocation = await _fusedLocationProviderClient.GetLastLocationAsync();
            if (androidLocation == null)
            {
                return null;
            }

            return new Shared.Models.Location(androidLocation.Longitude, androidLocation.Latitude);
        }

        public bool HasLocationPermissions()
        {
            var locationAccess =
                ContextCompat.CheckSelfPermission(Application.Context, Manifest.Permission.AccessFineLocation) ==
                   Permission.Granted;

            if (!locationAccess) { return false; }

            var queryResult = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(Application.Context);
            if (queryResult != ConnectionResult.Success)
            {
                return false;
            }

            return true;
        }
    }
}