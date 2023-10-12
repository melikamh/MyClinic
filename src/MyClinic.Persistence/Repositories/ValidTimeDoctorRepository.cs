

using Microsoft.EntityFrameworkCore;
using MyClinic.Domain.Entities;
using MyClinic.Domain.Enums;
using MyClinic.Domain.Repositories;
using MyClinic.Persistence;
using MyClinic.Domain.Shared;
using System.Threading;
using MyClinic.Persistence.Specifications;

namespace MyClinic.Persistence.Repositories;

public sealed class ValidTimeDoctorRepository : IValidTimeDoctorRepository
{
    private readonly MyClinicDbContext _dbContext;

    public ValidTimeDoctorRepository(MyClinicDbContext dbContext) =>
        _dbContext = dbContext;

    public void Add(ValidTimeDoctor validTimeDoctor) =>
            _dbContext.Set<ValidTimeDoctor>().Add(validTimeDoctor);

    public async Task<List<ValidTimeDoctor>> GetAvailableDoctorByDate(int doctorId, DateTime date, CancellationToken cancellationToken = default)
    => await ApplySpecification(new GetAvailableDoctorsByDateSpecification(doctorId, date)).ToListAsync(cancellationToken);

    public async Task<List<ValidTimeDoctor>> GetPatientAppointmentByDate(int patientId, DateTime date, CancellationToken cancellationToken = default)
  => await ApplySpecification(new GetPatientAppointmentByDateSpecification(patientId, date)).ToListAsync(cancellationToken);


    public async Task<List<ValidTimeDoctor>> GetReservedAppointment(int doctorId, DateTime date, CancellationToken cancellationToken = default)
       => await ApplySpecification(new GetReservedAppointmentSpecification(doctorId, date)).ToListAsync(cancellationToken);



    private IQueryable<ValidTimeDoctor> ApplySpecification(
         Specification<ValidTimeDoctor> specification)
    {
        return SpecificationEvaluator.GetQuery(
            _dbContext.Set<ValidTimeDoctor>(),
            specification);
    }
}
