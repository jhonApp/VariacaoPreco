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
    }
}
