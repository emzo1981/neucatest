using ClassLibrary1.Interfaces;

namespace ClassLibrary1;

public class FlightDeparture : IAuditable
{
    public int Id { get; set; }
   
    public required DayOfWeek DayOfWeek { get; set; }
    public required DateTime Hour { get; set; }
    public required decimal Price { get; set; }
    public required int CurrencyId { get; set; }
    public required Currency Currency { get; set; }
    public required int FlightId { get; set; }
    public required Flight Flight { get; set; }
    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}