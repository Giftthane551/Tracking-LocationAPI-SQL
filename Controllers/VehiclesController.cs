using Booking.Data;
using Booking.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Booking.Models;

namespace Booking.Controllers
{
    public class VehicleIdRequest
    {
        public string VehicleId { get; set; }
    }

    [Route("api/vehicles")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly VehicleDbContext _context;

        public VehiclesController(VehicleDbContext context)
        {
            _context = context;
        }

        // POST /api/vehicles/location
        [HttpPost("location")]
        public async Task<IActionResult> PostLocation([FromBody] VehicleLocation location)
        {
            if (location == null)
                return BadRequest("Invalid data.");

            _context.VehicleLocations.Add(location);
            await _context.SaveChangesAsync();

            return Ok("Location saved successfully.");
        }

        // GET /api/vehicles/locations
        [HttpGet("locations")]
        public async Task<IActionResult> GetLatestLocations()
        {
            var latestLocations = await _context.VehicleLocations
                .GroupBy(v => v.VehicleId)
                .Select(g => g.OrderByDescending(v => v.Timestamp).FirstOrDefault())
                .ToListAsync();

            return Ok(latestLocations);
        }                                                                                                      

        // POST /api/vehicles/location-by-id
        [HttpPost("location-by-id")]
        public async Task<IActionResult> GetLocationByVehicleId([FromBody] VehicleIdRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.VehicleId))
                return BadRequest("Invalid VehicleId.");

            var location = await _context.VehicleLocations
                .Where(v => v.VehicleId == request.VehicleId)
                .OrderByDescending(v => v.Timestamp)
                .FirstOrDefaultAsync();

            if (location == null)
                return NotFound($"No location found for VehicleId {request.VehicleId}.");

            return Ok(location);
        }
    }
}
