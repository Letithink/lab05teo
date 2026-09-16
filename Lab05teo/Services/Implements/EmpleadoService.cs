using Lab05teo.Models;
using Lab05teo.Services;
using Lab05teo.UnitOfWork;

namespace Lab05teo.Services.Implements;

public class EmpleadoService : IEmpleadoService
{
    private readonly IUnitOfWork _unitOfWork;

    public EmpleadoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Empleado>> GetAllAsync()
    {
        return await _unitOfWork.Empleados.GetAllAsync();
    }

    public async Task<Empleado?> GetByIdAsync(int id)
    {
        return await _unitOfWork.Empleados.GetByIdAsync(id);
    }

    public async Task<Empleado> CreateAsync(Empleado empleado)
    {
        await _unitOfWork.Empleados.AddAsync(empleado);
        await _unitOfWork.SaveChangesAsync();

        return empleado;
    }

    public async Task<bool> UpdateAsync(int id, Empleado empleado)
    {
        var empleadoExistente = await _unitOfWork.Empleados.GetByIdAsync(id);

        if (empleadoExistente == null)
            return false;

        empleadoExistente.Nombre = empleado.Nombre;
        empleadoExistente.Apellido = empleado.Apellido;
        empleadoExistente.Correo = empleado.Correo;
        empleadoExistente.Cargo = empleado.Cargo;
        empleadoExistente.Telefono = empleado.Telefono;

        _unitOfWork.Empleados.Update(empleadoExistente);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var empleado = await _unitOfWork.Empleados.GetByIdAsync(id);

        if (empleado == null)
            return false;

        _unitOfWork.Empleados.Delete(empleado);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}