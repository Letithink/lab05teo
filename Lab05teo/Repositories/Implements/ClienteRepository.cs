using Lab05teo.Models;

namespace Lab05teo.Repositories.Implements;

public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
{
    public ClienteRepository(BdCaso2Context context)
        : base(context)
    {
    }
}