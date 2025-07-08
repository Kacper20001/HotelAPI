using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationService.Domain.Enums
{
    public enum ReservationStatus
    {
        Pending = 0,     // Oczekująca na potwierdzenie
        Confirmed = 1,   // Potwierdzona
        Cancelled = 2    // Anulowana
    }
}
