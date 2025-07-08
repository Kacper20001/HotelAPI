using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationService.Application.Interfaces
{
    public interface IEventPublisher
    {
        Task PublishAsync<T>(T @event, string queueName);
    }
}
