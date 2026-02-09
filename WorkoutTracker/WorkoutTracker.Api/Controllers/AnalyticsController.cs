using Microsoft.AspNetCore.Mvc;
using WorkoutTracker.Api.Services;

namespace WorkoutTracker.Api.Controllers;

[ApiController]
[Route("api/analytics")]
public class AnalyticsController : ControllerBase
{
    private readonly AnalyticsService _service;

    public AnalyticsController(AnalyticsService service)
    {
        _service = service;
    }

    [HttpGet("volume-by-session")]
    public async Task<IActionResult> GetVolumeBySession()
    {
        var data = await _service.GetVolumeBySessionAsync();
        return Ok(data);
    }

    [HttpGet("sets-by-exercise")]
    public async Task<IActionResult> GetSetsByExercise()
    {
        var data = await _service.GetSetsByExerciseAsync();
        return Ok(data);
    }
}

