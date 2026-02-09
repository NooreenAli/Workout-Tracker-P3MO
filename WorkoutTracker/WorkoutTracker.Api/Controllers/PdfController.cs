using Microsoft.AspNetCore.Mvc;
using WorkoutTracker.Api.Services;
using WorkoutTracker.Api.DTOs.Pdf;

namespace WorkoutTracker.Api.Controllers;

[ApiController]
[Route("api/pdf")]
public class PdfController : ControllerBase
{
    private readonly PdfService _service;

    public PdfController(PdfService service)
    {
        _service = service;
    }

    [HttpPost("generate")]
    public async Task<IActionResult> Generate([FromBody] GeneratePdfRequest request)
    {
        var pdf = await _service.GeneratePdfAsync(request.Url);
        return File(pdf, "application/pdf", "workout.pdf");
    }
}

