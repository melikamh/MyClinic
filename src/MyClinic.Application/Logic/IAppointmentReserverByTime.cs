using MyClinic.Domain.Entities;

namespace MyClinic.Application.Logic
{

    /// <summary>
    /// پیاده سازی منطق اولین نوبت خالی
    /// </summary>
    public interface IAppointmentReserverByTime
    {
        /// <summary>
        /// بررسی نوبت رزرو خالی 
        /// </summary>
        /// <param name="allList"></param>
        /// <param name="reservedList"></param>
        /// <returns></returns>
        ValidTimeDoctor CheckReservation(ValidTimeDoctor allList, List<Appointment> reservedList, TimeSpan time);


    }
}