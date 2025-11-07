
using System.ComponentModel.DataAnnotations.Schema;

namespace Integrativa.Domain.Entities
{
    public sealed class Cotacao : BaseEntity
    {
        [Column("data")]
        public DateTime Data { get; set; }

        [Column("fornecedorid")]
        public int FornecedorId { get; set; }

        [Column("produtoid")]
        public int ProdutoId { get; set; }

        [Column("preco")]
        public decimal Preco { get; set; }
    }
}
