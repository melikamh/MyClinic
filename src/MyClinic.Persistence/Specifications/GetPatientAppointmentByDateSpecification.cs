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
    internal class GetPatientAppointmentByDateSpecification : Specification<Appointment>
    {
        /// <summary>
        /// لیست نوبت های بیمار در یک روز
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="date"></param>
        public GetPatientAppointmentByDateSpecification(int patientId, DateTime date)
           : base(appointment => appointment.ValidTimeDoctors.Any(p => p.Date.Date == date.Date) &&
                               appointment.PatientID == patientId)
        {
            AddInclude(appointment => appointment.ValidTimeDoctors);

        }

    }
}
