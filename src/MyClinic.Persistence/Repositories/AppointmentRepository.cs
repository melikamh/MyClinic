using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyClinic.Domain.Entities;
using MyClinic.Domain.Enums;
using MyClinic.Domain.Repositories;
using MyClinic.Persistence;
using MyClinic.Persistence.Specifications;
using System.Linq.Expressions;

namespace MyClinic.Persistence.Repositories
{

    internal sealed class AppointmentRepository : IAppointmentRepository
    {
        private readonly MyClinicDbContext _dbContext;

        public AppointmentRepository(MyClinicDbContext dbContext) =>
            _dbContext = dbContext;

        public void Add(Appointment appointment) =>
            _dbContext.Set<Appointment>().Add(appointment);

        public async Task<List<Appointment>> GetPatientAppointmentByDate(int patientId, DateTime date, CancellationToken cancellationToken = default)
    => await ApplySpecification(new GetPatientAppointmentByDateSpecification(patientId, date)).ToListAsync(cancellationToken);

        //public async Task<Appointment> GetPatientAppointmentByDateTime(int patientId, DateTime date, TimeSpan startTime, CancellationToken cancellationToken = default)
        //    => await ApplySpecification(new GetPatientAppointmentByDateTimeSpecification(patientId, date,startTime)).FirstOrDefaultAsync(cancellationToken);


        public async Task<List<Appointment>> GetReservedAppointment(int doctorId, DateTime date, CancellationToken cancellationToken = default)
           => await ApplySpecification(new GetReservedAppointmentSpecification(doctorId, date)).ToListAsync(cancellationToken);

        private IQueryable<Appointment> ApplySpecification(
             Specification<Appointment> specification)
        {
            return SpecificationEvaluator.GetQuery(
                _dbContext.Set<Appointment>(),
                specification);
        }
    }
}
