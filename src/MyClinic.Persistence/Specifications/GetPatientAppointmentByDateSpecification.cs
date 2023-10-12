using MyClinic.Domain.Entities;
using MyClinic.Domain.Enums;
using MyClinic.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyClinic.Domain.Errors.DomainErrors;

namespace MyClinic.Persistence.Specifications
{
    internal class GetPatientAppointmentByDateSpecification : Specification<ValidTimeDoctor>
    {
        /// <summary>
        /// لیست نوبت های بیمار در یک روز
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="date"></param>
        public GetPatientAppointmentByDateSpecification(int patientId, DateTime date)
           : base(validTimeDoctor => validTimeDoctor.Appointment.Any(p => p.PatientId == patientId) &&
                               validTimeDoctor.Date.Date == date.Date)
        {
            AddInclude(validTimeDoctor => validTimeDoctor.Appointment);

        }

    }
}
