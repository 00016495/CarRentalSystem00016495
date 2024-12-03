using CarRentalSystem00016495.Api.Service.DTOs.Rentals;

namespace CarRentalSystem00016495.Api.Service.DTOs.Cars;

public class CarForResultDto
{
    public long Id { get; set; }
    public string Model { get; set; }
    public string Name { get; set; }
    public string Colour { get; set; }
    public int Year { get; set; }
    public decimal PricePerDay { get; set; }
    public bool IsAvailable { get; set; }
    public long Quantity { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public ICollection<RentalForResultDto> Rentals { get; set; }
}
