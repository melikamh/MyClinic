using MyClinic.Domain.Entities;
using MyClinic.Domain.Enums;
using MyClinic.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinic.Persistence.Specifications
{
    internal class GetReservedAppointmentSpecification : Specification<Appointment>
    {
        /// <summary>
        /// لیست نوبتهای رزرو شده برای یک پزشک در یک روز
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="date"></param>
        public GetReservedAppointmentSpecification(int doctorId, DateTime date)
           : base(appointment => appointment.ValidTimeDoctors.Any(p => p.Date.Date == date.Date) &&
                               appointment.ValidTimeDoctors.Any(p => p.DoctorId == doctorId))
        {
            AddInclude(appointment => appointment.ValidTimeDoctors);

        }

    }
}
