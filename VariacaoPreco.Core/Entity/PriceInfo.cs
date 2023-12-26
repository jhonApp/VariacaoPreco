using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariacaoPreco.Core.Entity
{
    public class PriceInfo
    {
        public int? Dia { get; set; }
        public DateTime? Data { get; set; }
        public double? Valor { get; set; }
        public string? VariacaoDiaAnterior{ get; set; }
        public string? VariacaoPrimeiroDia { get; set; }
    }
}
