using System.ComponentModel.DataAnnotations.Schema;

namespace Cotacao.Domain.Entities
{
    public class CotacaoEntity : BaseEntity
    {
        [Column("data")]
        public DateTime Data { get; set; }

        [Column("fornecedorid")]
        public int FornecedorId { get; set; }

        [Column("produtoid")]
        public int ProdutoId { get; set; }

        [Column("preco")]
        public decimal Preco { get; set; }

        [ForeignKey("FornecedorId")]
        public virtual FornecedorEntity Fornecedor { get; set; }

        [ForeignKey("ProdutoId")]
        public virtual ProdutoEntity Produto { get; set; }
    }
}
