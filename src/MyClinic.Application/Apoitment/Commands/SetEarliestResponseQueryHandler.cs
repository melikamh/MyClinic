using MediatR;
using MyClinic.Application.Abstractions.Messaging;
using MyClinic.Application.Logic;
using MyClinic.Domain.DomainEvents;
using MyClinic.Domain.Entities;
using MyClinic.Domain.Enums;
using MyClinic.Domain.Errors;
using MyClinic.Domain.Repositories;
using MyClinic.Domain.Shared;
using MyClinic.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyClinic.Application.Apoitment.Commands
{
    internal sealed class SetEarliestResponseQueryHandler : IRequestHandler<SetEarliestAppointment, Result<Appointment>>
    {
        private readonly IAppointmentReserver _appointmentReserver;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IValidTimeDoctorRepository _validTimeDoctorRepository;
        private readonly IUnitOfWork _unitOfWork;
        public SetEarliestResponseQueryHandler(IAppointmentRepository appointmentRepository,
            IAppointmentReserver appointmentReserver,
            IValidTimeDoctorRepository validTimeDoctorRepository,
            IUnitOfWork unitOfWork)
        {
            _appointmentRepository = appointmentRepository;
            _validTimeDoctorRepository = validTimeDoctorRepository;
            _appointmentReserver = appointmentReserver;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Appointment>> Handle(SetEarliestAppointment request, CancellationToken cancellationToken)
        {
            //نوبت های تعریف شده برای پزشک در تاریخ مشخص 
            var doctorTimes = await _validTimeDoctorRepository.GetAvailableDoctorByDate(request.DoctorId, request.date);

            if (doctorTimes.Count == 0)
                return Result.Failure<Appointment>(
                    DomainErrors.ValidTimeDoctor.NotFound(request.date.Date.ToString()));
            // لیست رزرو شده توسط بیمار
            var pationtList = await _appointmentRepository.GetPatientAppointmentByDate(request.PationId, request.date);
            if (pationtList.Count > AppointmentSettings.MaxAppointmentsPerPatientPerDay)
                return Result.Failure<Appointment>(
                    DomainErrors.ValidTimeDoctor.NotFound(request.date.Date.ToString()));

            var reserve = _appointmentReserver.CheckReservation(doctorTimes, pationtList);

            var appointment = Appointment.Create(
                0,
                request.PationId,
                reserve.Id
            );
            _appointmentRepository.Add(appointment);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return appointment;
        }
    }
}
