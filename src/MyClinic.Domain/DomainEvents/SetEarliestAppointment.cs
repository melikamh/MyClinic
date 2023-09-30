using MediatR;
using MyClinic.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinic.Domain.DomainEvents
{
    public sealed record SetEarliestAppointment(int DoctorId, int PationId, DaysOfWeek Day) : IRequest<Unit>;

}
