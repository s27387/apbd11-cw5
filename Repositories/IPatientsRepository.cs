namespace apbd11_cw5.Repositories;

public interface IPatienRepository
{
    Task<Patient> GetPatient(int id);
}