using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using ClassLibrary1.Interfaces;

namespace ClassLibrary1;

public class Flight : IAuditable
{
    public int Id { get; set; }
    [StringLength(11)]
    [Required]
    public string FlightNumber { get; internal set; }
    [Required]
    public  City DestinationFrom { get;internal set; }
    [Required]
    public City DestinationTo { get;internal set; }
    public IEnumerable<FlightDeparture> Departures { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    public static Flight Create(string flightNumber, City cityFrom, City cityTo)
    {
        if (!ValidateFlightId(flightNumber))
            throw new Exception("Invalid Flight ID");
        
        return new Flight
        {
            FlightNumber = flightNumber,
            DestinationFrom = cityFrom,
            DestinationTo = cityTo
        };
    }

    private static bool ValidateFlightId(string flightNumber)
    {
        string pattern = @"^[A-Z]{3} \d{5} [A-Z]{3}$";
        
        Regex regex = new Regex(pattern);
        
        return regex.IsMatch(flightNumber);
    }
}