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
    public sealed class SetAppointmentQueryHandler : IRequestHandler<SetAppointment, Result<Appointment>>
    {
        private readonly IAppointmentReserverByTime _appointmentReserver;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IValidTimeDoctorRepository _validTimeDoctorRepository;
        private readonly IUnitOfWork _unitOfWork;
        public SetAppointmentQueryHandler(IAppointmentRepository appointmentRepository,
            IAppointmentReserverByTime appointmentReserver,
            IValidTimeDoctorRepository validTimeDoctorRepository,
            IUnitOfWork unitOfWork)
        {
            _appointmentRepository = appointmentRepository;
            _validTimeDoctorRepository = validTimeDoctorRepository;
            _appointmentReserver = appointmentReserver;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Appointment>> Handle(SetAppointment request, CancellationToken cancellationToken)
        {
            //نوبت های تعریف شده برای پزشک در تاریخ مشخص 
            var doctorTimes = await _validTimeDoctorRepository.GetAvailableDoctorByDate(request.doctorId, request.date);

            if (doctorTimes.Count == 0 || !doctorTimes.Any(p => p.StartTime == request.StartTime))
                return Result.Failure<Appointment>(
                    DomainErrors.ReserveTimeDoctor.NotFound(request.date.Date.ToString()));
            // لیست رزرو شده توسط بیمار
            var reservedDoctorTime = await _validTimeDoctorRepository.GetPatientAppointmentByDate(request.pationId, request.date);
            var pationtList = reservedDoctorTime.SelectMany(p => p.Appointment).ToList();
            if (pationtList.Count > AppointmentSettings.MaxAppointmentsPerPatientPerDay)
                return Result.Failure<Appointment>(
                    DomainErrors.ValidAppointment.Notallowed(request.date.Date.ToString()));

            // بررسی رزر نوبت تکراری
            if (reservedDoctorTime.Any(p=> p.StartTime == request.StartTime))
                return Result.Failure<Appointment>(
                   DomainErrors.ValidAppointment.ExistBefor);

            var doctorTime = doctorTimes.FirstOrDefault(p => p.StartTime == request.StartTime);
            var allAppointment = doctorTimes.SelectMany(p=>p.Appointment).ToList();
            var reserve = _appointmentReserver.CheckReservation(doctorTime, allAppointment, request.StartTime);

            if (reserve == null)
                return Result.Failure<Appointment>(
                   DomainErrors.ReserveTimeDoctor.NotFound(request.date.Date.ToString()));

            var appointment = Appointment.Create(
                0,
                request.pationId,
                reserve.Id
            );
            _appointmentRepository.Add(appointment);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return appointment;
        }
    }
}
