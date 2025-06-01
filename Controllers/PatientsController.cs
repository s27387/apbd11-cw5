using apbd11_cw5.Services;
using Microsoft.AspNetCore.Mvc;

namespace apbd11_cw5.Controllers;
[ApiController]
[Route("[controller]")]
public class PatientsController : ControllerBase
{
    private readonly IPatientsService _patientsService;

    public PatientsController(IPatientsService patientsService)
    {
        _patientsService = patientsService;
    }
    [HttpGet("{IdPatient}")]
    public async Task<IActionResult> GetPatientAsync(int IdPatient)
    {
        var patient = await _patientsService.GetPatientAsync(IdPatient);
        return Ok(patient);
    }
}