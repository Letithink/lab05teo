using Lab05teo.Models;

namespace Lab05teo.Services;

public interface IProyectoService
{
    Task<IEnumerable<Proyecto>> GetAllAsync();
    Task<Proyecto?> GetByIdAsync(int id);
    Task<Proyecto> CreateAsync(Proyecto proyecto);
    Task<bool> UpdateAsync(int id, Proyecto proyecto);
    Task<bool> DeleteAsync(int id);
}