using CarRentalSystem00016495.Api.Domain.Commons;

namespace CarRentalSystem00016495.Api.Domain.Entities;

public class Rental : Auditable
{
    public long CarId { get; set; }
    public Car Car { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalPrice { get; set; }
    public string RenterName { get; set; }
    public string RenterContact {  get; set; }
}
