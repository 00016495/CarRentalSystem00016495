using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CarRentalSystem00016495.Api.Domain.Entities;
using CarRentalSystem00016495.Api.Service.DTOs.Cars;
using CarRentalSystem00016495.Api.Data.IRepositories;
using CarRentalSystem00016495.Api.Service.Exceptions;
using CarRentalSystem00016495.Api.Service.Interfaces;

namespace CarRentalSystem00016495.Api.Service.Services;

public class CarService(IMapper mapper, IRepository<Car> carRepository) : ICarService
{
    public async Task<bool> AddAsync(CarForCreationDto dto, CancellationToken cancellationToken = default)
    {
        var car = await carRepository.SelectAll()
            .Where(c => string.Equals(c.Name, dto.Name, StringComparison.OrdinalIgnoreCase))
            .FirstOrDefaultAsync();
        if (car is not null )
        {
            car.Quantity += dto.Quantity;
            car.UpdatedAt = DateTime.UtcNow;
            return await carRepository.SaveChangeAsync(cancellationToken);
        }

        var mappedCar = mapper.Map<Car>(dto);
        mappedCar.CreatedAt = DateTime.UtcNow;
        await carRepository.InsertAsync(mappedCar);
        return await carRepository.SaveChangeAsync(cancellationToken);
    }

    public async Task<bool> DeleteByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        var car = carRepository.SelectAsync(id, cancellationToken);
        if (car is null)
            throw new CustomException(404, "Car not found");

        await carRepository.DeleteAsync(id, cancellationToken);
        return await carRepository.SaveChangeAsync(cancellationToken);
    }

    public async Task<IEnumerable<CarForResultDto>> RetrieveAllAsync(CancellationToken cancellationToken = default)
    {
        var cars = await carRepository.SelectAll()
            .Include(c => c.Rentals)
            .ToListAsync(cancellationToken);

        return mapper.Map<IEnumerable<CarForResultDto>>(cars);
    }

    public async Task<CarForResultDto> RetrieveByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        var car = await carRepository.SelectAll()
            .Where(c => c.Id == id)
            .Include(c => c.Rentals)
            .FirstOrDefaultAsync(c => c.Id == id);
        if (car is null)
            throw new CustomException(404, "Car not found");

        return mapper.Map<CarForResultDto>(car);
    }

    public async Task<bool> UpdateAsync(long id, CarForUpdateDto dto, CancellationToken cancellationToken = default)
    {
        var car = await carRepository.SelectAsync(id, cancellationToken);
        if (car is null)
            throw new CustomException(404, "Car not found");

        var mappedCar = mapper.Map(dto, car);
        mappedCar.UpdatedAt = DateTime.Now;
        return await carRepository.SaveChangeAsync(cancellationToken);

    }
}
