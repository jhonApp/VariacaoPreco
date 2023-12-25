using Microsoft.EntityFrameworkCore;
using VariacaoPreco.Core.Entity;

namespace VariacaoPreco.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Ativo> Ativos { get; set; }
        public DbSet<Variacao> VariacaoPrecos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }


}
