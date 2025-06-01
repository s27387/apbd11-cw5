using apbd11_cw5.Models;

namespace apbd11_cw5.Repositories;

public interface IPrescriptionsRepository
{
    Task<bool> DoctorExistsAsync(int doctorId);
    Task<Patient> GetOrAddPatientAsync(Patient patient);
    Task<List<Medicament>> GetMedicamentsByIdsAsync(IEnumerable<int> ids);
    Task AddPrescriptionAsync(Prescription prescription);
    Task SaveChangesAsync();
}