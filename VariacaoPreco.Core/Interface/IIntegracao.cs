using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VariacaoPreco.Core.Entity;

namespace VariacaoPreco.Core
{
    public interface IIntegracao
    {
        Task<List<Ativo>> ObterPrecoAtivo(string simbolo);
    }
}
