using Microsoft.EntityFrameworkCore;
using Cotacao.Domain.Entities;
    
namespace Cotacao.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<FornecedorEntity> fornecedor { get; set; }
        public DbSet<ProdutoEntity> produto { get; set; }
        public DbSet<CotacaoEntity> cotacao { get; set; }
    }
}
