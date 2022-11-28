using Module4HW4.Data;
using Module4HW4.Data.Entities;

namespace Module4HW4;

public class App
{
    private readonly ApplicationsDbContext _dbContext;

    public App(ApplicationsDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}