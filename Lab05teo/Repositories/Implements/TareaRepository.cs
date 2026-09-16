using Lab05teo.Models;

namespace Lab05teo.Repositories.Implements;

public class TareaRepository : GenericRepository<Tarea>, ITareaRepository
{
    public TareaRepository(BdCaso2Context context)
        : base(context)
    {
    }
}