using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinic.Domain.Shared
{
    public class AppointmentSettings
    {
        public const int MaxOverLabAppoint = 2;
        public const int MinOverLabAppoint = 1;
        public const int MaxGeneralAppointmentsPerDay = 2;
        public const int MaxSpecialistAppointmentsPerDay = 3;
        public const int MaxAppointmentsPerPatientPerDay = 2;
        public const int MinAppointmentDurationGeneral = 5;
        public const int MaxAppointmentDurationGeneral = 15;
        public const int MinAppointmentDurationSpecialist = 10;
        public const int MaxAppointmentDurationSpecialist = 30;
    }
}
