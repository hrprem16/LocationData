using Microsoft.AspNetCore.Mvc;

namespace GetDeviceLocation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocationController : ControllerBase
{
    private readonly ILogger<LocationController> _logger;

    public LocationController(ILogger<LocationController> logger)
    {
        _logger = logger;
    }

    [HttpPost("share-location")]
    public IActionResult ShareLocation([FromBody] LocationData location)
    {
        if (location == null)
        {
            _logger.LogWarning("Received null location data.");
            return BadRequest("Invalid location data.");
        }

        // Process or save the location data
        _logger.LogInformation($"Latitude: {location.Latitude}, Longitude: {location.Longitude}");

        return Ok("Location data received successfully.");
    }
}

public class LocationData
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
