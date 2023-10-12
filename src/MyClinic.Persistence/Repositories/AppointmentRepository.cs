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

    public sealed class AppointmentRepository : IAppointmentRepository
    {
        private readonly MyClinicDbContext _dbContext;

        public AppointmentRepository(MyClinicDbContext dbContext) =>
            _dbContext = dbContext;

        public void Add(Appointment appointment) =>
            _dbContext.Set<Appointment>().Add(appointment);

    }
}
