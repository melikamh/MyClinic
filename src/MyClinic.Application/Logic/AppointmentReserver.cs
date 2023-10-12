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
    public class AppointmentReserver : IAppointmentReserver
    {

        public ValidTimeDoctor? CheckReservation(List<ValidTimeDoctor> allList, List<Appointment> reservedList)
        {
            var reservDoctorList = reservedList.SelectMany(p => p.ValidTimeDoctors).ToList();
            var freeTime = allList.Except(reservDoctorList);

            if (freeTime.Count() >= 1)
            {
                return freeTime.FirstOrDefault();
            }

            return GetfirstOverLabTime(allList, reservDoctorList, reservedList);
        }

        /// <summary>
        /// اولین نوبت قابل رزرو در همپوشانی
        /// </summary>
        /// <param name="allList"></param>
        /// <param name="reservDoctorList"></param>
        /// <param name="reservedList"></param>
        /// <returns></returns>
        private static ValidTimeDoctor? GetfirstOverLabTime(List<ValidTimeDoctor> allList, List<ValidTimeDoctor> reservDoctorList, List<Appointment> reservedList)
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

        /// <summary>
        /// حداکثر همپوشانی هر تخصص
        /// </summary>
        /// <param name="doctorType"></param>
        /// <returns></returns>
        private static int GetMaxAllowedOverLabAppointments(DoctorType? doctorType)
        {

            var maxOverLabAppointments = new Dictionary<DoctorType, int>
                {
                    { DoctorType.General, AppointmentSettings.MaxGeneralAppointmentsPerDay },
                    { DoctorType.Specialist, AppointmentSettings.MaxSpecialistAppointmentsPerDay },
                    // Add new DoctorType values here
                };

            if (maxOverLabAppointments.TryGetValue(doctorType ?? DoctorType.General, out var maxAllowedAppointments))
            {
                return maxAllowedAppointments;
            }

            return 0;
        }
    }
}
