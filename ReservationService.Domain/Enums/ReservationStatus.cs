namespace ReservationService.Domain.Enums
{
    public enum ReservationStatus
    {
        Pending = 0,     // Oczekująca na potwierdzenie
        Confirmed = 1,   // Potwierdzona
        Cancelled = 2    // Anulowana
    }
}
