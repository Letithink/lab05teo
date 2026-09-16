using Lab05teo.Models;
using Lab05teo.Services;
using Lab05teo.UnitOfWork;

namespace Lab05teo.Services.Implements;

public class ProyectoService : IProyectoService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProyectoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Proyecto>> GetAllAsync()
    {
        return await _unitOfWork.Proyectos.GetAllAsync();
    }

    public async Task<Proyecto?> GetByIdAsync(int id)
    {
        return await _unitOfWork.Proyectos.GetByIdAsync(id);
    }

    public async Task<Proyecto> CreateAsync(Proyecto proyecto)
    {
        await _unitOfWork.Proyectos.AddAsync(proyecto);
        await _unitOfWork.SaveChangesAsync();

        return proyecto;
    }

    public async Task<bool> UpdateAsync(int id, Proyecto proyecto)
    {
        var proyectoExistente = await _unitOfWork.Proyectos.GetByIdAsync(id);

        if (proyectoExistente == null)
            return false;

        proyectoExistente.IdCliente = proyecto.IdCliente;
        proyectoExistente.IdResponsable = proyecto.IdResponsable;
        proyectoExistente.Nombre = proyecto.Nombre;
        proyectoExistente.Descripcion = proyecto.Descripcion;
        proyectoExistente.Objetivo = proyecto.Objetivo;
        proyectoExistente.FechaInicio = proyecto.FechaInicio;
        proyectoExistente.FechaFin = proyecto.FechaFin;
        proyectoExistente.Estado = proyecto.Estado;
        proyectoExistente.Presupuesto = proyecto.Presupuesto;

        _unitOfWork.Proyectos.Update(proyectoExistente);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var proyecto = await _unitOfWork.Proyectos.GetByIdAsync(id);

        if (proyecto == null)
            return false;

        _unitOfWork.Proyectos.Delete(proyecto);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}