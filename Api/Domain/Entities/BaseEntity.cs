using System.ComponentModel.DataAnnotations.Schema;

namespace Integrativa.Domain.Entities
{
    public class BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }
    }
}
