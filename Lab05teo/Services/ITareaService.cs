using Lab05teo.Models;

namespace Lab05teo.Services;

public interface ITareaService
{
    Task<IEnumerable<Tarea>> GetAllAsync();
    Task<Tarea?> GetByIdAsync(int id);
    Task<Tarea> CreateAsync(Tarea tarea);
    Task<bool> UpdateAsync(int id, Tarea tarea);
    Task<bool> DeleteAsync(int id);
}