using Microsoft.EntityFrameworkCore;
using VariacaoPreco.Data.Interface;

namespace VariacaoPreco.Data
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly IConfiguration _configuration;

        public DbContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AppDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("VariacaoAWS"));

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
