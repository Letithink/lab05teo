using Lab05teo.Models;

namespace Lab05teo.Repositories.Implements;

public class ProyectoRepository : GenericRepository<Proyecto>, IProyectoRepository
{
    public ProyectoRepository(BdCaso2Context context)
        : base(context)
    {
    }
}