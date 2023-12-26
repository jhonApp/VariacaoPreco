using Microsoft.AspNetCore.Mvc;
using VariacaoPreco.Core.Entity;
using VariacaoPreco.Core.Service;
//using VariacaoPreco.Data.Repository;

namespace VariacaoPreco.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtivoController : ControllerBase
    {
        private readonly AtivoService _ativoService;
        private readonly IntegracaoService _integracaoService;


        public AtivoController(AtivoService ativoService, IntegracaoService integracaoService)
        {
            _ativoService = ativoService;
            _integracaoService = integracaoService;
        }

        [HttpGet("consultar-ativos-simbolo")]
        public async Task<ActionResult> ConsultarAtivos(string simbolo)
        {
            try
            {
                var ativos = await _integracaoService.ObterPrecoAtivo(simbolo);
                return Ok(ativos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao consultar os ativos: {ex.Message}");
            }
        }


        [HttpGet("consultar-precos-ativos")]
        public ActionResult ObterVariacaoPreco(string simbolo)
        {
            try
            {
                var variacao = _ativoService.CalcularVariacoesBySimbolo(simbolo);
                return Ok(variacao);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao calcular a variação do preço: {ex.Message}");
            }
        }

        [HttpGet("variacao-preco-ativos")]
        public ActionResult ObterQuantidadePedidosPorCliente()
        {
            try
            {
                var precos = _ativoService.CalcularVariacoes();
                return Ok(precos);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Erro na consulta da variação de preços ativos: {ex.Message}");
            }
        }
    }
}
