using MyClinic.Domain.Entities;

namespace MyClinic.Application.Logic
{

    /// <summary>
    /// پیاده سازی منطق اولین نوبت خالی
    /// </summary>
    public interface IAppointmentReserver
    {
        /// <summary>
        /// بررسی نوبت رزرو خالی 
        /// </summary>
        /// <param name="allList"></param>
        /// <param name="reservedList"></param>
        /// <returns></returns>
        ValidTimeDoctor CheckReservation(List<ValidTimeDoctor> allList, int patientId);


    }
}