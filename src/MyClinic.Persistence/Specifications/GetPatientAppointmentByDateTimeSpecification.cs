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
    internal class GetPatientAppointmentByDateTimeSpecification : Specification<ValidTimeDoctor>
    {
        /// <summary>
        /// لیست نوبت های بیمار در یک روز
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="date"></param>
        public GetPatientAppointmentByDateTimeSpecification(int patientId, DateTime date, TimeSpan startTime)
           : base(validTimeDoctor => validTimeDoctor.Appointment.Any(p => p.PatientId == patientId) &&
                  validTimeDoctor.StartTime == startTime &&
                               validTimeDoctor.Date.Date == date.Date)
        {
            AddInclude(validTimeDoctor => validTimeDoctor.Appointment);

        }

    }
}
