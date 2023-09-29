using MyClinic.Domain.Entities;
using System.Linq.Expressions;

namespace MyClinic.Domain.Repositories
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> FindBy(Expression<Func<Appointment, bool>> predicate);
        void Add(Appointment appointment);
    }
}