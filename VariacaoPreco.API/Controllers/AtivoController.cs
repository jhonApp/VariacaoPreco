using Microsoft.AspNetCore.Mvc;
using VariacaoPreco.API.Models;
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

        //[HttpGet("precos-ativos")]
        //public ActionResult<List<Ativo>> ObterPrecoAtivo()
        //{
        //    var ativos = _ativoService.ObterPrecoAtivo();

        //    return Ok(ativos);
        //}

        //[HttpGet("quantidade-pedidos-por-cliente")]
        //public ActionResult<List<PedidoInfo>> ObterQuantidadePedidosPorCliente()
        //{
        //    var quantidadePedidos = _pedidoService.QuantidadePedidos();
        //    return Ok(quantidadePedidos);
        //}

        //[HttpGet("pedidos-por-cliente")]
        //public ActionResult<List<PedidoInfo>> PedidosPorCliente()
        //{
        //    var pedidosPorCliente = _pedidoService.PedidosPorCliente();
        //    return Ok(pedidosPorCliente);
        //}
    }
}
