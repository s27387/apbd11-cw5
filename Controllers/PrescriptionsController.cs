using apbd11_cw5.DTOs;
using apbd11_cw5.Services;
using Microsoft.AspNetCore.Mvc;

namespace apbd11_cw5.Controllers;

[ApiController]
[Route("[controller]")]
public class PrescriptionsController : ControllerBase
{
    private readonly IPrescriptionsService _prescriptionsService;

    public PrescriptionsController(IPrescriptionsService service)
    {
        _prescriptionsService = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePrescriptionAsync([FromBody] CreatePrescriptionDto createPrescriptionDto)
    {
        try
        {
            await _prescriptionsService.CreatePrescriptionAsync(createPrescriptionDto);
            return Ok("Prescription created successfully");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
