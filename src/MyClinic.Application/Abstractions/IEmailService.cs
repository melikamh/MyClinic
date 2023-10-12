using MyClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinic.Application.Abstractions
{
    public interface IEmailService
    {
        Task SendAppointmentInfoEmailAsync(Appointment appointment, CancellationToken cancellationToken = default);
    }
}
