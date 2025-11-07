using Microsoft.EntityFrameworkCore;
using Integrativa.Domain.Entities;

namespace Integrativa.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Fornecedor> fornecedor { get; set; }
        public DbSet<Produto> produto { get; set; }
        public DbSet<Cotacao> cotacao { get; set; }
    }
}
