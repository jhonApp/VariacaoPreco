using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VariacaoPreco.Core.Entity
{
    [Table("Ativo")]
    public class Ativo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_ativo { get; set; }
        public string Simbolo { get; set; }
        public int Dia { get; set; }
        public DateTime Data_stamp { get; set; }
        public double? Valor_baixa { get; set; }
        public double? Valor_alta { get; set; }
        public double? Valor_fechamento { get; set; }
        public double? Valor_abertura { get; set; }
        public int? Volume { get; set; }
    }
}
