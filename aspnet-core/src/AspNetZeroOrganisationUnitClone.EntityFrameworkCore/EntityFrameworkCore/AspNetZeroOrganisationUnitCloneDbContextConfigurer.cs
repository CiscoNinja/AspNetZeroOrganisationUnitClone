using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AspNetZeroOrganisationUnitClone.EntityFrameworkCore
{
    public static class AspNetZeroOrganisationUnitCloneDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AspNetZeroOrganisationUnitCloneDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<AspNetZeroOrganisationUnitCloneDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
