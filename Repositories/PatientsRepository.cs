using apbd11_cw5.DAL;
using apbd11_cw5.Models;
using apbd11_cw5.Services;
using Microsoft.EntityFrameworkCore;

namespace apbd11_cw5.Repositories;

public class PatientsRepository : IPatientsRepository
{
    private readonly FarmacyDBContext _dbContext;

    public PatientsRepository(FarmacyDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Patient?> GetPatientWithDetailsAsync(int idPatient)
    {
        return await _dbContext.Patients
            .Include(p => p.Prescriptions)
            .ThenInclude(pr => pr.PrescriptionMedicaments)
            .ThenInclude(pm => pm.Medicament)
            .Include(p => p.Prescriptions)
            .ThenInclude(pr => pr.Doctor)
            .Where(p => p.IdPatient == idPatient)
            .FirstOrDefaultAsync();
    }

}