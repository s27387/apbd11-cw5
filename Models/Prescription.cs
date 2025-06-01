using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apbd11_cw5.Models;

public class Prescription
{
    [Key]
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DateDue { get; set; }
    
    public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    
    public int IdPatient { get; set; }
    [ForeignKey(nameof(IdPatient))]
    public Patient Patient { get; set; }
    
    public int IdDoctor { get; set; }
    [ForeignKey(nameof(IdDoctor))]
    public Doctor Doctor { get; set; }
}