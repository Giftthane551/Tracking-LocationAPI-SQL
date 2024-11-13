namespace Booking.Services
{
    using System.Collections.Generic;
    using System.Linq;

    public class VehicleLocationRepository : IVehicleLocationRepository
    {
        private readonly List<VehicleLocation> _locations = new();

        public void AddLocation(VehicleLocation location)
        {
            _locations.Add(location);
        }

        public List<VehicleLocation> GetLatestLocations()
        {
            return _locations
                .GroupBy(v => v.VehicleId)
                .Select(g => g.OrderByDescending(v => v.Timestamp).First())
                .ToList();
        }
    }

}
