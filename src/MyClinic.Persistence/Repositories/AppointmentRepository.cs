

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyClinic.Domain.Entities;
using MyClinic.Domain.Repositories;
using MyClinic.Persistence;
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

        public IEnumerable<Appointment> FindBy(Expression<Func<Appointment, bool>> predicate)
        {
            return _dbContext.Set<Appointment>().Where(predicate);
        }
    }
}
