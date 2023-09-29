using MediatR;

namespace MyClinic.Domain.Primitives
{
    public interface IDomainEvent : INotification
    {
        public int Id { get; init; }
    }
}