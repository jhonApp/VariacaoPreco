using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VariacaoPreco.Core.Entity
{
    [Table("VariacaoPreco")]
    public class Variacao
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_variacao { get; set; }
        public int ID_ativo { get; set; }
        public int Dia { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public string VariacaoDiaAnterior { get; set; }
        public string VariacaoPrimeiraData { get; set; }

        [ForeignKey("ID_ativo")]
        public Ativo Ativo { get; set; }
    }
}
