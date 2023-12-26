using Newtonsoft.Json;
using VariacaoPreco.Core.Entity;
using VariacaoPreco.Core.Interface;

namespace VariacaoPreco.Core.Service
{
    public class IntegracaoService
    {
        private readonly IAtivo _ativo;

        public IntegracaoService(IAtivo ativo)
        {
            _ativo = ativo;
        }

        public async Task<List<Ativo>> ObterPrecoAtivo(string simbolo)
        {
            try
            {
                using var httpClient = new HttpClient();

                string apiUrl = $"https://query2.finance.yahoo.com/v8/finance/chart/" + simbolo;
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var chartData = JsonConvert.DeserializeObject<ChartData>(jsonResponse);
                    List<Ativo> ativos = new();

                    if (chartData != null)
                    {
                        ativos = ExtrairVariacoes(chartData);
                        if (ativos.Count != 0)
                        {
                            SalvarAtivos(ativos);
                        }
                    }
                    
                    return ativos;
                }
                else
                {
                    throw new HttpRequestException($"API request failed with status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private List<Ativo> ExtrairVariacoes(ChartData chartData)
        {
            try
            {
                List<Ativo> ativos = new List<Ativo>();

                foreach (var result in chartData.chart.result)
                {
                    for (int i = 0; i < result.timestamp.Count; i++)
                    {
                        var timestamp = result.timestamp[i];
                        var quote = result.indicators?.quote.FirstOrDefault();

                        if (quote != null && i < quote.low.Count && i < quote.high.Count &&
                            i < quote.open.Count && i < quote.close.Count && i < quote.volume.Count)
                        {
                            Ativo ativo = new Ativo
                            {
                                Simbolo = result.meta.symbol,
                                Dia = DateTimeOffset.FromUnixTimeSeconds(timestamp).DateTime.Day,
                                Data_stamp = DateTimeOffset.FromUnixTimeSeconds(timestamp).DateTime,
                                Valor_fechamento = quote.close[i],
                                Valor_baixa = quote.low[i],
                                Valor_alta = quote.high[i],
                                Valor_abertura = quote.open[i],
                                Volume = quote.volume[i]
                            };

                            ativos.Add(ativo);
                        }
                    }
                }

                return ativos;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Ativo ValidaAtivo(Ativo ativo)
        {
            try
            {
                return _ativo.GetAtivoByDateAndSimbolo(ativo.Data_stamp, ativo.Simbolo);
            }
            catch (Exception ex)
            {
                // Trate a exceção adequadamente
                throw new Exception("Error validação.", ex);
            }
        }

        private void SalvarAtivos(List<Ativo> ativos)
        {
            try
            {
                Ativo hasAtivo = ValidaAtivo(ativos.FirstOrDefault());

                if (hasAtivo == null)
                {
                    _ativo.Add(ativos);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving assets.", ex);
            }
        }
    }
}
