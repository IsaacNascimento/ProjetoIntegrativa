using Cotacao.Domain.Entities;
using Cotacao.Domain.Interfaces;
using Cotacao.Persistence.Context;
using Cotacao.Domain.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Cotacao.Persistence.Repositories
{
    public class CotacaoRepository : BaseRepository<CotacaoEntity>, ICotacaoRepository
    {
        public CotacaoRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<CotacaoDTO>> ObterTodosComNomes()
        {
            return await DbContext.cotacao
                .Include(c => c.Produto)
                .Include(c => c.Fornecedor)
                .Select(c => new CotacaoDTO
                {
                    Id = c.Id,
                    ProdutoId = c.ProdutoId,
                    FornecedorId = c.FornecedorId,
                    Preco = c.Preco,
                    Data = c.Data,
                    NomeProduto = c.Produto.Nome,
                    NomeFornecedor = c.Fornecedor.Nome
                })
                .ToListAsync();
        }

        public async Task<CotacaoDTO> ObterPorMenorPreco()
        {
            var menorCotacao = await DbContext.cotacao
                .Include(c => c.Produto)   
                .Include(c => c.Fornecedor)
                .OrderBy(c => c.Preco)
                .Select(c => new CotacaoDTO
                {
                   Id = c.Id,
                   ProdutoId = c.ProdutoId,
                   FornecedorId = c.FornecedorId,
                   Preco = c.Preco,
                   Data = c.Data,
                   NomeProduto = c.Produto.Nome,
                   NomeFornecedor = c.Fornecedor.Nome
                })
                .FirstOrDefaultAsync();
            
            return menorCotacao;
        }
    }
}
