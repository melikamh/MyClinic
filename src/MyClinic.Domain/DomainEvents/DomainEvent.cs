using MyClinic.Domain.Primitives;

namespace MyClinic.Domain.DomainEvents
{
    public abstract record DomainEvent (int Id) : IDomainEvent;
}
