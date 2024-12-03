using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CarRentalSystem00016495.Api.Domain.Entities;
using CarRentalSystem00016495.Api.Data.IRepositories;
using CarRentalSystem00016495.Api.Service.Interfaces;
using CarRentalSystem00016495.Api.Service.DTOs.Rentals;
using CarRentalSystem00016495.Api.Service.Exceptions;

namespace CarRentalSystem00016495.Api.Service.Services;

public class RentalService(
    IMapper mapper, 
    IRepository<Car> carRepository,
    IRepository<Rental> rentalRepository) : IRentalService
{
    public async Task<bool> AddAsync(RentalForCreationDto dto, CancellationToken cancellationToken = default)
    {
        var car = await carRepository.SelectAsync(dto.CarId, cancellationToken);
        if (car is null)
            throw new CustomException(404, "Car not found");

        var mappedRental = mapper.Map<Rental>(dto);
        mappedRental.CreatedAt = DateTime.UtcNow;
        await rentalRepository.InsertAsync(mappedRental);

        return await rentalRepository.SaveChangeAsync(cancellationToken);
    }

    public async Task<bool> DeleteByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        var rental = await rentalRepository.SelectAll()
            .Where(r => r.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (rental is null)
            throw new CustomException(404, "Rental not found");

        await rentalRepository.DeleteAsync(id, cancellationToken);
        return await rentalRepository.SaveChangeAsync(cancellationToken);
    }

    public async Task<IEnumerable<RentalForResultDto>> RetrieveAllAsync(CancellationToken cancellationToken = default)
    {
        var rentals = await rentalRepository.SelectAll()
            .AsNoTracking()
            .ToListAsync();

        return mapper.Map<IEnumerable<RentalForResultDto>>(rentals);
    }

    public async Task<RentalForResultDto> RetrieveByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        var rental = await rentalRepository.SelectAll()
            .Where (r => r.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);
        if (rental is null)
            throw new CustomException(404, "Rental not found");

        return mapper.Map<RentalForResultDto>(rental);
    }

    public async Task<bool> UpdateAsync(long id, RentalForUpdateDto dto, CancellationToken cancellationToken = default)
    {
        var rental = await rentalRepository.SelectAsync(id, cancellationToken);
        if (rental is null)
            throw new CustomException(404, "Rental not found");

        var mappedRental = mapper.Map(dto, rental);
        mappedRental.UpdatedAt = DateTime.UtcNow;
        return await rentalRepository.SaveChangeAsync();
    }
}
