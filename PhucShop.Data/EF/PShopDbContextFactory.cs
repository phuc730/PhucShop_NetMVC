using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PhucShop.Data.EF
{
    public class PShopDbContextFactory : IDesignTimeDbContextFactory<PShopDbContext>
    {   //Tao migration
        public PShopDbContext CreateDbContext(string[] args)
        {
            //truy cap vao appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            //lay ket noi db tu appsettings
            var connectionString = configuration.GetConnectionString("pShopSolutionDb");
            var optionsBuilder = new DbContextOptionsBuilder<PShopDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new PShopDbContext(optionsBuilder.Options);
        }
    }
}
