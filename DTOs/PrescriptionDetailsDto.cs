namespace apbd11_cw5.Dtos;

public class PrescriptionDetailDto
{
    public DateTime Date { get; set; }
    public DateTime DateDue { get; set; }
    public string DoctorFirstName { get; set; } = null!;
    public string DoctorLastName { get; set; } = null!;
    public List<MedicamentDetailDto> Medicaments { get; set; } = new();
}