using MyClinic.Api.Abstractions;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using MyClinic.Domain.Shared;
using MyClinic.Domain.DomainEvents;
using MyClinic.Api.Contracts;
using MyClinic.Domain.Entities;

namespace MyClinic.Api.Controller
{
    [Route("api/Appointments")]
    public sealed class AppointmentController : ApiController
    {
        public AppointmentController(ISender sender)
          : base(sender)
        {
        }

        [HttpPost("standard")]

        public async Task<IActionResult> SetAppointment([FromBody] SetAppointmentRequest request,
            CancellationToken cancellationToken)
        {
            var command = new SetAppointment(
                request.doctorId,
                request.pationId,
                request.date,
                request.StartTime
                );

            Result<Appointment> result = await Sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return HandleFailure(result);
            }

            return result.IsSuccess
               ? Ok(result.Value)
               : NotFound(result.Error);
        }

        [HttpPost("earliest")]
        public async Task<IActionResult> SetEarliestAppointment([FromBody] SetEarliestAppointmentRequest request,
            CancellationToken cancellationToken)
        {
            var command = new SetEarliestAppointment(
                request.doctorId,
                request.pationId,
                request.date
               
                );

            Result<Appointment> result = await Sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return HandleFailure(result);
            }

            return result.IsSuccess
               ? Ok(result.Value)
               : NotFound(result.Error);
        }
    }
}
