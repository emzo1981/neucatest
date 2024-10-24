using System.ComponentModel.DataAnnotations;
using ClassLibrary1.Interfaces;

namespace ClassLibrary1;

public class Flight : IAuditable
{
    public int Id { get; set; }
    [StringLength(11)]
    public required string FlightNumber { get; set; }
    [StringLength(256)]
    public required string CityFrom { get; set; }
    [StringLength(256)]
    public required string CityTo { get; set; }
    public required IEnumerable<FlightDeparture> Departures { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}