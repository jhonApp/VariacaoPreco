using VariacaoPreco.Core.Entity;

namespace VariacaoPreco.Core.Interface
{
    public interface IAtivo
    {
        void Add(List<Ativo> ativos);
        List<Variacao> GetAll();
        List<Ativo> ObterAtivosUltimos30Pregoes();
        List<Ativo> ObterAtivosUltimos30PregoesBySimbolo(string simbolo);
        Ativo GetAtivoByDateAndSimbolo(DateTime stamp, string simbolo);

    }
}
