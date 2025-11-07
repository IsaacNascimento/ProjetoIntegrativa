using Cotacao.Domain.Entities;
using Cotacao.Domain.Dtos;

namespace Cotacao.Domain.Interfaces
{
    public interface ICotacaoRepository : IBaseRepository<CotacaoEntity>
    {
        Task<List<CotacaoDTO>> ObterTodosComNomes();
        Task<CotacaoDTO> ObterPorMenorPreco();
    }
}
