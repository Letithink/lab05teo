using Lab05teo.Repositories;

namespace Lab05teo.UnitOfWork;

public interface IUnitOfWork
{
    IEmpleadoRepository Empleados { get; }
    IClienteRepository Clientes { get; }
    IProyectoRepository Proyectos { get; }
    ITareaRepository Tareas { get; }
    IGastoRepository Gastos { get; }

    Task<int> SaveChangesAsync();
}


