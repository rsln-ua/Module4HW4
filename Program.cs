using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Module4HW4;
using Module4HW4.Data;

IConfiguration config = new ConfigurationBuilder().AddJsonFile("config.json").Build();
var connectionString = config.GetConnectionString("DefaultConnection");

var serviceCollection = new ServiceCollection();

serviceCollection
    .AddDbContextFactory<ApplicationsDbContext>(opts => opts.UseNpgsql(connectionString))
    .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
    .AddTransient<App>();

var app = serviceCollection.BuildServiceProvider().GetService<App>();