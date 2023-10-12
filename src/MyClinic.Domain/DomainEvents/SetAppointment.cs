
using MediatR;
using MyClinic.Domain.Entities;
using MyClinic.Domain.Enums;
using MyClinic.Domain.Shared;

namespace MyClinic.Domain.DomainEvents
{
    public sealed record SetAppointment(int doctorId, int pationId, DateTime date, TimeSpan StartTime) : IRequest<Result<Appointment>>;

}
