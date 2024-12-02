using CarRentalSystem00016495.Api.Domain.Commons;

namespace CarRentalSystem00016495.Api.Domain.Entities;

public class Car : Auditable
{
    public string Model { get; set; }
    public string Name { get; set; }
    public string Colour { get; set; }
    public int Year { get; set; }
    public decimal PricePerDay { get; set; }
    public bool IsAvailable { get; set; }
    public long Quantity { get; set; }
    public ICollection<Rental> Rentals { get; set; }

}
