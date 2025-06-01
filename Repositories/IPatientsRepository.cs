using apbd11_cw5.Models;

namespace apbd11_cw5.Repositories;

public interface IPatientsRepository
{
    Task<Patient?> GetPatientWithDetailsAsync(int idPatient);
}
