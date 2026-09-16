using Lab05teo.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab05teo.Repositories.Implements;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly BdCaso2Context _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(BdCaso2Context context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }
}