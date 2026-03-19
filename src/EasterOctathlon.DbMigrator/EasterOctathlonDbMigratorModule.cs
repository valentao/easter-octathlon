using EasterOctathlon.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace EasterOctathlon.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(EasterOctathlonEntityFrameworkCoreModule),
    typeof(EasterOctathlonApplicationContractsModule)
)]
public class EasterOctathlonDbMigratorModule : AbpModule
{
}
