using CarRentalSystem00016495.Api.Helpers;
using CarRentalSystem00016495.Api.Service.DTOs.Cars;
using CarRentalSystem00016495.Api.Service.DTOs.Rentals;
using CarRentalSystem00016495.Api.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalSystem00016495.Api.Controllers;

public class RentalsController(IRentalService rentalService) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken = default)
    => Ok(new Response
      {
          StatusCode = 200,
          Message = "Success",
          Data = await rentalService.RetrieveAllAsync(cancellationToken)
      });
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    => Ok(new Response
    {
            StatusCode = 200,
            Message = "Success",
            Data = await rentalService.RetrieveByIdAsync(id, cancellationToken)
        });
    [HttpPost]
    public async Task<IActionResult> PostAsync(RentalForCreationDto dto, CancellationToken cancellationToken = default)
    => Ok(new Response
    {
            StatusCode = 200,
            Message = "Success",
            Data = await rentalService.AddAsync(dto, cancellationToken)
        });
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id, CancellationToken cancellationToken = default)
    => Ok(new Response
    {
            StatusCode = 200,
            Message = "Success",
            Data = await rentalService.DeleteByIdAsync(id, cancellationToken)
        });

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(long id, RentalForUpdateDto dto, CancellationToken cancellationToken = default)
    => Ok(new Response
    {
            StatusCode = 200,
            Message = "Success",
            Data = await rentalService.UpdateAsync(id, dto, cancellationToken)
        });
}
