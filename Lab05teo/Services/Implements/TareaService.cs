using Lab05teo.Models;
using Lab05teo.Services;
using Lab05teo.UnitOfWork;

namespace Lab05teo.Services.Implements;

public class TareaService : ITareaService
{
    private readonly IUnitOfWork _unitOfWork;

    public TareaService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Tarea>> GetAllAsync()
    {
        return await _unitOfWork.Tareas.GetAllAsync();
    }

    public async Task<Tarea?> GetByIdAsync(int id)
    {
        return await _unitOfWork.Tareas.GetByIdAsync(id);
    }

    public async Task<Tarea> CreateAsync(Tarea tarea)
    {
        await _unitOfWork.Tareas.AddAsync(tarea);
        await _unitOfWork.SaveChangesAsync();

        return tarea;
    }

    public async Task<bool> UpdateAsync(int id, Tarea tarea)
    {
        var tareaExistente = await _unitOfWork.Tareas.GetByIdAsync(id);

        if (tareaExistente == null)
            return false;

        tareaExistente.IdProyecto = tarea.IdProyecto;
        tareaExistente.IdEmpleado = tarea.IdEmpleado;
        tareaExistente.Nombre = tarea.Nombre;
        tareaExistente.Descripcion = tarea.Descripcion;
        tareaExistente.FechaInicio = tarea.FechaInicio;
        tareaExistente.FechaLimite = tarea.FechaLimite;
        tareaExistente.Estado = tarea.Estado;
        tareaExistente.Progreso = tarea.Progreso;

        _unitOfWork.Tareas.Update(tareaExistente);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var tarea = await _unitOfWork.Tareas.GetByIdAsync(id);

        if (tarea == null)
            return false;

        _unitOfWork.Tareas.Delete(tarea);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}