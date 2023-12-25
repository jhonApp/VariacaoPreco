namespace VariacaoPreco.API.Models
{
    public class PedidoPorCliente
    {
        public int ClienteId { get; set; }
        public string NomeCliente { get; set; }
        public List<int> Pedidos { get; set; }
    }
}
