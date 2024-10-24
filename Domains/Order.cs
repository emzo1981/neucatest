using ClassLibrary1.Interfaces;

namespace ClassLibrary1;

public class Order : IAuditable
{
    public int Id { get; set; }
    public decimal BasePrice { get; internal set; }
    public decimal FinalPrice { get; internal set; }

    //ta sekcja własciowosci została powtorzona aby uniknac zmian wstecznych w zamowieniach gdyby ktos zmienił wartosci w FlightDeparture
    public int CurrencyId { get; internal set; }
    public Currency Currency { get; internal set; }

    public DayOfWeek DayOfWeek { get; internal set; }
    public DateTime Hour { get; internal set; }

    public IEnumerable<Discount> Discounts { get; internal set; }
    public int TenantId { get; internal set; }
    public Tenant Tenant { get; internal set; }
    public int FlightId { get; internal set; }
    public Flight Flight { get; internal set; }
    public int FlightDepartureId { get; internal set; }
    public FlightDeparture FlightDeparture { get; internal set; }

    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public static Order Create(FlightDeparture flightDeparture, List<Discount> discountList, Tenant tenant)
    {
        var order = new Order
        {
            FlightDeparture = flightDeparture,
            Currency = flightDeparture.Currency,
            Flight = flightDeparture.Flight,
            DayOfWeek = flightDeparture.DayOfWeek,
            Hour = flightDeparture.Hour,
            BasePrice = flightDeparture.Price,
            Tenant = tenant,
            FinalPrice = flightDeparture.Price
        };
        if (!discountList.Any())
            return order;

        var finalPrice = flightDeparture.Price;
        var discountsUsed = new List<Discount>();
        foreach (var discount in discountList)
        {
            var difference = finalPrice - discount.Value;
            if (difference < 20)
                break;
            finalPrice -= discount.Value;
            discountsUsed.Add(discount);
        }

        order.FinalPrice = finalPrice;
        if (tenant.TenantGroup == TenantGroupEnum.GroupA)
            order.Discounts = discountsUsed;
        return order;
    }
}