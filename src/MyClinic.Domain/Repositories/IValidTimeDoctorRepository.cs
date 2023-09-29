using MyClinic.Domain.Entities;

namespace MyClinic.Persistence.Repositories
{
    public interface IValidTimeDoctorRepository
    {
        void Add(ValidTimeDoctor validTimeDoctor);
    }
}