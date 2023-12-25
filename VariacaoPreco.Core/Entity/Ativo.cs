using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VariacaoPreco.Core.Entity
{
    [Table("Ativo")]
    public class Ativo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_ativo { get; set; }
        [MaxLength(100)] public string nome { get; set; }
    }
}
