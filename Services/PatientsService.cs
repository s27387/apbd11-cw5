using apbd11_cw5.Dtos;
using apbd11_cw5.DTOs;
using apbd11_cw5.Models;
using apbd11_cw5.Repositories;

namespace apbd11_cw5.Services;

public class PatientsService : IPatientsService
{
    private readonly IPatientsRepository _patientsRepository;

    public PatientsService(IPatientsRepository patientsRepository)
    {
        _patientsRepository = patientsRepository;
    }
    public async Task<PatientDto?> GetPatientAsync(int idPatient)
    {
        var patient = await _patientsRepository.GetPatientWithDetailsAsync(idPatient);

        if (patient == null)
            return null;

        return new PatientDto
        {
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            BirthDate = patient.Birthdate,
            Prescriptions = patient.Prescriptions
                .OrderBy(p => p.DateDue)
                .Select(p => new PrescriptionDetailDto
                {
                    Date = p.Date,
                    DateDue = p.DateDue,
                    DoctorFirstName = p.Doctor.FirstName,
                    DoctorLastName = p.Doctor.LastName,
                    Medicaments = p.PrescriptionMedicaments.Select(pm => new MedicamentDetailDto
                    {
                        Name = pm.Medicament.Name,
                        Description = pm.Medicament.Description,
                        Type = pm.Medicament.Type,
                        Dose = pm.Dose,
                        Details = pm.Details
                    }).ToList()
                }).ToList()
        };
    }


}