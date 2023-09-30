using MyClinic.Domain.Primitives;
using MediatR;


namespace MyClinic.Application.Abstractions.Messaging
{
    public interface IDomainEventHandler<TEvent> : INotificationHandler<TEvent>
      where TEvent : IDomainEvent
    {
    }

}
