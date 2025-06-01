using apbd11_cw5.Dtos;

namespace apbd11_cw5.DTOs;

public class PatientDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public List<PrescriptionDetailDto>? Prescriptions { get; set; }
}