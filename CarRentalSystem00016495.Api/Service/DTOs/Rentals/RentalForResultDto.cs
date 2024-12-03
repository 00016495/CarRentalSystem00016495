using CarRentalSystem00016495.Api.Domain.Entities;

namespace CarRentalSystem00016495.Api.Service.DTOs.Rentals;

public class RentalForResultDto
{
    public long Id { get; set; }
    public long CarId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalPrice { get; set; }
    public string RenterName { get; set; }
    public string RenterContact { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set;}
}
