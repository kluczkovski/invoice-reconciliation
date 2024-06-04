using Ardalis.GuardClauses;
using EK.InvoiceReconciliation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EK.InvoiceReconciliation.Infrastructure;

public static class DependencyInjection
{

  public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration  configuration)
  {
    var connectionString = configuration.GetConnectionString("IRSConnection");

    Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

    services.AddDbContext<AppDbContext>(options =>
    {
      options.UseSqlServer(connectionString);
    });


    return services;
  }

}
