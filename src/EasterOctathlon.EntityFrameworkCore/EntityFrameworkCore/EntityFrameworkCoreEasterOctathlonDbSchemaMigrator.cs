using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EasterOctathlon.Data;
using Volo.Abp.DependencyInjection;

namespace EasterOctathlon.EntityFrameworkCore;

public class EntityFrameworkCoreEasterOctathlonDbSchemaMigrator
    : IEasterOctathlonDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreEasterOctathlonDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the EasterOctathlonDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<EasterOctathlonDbContext>()
            .Database
            .MigrateAsync();
    }
}
