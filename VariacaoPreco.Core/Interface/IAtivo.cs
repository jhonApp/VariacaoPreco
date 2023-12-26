using VariacaoPreco.Core.Entity;

namespace VariacaoPreco.Core.Interface
{
    public interface IAtivo
    {
        void Add(Ativo ativo);
        Ativo GetAtivoByDate(DateTime stamp);
        List<Variacao> GetAll();
        List<Ativo> ObterAtivosUltimos30Pregoes();

    }
}
