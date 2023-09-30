﻿

using MyClinic.Domain.Entities;
using MyClinic.Domain.Enums;
using MyClinic.Domain.Repositories;
using MyClinic.Persistence;

namespace MyClinic.Persistence.Repositories;

internal sealed class ValidTimeDoctorRepository : IValidTimeDoctorRepository
{
    private readonly MyClinicDbContext _dbContext;

    public ValidTimeDoctorRepository(MyClinicDbContext dbContext) =>
        _dbContext = dbContext;

    public void Add(ValidTimeDoctor validTimeDoctor) =>
            _dbContext.Set<ValidTimeDoctor>().Add(validTimeDoctor);

    public Task<List<ValidTimeDoctor>> DoctorAvailAble(int doctorId, DaysOfWeek Day, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
