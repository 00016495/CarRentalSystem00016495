using CarRentalSystem00016495.Api.Domain.Entities;

namespace CarRentalSystem00016495.Api.Service.DTOs.Rentals;

public class RentalForCreationDto
{
    public long CarId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalPrice { get; set; }
    public string RenterName { get; set; }
    public string RenterContact { get; set; }
}
