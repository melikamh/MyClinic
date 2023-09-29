using MyClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinic.Persistence.Constants
{
    internal static class TableNames
    {
        internal const string Patient = nameof(Patient);
        internal const string Doctor = nameof(Doctor);
        internal const string ValidTime = nameof(ValidTime);
        internal const string ValidTimeDoctor = nameof(ValidTimeDoctor);
        internal const string Appointment = nameof(Appointment);

    }

}
