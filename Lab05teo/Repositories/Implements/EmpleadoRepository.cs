using Lab05teo.Models;

namespace Lab05teo.Repositories.Implements;

public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleadoRepository
{
    public EmpleadoRepository(BdCaso2Context context)
        : base(context)
    {
    }
}