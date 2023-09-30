using MyClinic.Domain.Entities;
using MyClinic.Domain.Enums;

namespace MyClinic.Persistence.Repositories
{
    public interface IValidTimeDoctorRepository
    {
        Task<List<ValidTimeDoctor>> DoctorAvailAble(int doctorId, DaysOfWeek Day, CancellationToken cancellationToken = default);
        void Add(ValidTimeDoctor validTimeDoctor);
    }
}