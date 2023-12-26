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


        public AtivoController(AtivoService ativoService)
        {
            _ativoService = ativoService;
        }

        [HttpGet("precos-ativos")]
        public ActionResult ObterVariacaoPreco()
        {
            try
            {
                var variacao = _ativoService.CalcularVariacaoPreco();
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
