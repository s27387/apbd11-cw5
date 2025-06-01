using apbd11_cw5.DTOs;

namespace apbd11_cw5.Services;

public interface IPrescriptionsService
{
    Task CreatePrescriptionAsync(CreatePrescriptionDto dto);
}