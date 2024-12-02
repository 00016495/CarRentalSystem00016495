using System.Linq.Expressions;

namespace CarRentalSystem00016495.Api.Data.IRepositories;

public interface IRepository<TEntity>
{
    public TEntity Update(TEntity entity);
    public Task<TEntity> SelectAsync(long id, CancellationToken cancellationToken = default);
    public Task<bool> SaveChangeAsync(CancellationToken cancellationToken = default);
    public IQueryable<TEntity> SelectAll(CancellationToken cancellationToken = default);
    public Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default);
    public Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default);

}
