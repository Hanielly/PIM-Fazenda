using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechFarmSystem.Models
{
    public class Producao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [Display(Name = "Nome do Produto")]
        public string NomedoProduto { get; set; } = string.Empty;

        [Required(ErrorMessage = "A quantidade produzida é obrigatória.")]
        public int QuantidadeProduzida { get; set; }

        [Required(ErrorMessage = "A data da produção é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime DataProducao { get; set; }

        [StringLength(100, ErrorMessage = "As observações não podem ter mais que 100 caracteres.")]
        public string? Observacoes { get; set; }
    }
}
