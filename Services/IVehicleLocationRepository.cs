namespace Booking.Services
{
    public interface IVehicleLocationRepository
    {
        void AddLocation(VehicleLocation location);
        List<VehicleLocation> GetLatestLocations();
    }

}
