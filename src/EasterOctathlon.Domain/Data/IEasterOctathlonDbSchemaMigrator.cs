using System.Threading.Tasks;

namespace EasterOctathlon.Data;

public interface IEasterOctathlonDbSchemaMigrator
{
    Task MigrateAsync();
}
