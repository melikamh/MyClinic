using MyClinic.Domain.Entities;
using MyClinic.Domain.Enums;

namespace MyClinic.Persistence.Repositories
{
    public interface IValidTimeDoctorRepository
    {
        /// <summary>
        /// لیست نوبتهای پزشک در روز
        /// </summary>
        /// <param name="doctorId"></param>
        /// <param name="day"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<ValidTimeDoctor>> GetAvailableDoctorByDate(int doctorId, DateTime date, CancellationToken cancellationToken = default);
        void Add(ValidTimeDoctor validTimeDoctor);
    }
}