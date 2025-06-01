using apbd11_cw5.DAL;
using apbd11_cw5.Models;
using apbd11_cw5.Repositories;
using Microsoft.EntityFrameworkCore;

namespace apbd11_cw5.Repositories;

public class PrescriptionsRepository : IPrescriptionsRepository
{
    private readonly FarmacyDBContext _dbContext;

    public PrescriptionsRepository(FarmacyDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> DoctorExistsAsync(int doctorId)
    {
        return await _dbContext.Doctors.AnyAsync(d => d.IdDoctor == doctorId);
    }

    public async Task<Patient> GetOrAddPatientAsync(Patient patient)
    {
        var existingPatient = await _dbContext.Patients
            .FirstOrDefaultAsync(p => p.FirstName == patient.FirstName
                                      && p.LastName == patient.LastName
                                      && p.Birthdate == patient.Birthdate);
        if (existingPatient != null)
        {
            return existingPatient;
        }

        _dbContext.Patients.Add(patient);
        await _dbContext.SaveChangesAsync();
        return patient;
    }

    public async Task<List<Medicament>> GetMedicamentsByIdsAsync(IEnumerable<int> ids)
    {
        return await _dbContext.Medicaments.Where(m => ids.Contains(m.IdMedicament)).ToListAsync();
    }

    public async Task AddPrescriptionAsync(Prescription prescription)
    {
        _dbContext.Prescriptions.Add(prescription);
        await _dbContext.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
