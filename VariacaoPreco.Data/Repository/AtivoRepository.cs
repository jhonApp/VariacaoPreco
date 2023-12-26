using Microsoft.EntityFrameworkCore;
using VariacaoPreco.Core.Entity;
using VariacaoPreco.Core.Interface;

namespace VariacaoPreco.Data.Repository
{
    public class AtivoRepository : IAtivo
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<Ativo> _ativos;
        private readonly DbSet<Variacao> _variacaos;

        public AtivoRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _ativos = dbContext.Set<Ativo>();
            _variacaos = dbContext.Set<Variacao>();
        }

        public void Add(Ativo ativo)
        {
            _ativos.Add(ativo);
            _dbContext.SaveChanges();
        }

        public List<Variacao> GetAll()
        {
            return _variacaos
                .Include(e => e.Ativo)
                .ToList();
        }

        public Ativo GetAtivoByDate(DateTime stamp)
        {
            return _ativos.FirstOrDefault(e => e.Data_stamp.Date == stamp.Date);
        }

        public int GetAtivoID(Ativo ativo)
        {
            _dbContext.Entry(ativo).GetDatabaseValues();
            return ativo.ID_ativo;
        }

        public List<Ativo> ObterAtivosUltimos30Pregoes()
        {
            var ativos = _dbContext.Ativos
                .OrderByDescending(a => a.Data_stamp)  // Ordenando os ativos pela data em ordem decrescente
                .Take(30)  // Limitando o resultado aos últimos 30 registros
                .ToList();

            return ativos;
        }
    }
}