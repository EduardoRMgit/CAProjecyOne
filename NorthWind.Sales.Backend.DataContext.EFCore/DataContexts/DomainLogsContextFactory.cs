using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using NorthWind.DomainLogs.EntityFrameworkCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Backend.DataContext.EFCore.DataContexts
{
    internal class DomainLogsContextFactory :
        IDesignTimeDbContextFactory<DomainLogsContext>
    {
        public DomainLogsContext CreateDbContext(string[] args)
        {
            var OptionsBuilder =
                new DbContextOptionsBuilder<DomainLogsContext>();

            OptionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=NorthWindLogsDB",
                b => b.MigrationsAssembly(
                    "NorthWind.Sales.Backend.DataContext.EFCore"));

            return new DomainLogsContext(OptionsBuilder.Options);
        }
    }
}
