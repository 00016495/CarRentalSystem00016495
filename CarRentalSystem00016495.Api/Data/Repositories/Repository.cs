using Microsoft.EntityFrameworkCore;
using CarRentalSystem00016495.Api.Domain.Commons;
using CarRentalSystem00016495.Api.Data.DbContexts;
using CarRentalSystem00016495.Api.Data.IRepositories;

namespace CarRentalSystem00016495.Api.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    private readonly DbSet<TEntity> dbSet;
    private readonly AppDbContext dbContext;

    public Repository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
        this.dbSet = dbContext.Set<TEntity>();
    }
    public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        var entity = await this.dbSet.FirstOrDefaultAsync(e => e.Id == id);
        dbSet.Remove(entity);
        return true;
    }

    public async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
        => (await this.dbSet.AddAsync(entity, cancellationToken)).Entity;

    public async Task<bool> SaveChangeAsync(CancellationToken cancellationToken = default)
         => (await this.dbContext.SaveChangesAsync(cancellationToken) > 0);

    public IQueryable<TEntity> SelectAll(CancellationToken cancellationToken = default)
        => dbSet;
    public async Task<TEntity> SelectAsync(long id, CancellationToken cancellationToken = default)
        => await dbSet.FirstOrDefaultAsync(e => e.Id == id,cancellationToken);

    public TEntity Update(TEntity entity)
        => this.dbSet.Update(entity).Entity;
}
