using CarRentalSystem00016495.Api.Service.DTOs.Cars;

namespace CarRentalSystem00016495.Api.Service.Interfaces;

public interface ICarService
{
    public Task<bool> DeleteByIdAsync(long id, CancellationToken cancellationToken = default);
    public Task<bool> AddAsync(CarForCreationDto dto, CancellationToken cancellationToken = default);
    public Task<CarForResultDto> RetrieveByIdAsync(long id, CancellationToken cancellationToken = default);
    public Task<bool> UpdateAsync(long id, CarForUpdateDto dto, CancellationToken cancellationToken = default);
    public Task<IEnumerable<CarForResultDto>> RetrieveAllAsync(CancellationToken cancellationToken = default);
}
