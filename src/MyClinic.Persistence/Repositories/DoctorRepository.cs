using MyClinic.Domain.Entities;
using MyClinic.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MyClinic.Persistence.Repositories;

internal sealed class DoctorRepository : IDoctorRepository
{
    private readonly MyClinicDbContext _dbContext;

    public DoctorRepository(MyClinicDbContext dbContext) =>
        _dbContext = dbContext;

    public void Add(Doctor doctor) =>
            _dbContext.Set<Doctor>().Add(doctor);
}
