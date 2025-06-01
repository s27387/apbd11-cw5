

using apbd11_cw5.DTOs;
using apbd11_cw5.Models;
using apbd11_cw5.Repositories;
using apbd11_cw5.Services;

namespace apbd11_cw5.Services;

public class PrescriptionsService : IPrescriptionsService
{
    private readonly IPrescriptionsRepository _prescriptionsRepository;

    public PrescriptionsService(IPrescriptionsRepository repository)
    {
        _prescriptionsRepository = repository;
    }

    public async Task CreatePrescriptionAsync(CreatePrescriptionDto createPrescriptionDto)
    {
        if (!await _prescriptionsRepository.DoctorExistsAsync(createPrescriptionDto.DoctorId))
        {
            throw new Exception("Doctor not found");
        }

        var patient = await _prescriptionsRepository.GetOrAddPatientAsync(new Patient
        {
            FirstName = createPrescriptionDto.Patient.FirstName,
            LastName = createPrescriptionDto.Patient.LastName,
            Birthdate = createPrescriptionDto.Patient.BirthDate
        });

        var medicaments = await _prescriptionsRepository.GetMedicamentsByIdsAsync(createPrescriptionDto.Medicaments.Select(m => m.IdMedicament));
        if (medicaments.Count != createPrescriptionDto.Medicaments.Count)
        {
            throw new Exception("One or more medicaments not found");
        }

        var prescription = new Prescription
        {
            Date = createPrescriptionDto.Date,
            DateDue = createPrescriptionDto.DateDue,
            IdDoctor = createPrescriptionDto.DoctorId,
            IdPatient = patient.IdPatient,
            PrescriptionMedicaments = createPrescriptionDto.Medicaments.Select(m => new PrescriptionMedicament
            {
                IdMedicament = m.IdMedicament,
                Dose = m.Dose,
                Details = m.Details
            }).ToList()
        };

        await _prescriptionsRepository.AddPrescriptionAsync(prescription);
    }
}