using MyClinic.Application.Abstractions;
using MyClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinic.Infrastructure.Service
{
    internal class EmailService : IEmailService
    {
        public Task SendAppointmentInfoEmailAsync(Appointment appointment, CancellationToken cancellationToken = default) =>
            Task.CompletedTask;
    }
}
