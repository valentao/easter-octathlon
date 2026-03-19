using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace EasterOctathlon.Data;

/* This is used if database provider does't define
 * IEasterOctathlonDbSchemaMigrator implementation.
 */
public class NullEasterOctathlonDbSchemaMigrator : IEasterOctathlonDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
