using Lab05teo.Models;
using Lab05teo.Repositories;
using Lab05teo.Repositories.Implements;

namespace Lab05teo.UnitOfWork.Implements;

public class UnitOfWork : IUnitOfWork
{
    private readonly BdCaso2Context _context;

    public IEmpleadoRepository Empleados { get; }
    public IClienteRepository Clientes { get; }
    public IProyectoRepository Proyectos { get; }
    public ITareaRepository Tareas { get; }
    public IGastoRepository Gastos { get; }

    public UnitOfWork(BdCaso2Context context)
    {
        _context = context;

        Empleados = new EmpleadoRepository(_context);
        Clientes = new ClienteRepository(_context);
        Proyectos = new ProyectoRepository(_context);
        Tareas = new TareaRepository(_context);
        Gastos = new GastoRepository(_context);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}