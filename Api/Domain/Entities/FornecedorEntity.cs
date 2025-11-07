using System.ComponentModel.DataAnnotations.Schema;

namespace Cotacao.Domain.Entities
{
    public class FornecedorEntity : BaseEntity
    {
        [Column("cnpj")]
        public string Cnpj { get; set; }
    }
}
