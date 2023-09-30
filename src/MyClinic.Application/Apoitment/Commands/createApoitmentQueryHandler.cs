using MediatR;
using MyClinic.Application.Abstractions.Messaging;
using MyClinic.Domain.DomainEvents;
using MyClinic.Domain.Repositories;
using MyClinic.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinic.Application.Apoitment.Commands
{
    internal sealed class CreateApoitmentQueryHandler : IRequestHandler<SetEarliestAppointment,Unit>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public CreateApoitmentQueryHandler(IAppointmentRepository appointmentRepository) =>
            _appointmentRepository = appointmentRepository;

        public async Task<Unit> Handle(SetEarliestAppointment request, CancellationToken cancellationToken)
        {
            //some conditions 
            //then insert
            return Unit.Value;
        }
    }
}
