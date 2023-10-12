using MyClinic.Domain.Enums;
using MyClinic.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinic.Application.Logic
{
    public abstract class Setting
    {
        /// <summary>
        /// حداکثر همپوشانی هر تخصص
        /// </summary>
        /// <param name="doctorType"></param>
        /// <returns></returns>
        public static int GetMaxAllowedOverLabAppointments(DoctorType? doctorType)
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
