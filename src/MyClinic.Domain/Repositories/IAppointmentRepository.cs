using MyClinic.Domain.Entities;
using MyClinic.Domain.Enums;
using System.Linq.Expressions;

namespace MyClinic.Domain.Repositories
{
    public interface IAppointmentRepository
    {
        /// <summary>
        /// لیست نوبت های بیمار در یک روز
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="date"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<Appointment>> GetPatientAppointmentByDate(int patientId, DateTime date, CancellationToken cancellationToken = default);

        ///// <summary>
        ///// نوبت  بیمار در یک روز  ویک ساعت
        ///// </summary>
        ///// <param name="patientId"></param>
        ///// <param name="date"></param>
        ///// <param name="startTime"></param>
        ///// <param name="cancellationToken"></param>
        ///// <returns></returns>
        //Task<Appointment> GetPatientAppointmentByDateTime(int patientId, DateTime date,TimeSpan startTime, CancellationToken cancellationToken = default);

        /// <summary>
        /// لیست نوبتهای رزرو شده برای یک پزشک در یک روز
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="date"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<Appointment>> GetReservedAppointment(int patientId, DateTime date, CancellationToken cancellationToken = default);
        void Add(Appointment appointment);
    }
}