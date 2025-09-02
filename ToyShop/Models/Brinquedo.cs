using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToyStore.Models
{
    [Table("TDS_TB_Brinquedos")]
    public class Brinquedo
    {
        [Key]
        public int Id_brinquedo { get; set; }
        public string Nome_brinquedo { get; set; } 
        public string Tipo_brinquedo { get; set; }
        [Range(1, 14, ErrorMessage = "A classificação deve ser entre 1 e 14 anos." )]
        public int Classificacao { get; set; }
        public string Tamanho { get; set; }
        public decimal Preco { get; set; }
    }
}