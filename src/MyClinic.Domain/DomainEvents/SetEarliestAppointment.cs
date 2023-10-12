using MediatR;
using MyClinic.Domain.Entities;
using MyClinic.Domain.Enums;
using MyClinic.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinic.Domain.DomainEvents
{
    public sealed record SetEarliestAppointment(int doctorId, int pationId, DateTime date) : IRequest<Result<Appointment>>;

}
