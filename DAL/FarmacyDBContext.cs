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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed Doctors
        modelBuilder.Entity<Doctor>().HasData(
            new Doctor { IdDoctor = 1, FirstName = "Anna", LastName = "Kowalska", Email = "anna.kowalska@example.com" },
            new Doctor { IdDoctor = 2, FirstName = "Jan", LastName = "Nowak", Email = "jan.nowak@example.com" }
        );

        // Seed Patients
        modelBuilder.Entity<Patient>().HasData(
            new Patient { IdPatient = 1, FirstName = "Maria", LastName = "Wiśniewska", Birthdate = new DateTime(1985, 3, 12) },
            new Patient { IdPatient = 2, FirstName = "Tomasz", LastName = "Lewandowski", Birthdate = new DateTime(1992, 7, 23) }
        );

        // Seed Medicaments
        modelBuilder.Entity<Medicament>().HasData(
            new Medicament { IdMedicament = 1, Name = "Ibuprofen", Description = "Painkiller and anti-inflammatory", Type = "Tablet" },
            new Medicament { IdMedicament = 2, Name = "Amoxicillin", Description = "Antibiotic for infections", Type = "Capsule" }
        );

        // Seed Prescriptions
        modelBuilder.Entity<Prescription>().HasData(
            new Prescription { IdPrescription = 1, Date = DateTime.Now.Date, DateDue = DateTime.Now.Date.AddDays(7), IdDoctor = 1, IdPatient = 1 },
            new Prescription { IdPrescription = 2, Date = DateTime.Now.Date, DateDue = DateTime.Now.Date.AddDays(10), IdDoctor = 2, IdPatient = 2 }
        );

        // Seed Prescription_Medicament (join table)
        modelBuilder.Entity<PrescriptionMedicament>().HasData(
            new PrescriptionMedicament { IdMedicament = 1, IdPrescription = 1, Dose = 200, Details = "Take one tablet after meal" },
            new PrescriptionMedicament { IdMedicament = 2, IdPrescription = 1, Dose = null, Details = "Use only when needed" },
            new PrescriptionMedicament { IdMedicament = 1, IdPrescription = 2, Dose = 400, Details = "Twice a day with water" }
        );
    }

    
}