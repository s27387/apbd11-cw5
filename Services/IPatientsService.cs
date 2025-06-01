using apbd11_cw5.DTOs;
using apbd11_cw5.Models;

namespace apbd11_cw5.Services;

public interface IPatientsService
{
    Task<PatientDto> GetPatientAsync(int IdPatient);
}