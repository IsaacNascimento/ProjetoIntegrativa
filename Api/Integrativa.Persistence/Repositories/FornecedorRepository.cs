using Cotacao.Domain.Entities;
using Cotacao.Domain.Interfaces;
using Cotacao.Persistence.Context;

namespace Cotacao.Persistence.Repositories
{
    public class FornecedorRepository : BaseRepository<FornecedorEntity>, IFornecedorRepository
    {
        public FornecedorRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
