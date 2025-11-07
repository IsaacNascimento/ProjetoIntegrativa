using Integrativa.Domain.Entities;
using Integrativa.Domain.Interfaces;
using Integrativa.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrativa.Persistence.Repositories
{
    public class CotacaoRepository : BaseRepository<Cotacao>, ICotacaoRepository
    {
        public CotacaoRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Cotacao> ObterPorMenorPreco()
        {
            var menorCotacao = await DbContext.cotacao
                .OrderBy(x => x.Preco)
                .FirstOrDefaultAsync();
            return menorCotacao;
        }
    }
}
