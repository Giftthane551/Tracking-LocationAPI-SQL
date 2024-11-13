using Booking.Services;
using Microsoft.EntityFrameworkCore;
using Booking.Models;

namespace Booking.Data
{
    public class VehicleDbContext : DbContext
    {
        public VehicleDbContext(DbContextOptions<VehicleDbContext> options) : base(options) { }

        public DbSet<VehicleLocation> VehicleLocations { get; set; }
    }
}
