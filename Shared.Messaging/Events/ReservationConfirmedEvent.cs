using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Messaging.Events
{
    public class ReservationConfirmedEvent
    {
        public Guid ReservationId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime ConfirmedAt { get; set; }
    }
}
