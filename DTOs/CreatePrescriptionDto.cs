namespace apbd11_cw5.DTOs;

public class CreatePrescriptionDto
{
    public DateTime Date { get; set; }
    public DateTime DateDue { get; set; }
    public int DoctorId { get; set; }
    public PatientDto Patient { get; set; } = null!;
    public List<PrescriptionMedicamentDto> Medicaments { get; set; } = new();
}