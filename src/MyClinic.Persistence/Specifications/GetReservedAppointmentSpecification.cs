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
    internal class GetReservedAppointmentSpecification : Specification<ValidTimeDoctor>
    {
        /// <summary>
        /// لیست نوبتهای رزرو شده برای یک پزشک در یک روز
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="date"></param>
        public GetReservedAppointmentSpecification(int doctorId, DateTime date)
           : base(validTimeDoctor => validTimeDoctor.Date.Date == date.Date &&
                               validTimeDoctor.DoctorId == doctorId)
        {
            AddInclude(validTimeDoctor => validTimeDoctor.Appointment);

        }

    }
}
