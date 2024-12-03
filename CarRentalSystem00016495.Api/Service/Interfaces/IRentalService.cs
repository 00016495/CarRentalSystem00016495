using CarRentalSystem00016495.Api.Service.DTOs.Rentals;

namespace CarRentalSystem00016495.Api.Service.Interfaces;

public interface IRentalService
{
    public Task<bool> DeleteByIdAsync(long id, CancellationToken cancellationToken = default);
    public Task<bool> AddAsync(RentalForCreationDto dto, CancellationToken cancellationToken = default);
    public Task<RentalForResultDto> RetrieveByIdAsync(long id, CancellationToken cancellationToken = default);
    public Task<IEnumerable<RentalForResultDto>> RetrieveAllAsync(CancellationToken cancellationToken = default);
    public Task<bool> UpdateAsync(long id, RentalForUpdateDto dto, CancellationToken cancellationToken = default);
}
