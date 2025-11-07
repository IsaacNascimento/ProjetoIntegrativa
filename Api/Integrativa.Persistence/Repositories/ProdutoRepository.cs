using Cotacao.Domain.Interfaces;
using Cotacao.Domain.Entities;
using Cotacao.Persistence.Context;

namespace Cotacao.Persistence.Repositories
{
    public class ProdutoRepository : BaseRepository<ProdutoEntity>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
