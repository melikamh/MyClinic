using MyClinic.Domain.Entities;

namespace MyClinic.Domain.Repositories
{
    public interface IValidTimeRepository
    {
        void Add(ValidTime validTime);
    }
}