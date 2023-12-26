using VariacaoPreco.Core.Entity;
using VariacaoPreco.Core.Interface;
using Newtonsoft.Json;

namespace VariacaoPreco.Core.Service
{
    public class AtivoService
    {
        private readonly IAtivo _ativo;

        public AtivoService(IAtivo ativo)
        {
            _ativo = ativo;
        }

        public double CalcularVariacaoPreco()
        {
            try
            {
                List<Ativo> ativosUltimos30Pregoes = _ativo.ObterAtivosUltimos30Pregoes();

                // Verificando se existem dados suficientes para calcular a variação
                if (ativosUltimos30Pregoes.Count >= 2)
                {
                    // Ordenando os ativos por data, do mais antigo para o mais recente
                    ativosUltimos30Pregoes = ativosUltimos30Pregoes.OrderBy(a => a.Data_stamp).ToList();

                    // Valor de abertura do primeiro dia
                    double valorAberturaPrimeiroDia = (double)ativosUltimos30Pregoes.First().Valor_abertura;

                    // Valor de abertura do último dia
                    double valorAberturaUltimoDia = (double)ativosUltimos30Pregoes.Last().Valor_abertura;

                    double variacaoPreco = valorAberturaUltimoDia - valorAberturaPrimeiroDia;

                    return variacaoPreco;
                }
                else
                {
                    throw new InvalidOperationException("Não há dados suficientes para calcular a variação de preço nos últimos 30 pregões.");
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao calcular a variação do preço.", ex);
            }
        }

        public List<PriceInfo> CalcularVariacoes()
        {
            try
            {
                var priceInfoList = new List<PriceInfo>();

                List<Ativo> ativosUltimos30Pregoes = _ativo.ObterAtivosUltimos30Pregoes();

                if (ativosUltimos30Pregoes.Count < 2)
                {
                    throw new InvalidOperationException("Não há dados suficientes para calcular a variação de preço nos últimos 30 pregões.");
                }

                for (int i = 0; i < ativosUltimos30Pregoes.Count; i++)
                {
                    Ativo ativoAtual = ativosUltimos30Pregoes[i];
                    double precoAtual = ativoAtual.Valor_fechamento != null ? (double)ativoAtual.Valor_fechamento : 0;

                    if (precoAtual != null)
                    {
                        double precoPrimeiraData = (double)ativosUltimos30Pregoes[0].Valor_fechamento;

                        // Condição para verificar se o valor do dia anterior é nulo
                        double precoDataAnterior = i > 0 && ativosUltimos30Pregoes[i - 1].Valor_fechamento != null ?
                                                   (double)ativosUltimos30Pregoes[i - 1].Valor_fechamento :
                                                   0;

                        PriceInfo priceInfo = CreatePriceInfo(ativoAtual, precoAtual, precoDataAnterior, precoPrimeiraData);
                        priceInfoList.Add(priceInfo);
                    }
                }

                return priceInfoList;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao calcular a variação do preço.", ex);
            }
        }

        private PriceInfo CreatePriceInfo(Ativo ativo, double precoAtual, double precoDataAnterior, double precoPrimeiraData)
        {
            DateTime data = ativo.Data_stamp.Date;

            return new PriceInfo
            {
                Dia = ativo.Dia,
                Data = data,
                Valor = ativo.Valor_fechamento,
                VariacaoDiaAnterior = CalculaVariacao(precoAtual, precoDataAnterior),
                VariacaoPrimeiroDia = CalculaVariacao(precoAtual, precoPrimeiraData)
            };
        }

        private string CalculaVariacao(double precoAtual, double precoReferencia)
        {
            try
            {
                double variacao = ((precoAtual - precoReferencia) / precoReferencia) * 100;
                return $"{Math.Round(variacao, 2)}%";
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao calcular a variação.", ex);
            }
        }

    }
}
