using MyClinic.Domain.Entities;
using MyClinic.Domain.Enums;
using System.Linq.Expressions;

namespace MyClinic.Domain.Repositories
{
    public interface IAppointmentRepository
    {
        
        void Add(Appointment appointment);
    }
}