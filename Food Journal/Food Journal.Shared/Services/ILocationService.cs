using Food_Journal.Shared.Models;
using Food_Journal.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Food_Journal.Shared.Services
{
    public interface ILocationService
    {
        Task<Location?> GetCurrentLocation();
        bool HasLocationPermissions();
    }
}
