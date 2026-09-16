using Lab05teo.Models;

namespace Lab05teo.Services;

public interface IEmpleadoService
{
    Task<IEnumerable<Empleado>> GetAllAsync();
    Task<Empleado?> GetByIdAsync(int id);
    Task<Empleado> CreateAsync(Empleado empleado);
    Task<bool> UpdateAsync(int id, Empleado empleado);
    Task<bool> DeleteAsync(int id);
}