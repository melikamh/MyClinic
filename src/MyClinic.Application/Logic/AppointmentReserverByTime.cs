using MyClinic.Domain.Entities;
using MyClinic.Domain.Enums;
using MyClinic.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinic.Application.Logic
{
    public class AppointmentReserverByTime : Setting, IAppointmentReserverByTime
    {

        public ValidTimeDoctor? CheckReservation(ValidTimeDoctor validTimeDoctor, List<Appointment> reservedList, TimeSpan time)
        {
            if (!reservedList.Any(p => p.ValidTimeDoctorId == validTimeDoctor.Id))
                return validTimeDoctor;

            return GetOverLabReserve(validTimeDoctor, reservedList);
        }

        /// <summary>
        ///  نوبت قابل رزرو در همپوشانی
        /// </summary>
        /// <param name="allList"></param>
        /// <param name="reservDoctorList"></param>
        /// <param name="reservedList"></param>
        /// <returns></returns>
        private static ValidTimeDoctor? GetOverLabReserve(ValidTimeDoctor validTimeDoctor, List<Appointment> reservedList)
        {
            var countReservationList = CountReservation(reservedList);
            var result = new ValidTimeDoctor();
            var doctorSpecialization = validTimeDoctor.Doctor.Specialization;
            var OverLabNumber = GetMaxAllowedOverLabAppointments(doctorSpecialization);

            if (countReservationList.FirstOrDefault(p=>p.Key==validTimeDoctor.Id).Value == OverLabNumber)
            {
                return result;
            }


            return validTimeDoctor;
        }

        /// <summary>
        /// لیست تایم های رزرو هر دکتر و تعداد رزرو در آن ساعت
        /// </summary>
        /// <param name="reservedList"></param>
        /// <returns></returns>
        private static Dictionary<int, int> CountReservation(List<Appointment> reservedList)
        {
            return reservedList.GroupBy(p => p.ValidTimeDoctorId).ToDictionary(group => group.Key, group => group.Count());
        }

       
    }
}
