
namespace Booking.Services
{
    public class VehicleLocation
    {

        public int Id { get; set; }
        public string VehicleId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime Timestamp { get; set; }
    }
 }
