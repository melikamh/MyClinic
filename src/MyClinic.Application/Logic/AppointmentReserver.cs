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
    public class AppointmentReserver :Setting, IAppointmentReserver
    {

        public ValidTimeDoctor? CheckReservation(List<ValidTimeDoctor> doctorTimes, int patientId)
        {
            var reservedList = doctorTimes.SelectMany(p => p.Appointment).ToList();
            var reserverdDoctorTime = doctorTimes.Where(p => reservedList.Where(x => x.PatientId == patientId).Select(x => x.ValidTimeDoctorId).ToList().Contains(p.Id)).ToList();
            var freeTime = doctorTimes.Except(reserverdDoctorTime);

            if (freeTime.Count() >= 1)
            {
                return freeTime.FirstOrDefault();
            }

            return GetfirstOverLabTime(reserverdDoctorTime, reservedList);
        }

        /// <summary>
        /// اولین نوبت قابل رزرو در همپوشانی
        /// </summary>
        /// <param name="allList"></param>
        /// <param name="reservDoctorList"></param>
        /// <param name="reservedList"></param>
        /// <returns></returns>
        private static ValidTimeDoctor? GetfirstOverLabTime(List<ValidTimeDoctor> reservDoctorList, List<Appointment> reservedList)
        {
            var countReservationList = CountReservation(reservedList);
            var result = new ValidTimeDoctor();
            var doctorSpecialization = reservDoctorList.FirstOrDefault()?.Doctor.Specialization;
            var OverLabNumber = GetMaxAllowedOverLabAppointments(doctorSpecialization);

            if (countReservationList.Count(p => p.Value >= AppointmentSettings.MaxOverLabAppoint) == OverLabNumber)
            {
                return result;
            }

            // اعمال عدم همپوشانی قرار ملاقات های یک بیمار
            // اعمال همپوشانی مجاز برای پزشک مربوطه با توجه به تخصص
            return reservDoctorList?.FirstOrDefault(p =>
                         p.ValidTimeId == countReservationList.OrderBy(x => x.Key)
                        .Where(z => !reservedList.Select(x => x.ValidTimeDoctorId).Contains(z.Key))
                        .FirstOrDefault(a => a.Value == AppointmentSettings.MinOverLabAppoint).Key);
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
