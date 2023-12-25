using Microsoft.EntityFrameworkCore;
using VariacaoPreco.Core.Entity;
using VariacaoPreco.Core.Interface;

namespace VariacaoPreco.Data.Repository
{
    public class AtivoRepository : IAtivo
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<Ativo> _ativos;

        public AtivoRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _ativos = dbContext.Set<Ativo>();
        }

        public void AdicionarAtivo(Ativo ativo)
        {
            _ativos.Add(ativo);
            _dbContext.SaveChanges();
        }

        public int GetAtivoID(Ativo ativo)
        {
            _dbContext.Entry(ativo).GetDatabaseValues();
            return ativo.ID_ativo;
        }
    }
}