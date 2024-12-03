using CarRentalSystem00016495.Api.Helpers;
using CarRentalSystem00016495.Api.Service.DTOs.Cars;
using CarRentalSystem00016495.Api.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalSystem00016495.Api.Controllers;

public class CarsController(ICarService carService) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken = default)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await carService.RetrieveAllAsync(cancellationToken)
        });
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await carService.RetrieveByIdAsync(id, cancellationToken)
        });
    [HttpPost]
    public async Task<IActionResult> PostAsync(CarForCreationDto dto, CancellationToken cancellationToken = default)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await carService.AddAsync(dto, cancellationToken)
        });
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id, CancellationToken cancellationToken = default)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await carService.DeleteByIdAsync(id, cancellationToken)
        });

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(long id, CarForUpdateDto dto, CancellationToken cancellationToken = default)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await carService.UpdateAsync(id, dto, cancellationToken)
        });


}
