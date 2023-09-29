
using MyClinic.Domain.Entities;
using MyClinic.Domain.Repositories;
using MyClinic.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace MyClinic.Persistence.Repositories;

public sealed class ValidTimeRepository : IValidTimeRepository
{
    private readonly MyClinicDbContext _dbContext;

    public ValidTimeRepository(MyClinicDbContext dbContext) =>
        _dbContext = dbContext;

    public void Add(ValidTime validTime) =>
            _dbContext.Set<ValidTime>().Add(validTime);
}
