using Lab05teo.Models;

namespace Lab05teo.Repositories.Implements;

public class GastoRepository : GenericRepository<Gasto>, IGastoRepository
{
    public GastoRepository(BdCaso2Context context)
        : base(context)
    {
    }
}