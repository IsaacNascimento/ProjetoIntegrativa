using Cotacao.Domain.Interfaces;
using Cotacao.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cotacao.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CotacaoController : Controller
    {
    private readonly ICotacaoRepository _repository;

        public CotacaoController(ICotacaoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var result = await _repository.ObterTodosComNomes();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarProduto([FromBody] CotacaoEntity cotacao)
        {
            await _repository.Create(cotacao);
            return Ok("Cadastrado!");
        }

        [HttpGet("ObterCotacaoDeMenorValor")]
        public async Task<IActionResult> ObterCotacaoDeMenorValor()
        {
            var result = await _repository.ObterPorMenorPreco();
            return Ok(result);
        }
    }
}
