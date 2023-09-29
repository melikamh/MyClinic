using MyClinic.Domain.Entities;


namespace MyClinic.Persistence.Repositories
{
    public interface IDoctorRepository
    {
        void Add(Doctor doctor);

    }
}