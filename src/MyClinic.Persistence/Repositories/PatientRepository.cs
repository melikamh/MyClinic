
using MyClinic.Domain.Entities;
using MyClinic.Domain.Repositories;

namespace MyClinic.Persistence.Repositories;

internal sealed class PatientRepository : IPatientRepository
{
    private readonly MyClinicDbContext _dbContext;

    public PatientRepository(MyClinicDbContext dbContext) =>
        _dbContext = dbContext;

    public void Add(Patient patient) =>
            _dbContext.Set<Patient>().Add(patient);
}
