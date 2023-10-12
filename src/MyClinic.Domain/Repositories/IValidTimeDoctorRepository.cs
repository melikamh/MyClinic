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

        /// <summary>
        /// لیست نوبت های بیمار در یک روز
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="date"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<ValidTimeDoctor>> GetPatientAppointmentByDate(int patientId, DateTime date, CancellationToken cancellationToken = default);

        /// <summary>
        /// لیست نوبتهای رزرو شده برای یک پزشک در یک روز
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="date"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<ValidTimeDoctor>> GetReservedAppointment(int patientId, DateTime date, CancellationToken cancellationToken = default);
        void Add(ValidTimeDoctor validTimeDoctor);
    }
}