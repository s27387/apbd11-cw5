﻿

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace apbd11_cw5.Models;

[PrimaryKey(nameof(IdMedicament), nameof(IdPrescription))]
[Table("Prescription_Medicament")]
public class PrescriptionMedicament
{
    
    [ForeignKey(nameof(IdMedicament))]
    public int IdMedicament { get; set; }
    public Medicament Medicament { get; set; }
    
    [ForeignKey(nameof(IdPrescription))]
    public int IdPrescription { get; set; }
    public Prescription Prescription { get; set; }
    
    
    public int? Dose { get; set; }
    [MaxLength(100)]
    public string Details { get; set; }

}