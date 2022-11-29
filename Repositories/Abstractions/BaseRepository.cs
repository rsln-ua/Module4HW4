using AutoMapper;
using Module4HW4.Data;

namespace Module4HW4.Repositories.Abstractions;

public abstract class BaseRepository
{
    protected BaseRepository(ApplicationDbContext dbContext, IMapper mapper)
    {
        DbContext = dbContext;
        Mapper = mapper;
    }

    protected ApplicationDbContext DbContext { get; set; }

    protected IMapper Mapper { get; set; }
}