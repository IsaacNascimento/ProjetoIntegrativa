using Integrativa.Domain.Entities;
using Integrativa.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Integrativa.Api.Controllers
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
            var result = await _repository.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarProduto([FromBody] Cotacao cotacao)
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
