using apbd11_cw5.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd11_cw5.DAL;

public class FarmacyDBContext : DbContext
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }

    protected FarmacyDBContext()
    {
        
    }

    public FarmacyDBContext(DbContextOptions<FarmacyDBContext> options) : base(options)
    {
        
    }

    
}