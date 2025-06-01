namespace apbd11_cw5.Dtos;
public class MedicamentDetailDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Type { get; set; } = null!;
    public int? Dose { get; set; }
    public string Details { get; set; } = null!;
}