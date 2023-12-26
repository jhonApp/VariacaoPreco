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

        public void Add(List<Ativo> ativos)
        {
            foreach (var ativo in ativos)
            {
                _dbContext.Ativos.Add(ativo);
            }

            _dbContext.SaveChanges();
        }

        public List<Variacao> GetAll()
        {
            return _variacaos
                .Include(e => e.Ativo)
                .ToList();
        }

        public Ativo GetAtivoByDateAndSimbolo(DateTime stamp, string simbolo)
        {
            return _ativos.FirstOrDefault(e => e.Data_stamp.Date == stamp.Date && e.Simbolo == simbolo);
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

        public List<Ativo> ObterAtivosUltimos30PregoesBySimbolo(string simbolo)
        {
            var ativos = _dbContext.Ativos
                .Where(e => e.Simbolo == simbolo)
                .OrderByDescending(a => a.Data_stamp)  // Ordenando os ativos pela data em ordem decrescente
                .Take(30)  // Limitando o resultado aos últimos 30 registros
                .ToList();

            return ativos;
        }

    }
}