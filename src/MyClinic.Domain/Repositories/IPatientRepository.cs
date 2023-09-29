using MyClinic.Domain.Entities;

namespace MyClinic.Persistence.Repositories
{
    public interface IPatientRepository
    {
        void Add(Patient patient);
    }
}