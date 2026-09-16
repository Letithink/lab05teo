using Lab05teo.Models;

namespace Lab05teo.Services;

public interface IGastoService
{
    Task<IEnumerable<Gasto>> GetAllAsync();
    Task<Gasto?> GetByIdAsync(int id);
    Task<Gasto> CreateAsync(Gasto gasto);
    Task<bool> UpdateAsync(int id, Gasto gasto);
    Task<bool> DeleteAsync(int id);
}