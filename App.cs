using AutoMapper;
using Module4HW4.Data;

namespace Module4HW4;

public class App
{
    private readonly ApplicationsDbContext _dbContext;

    public App(ApplicationsDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
    }
}