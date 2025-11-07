using Cotacao.Domain.Entities;
using Cotacao.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cotacao.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _repository;

        public ProdutoController(IProdutoRepository repository)
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
        public async Task<IActionResult> RegistrarProduto([FromBody] ProdutoEntity produto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new ProdutoEntity { Nome = produto.Nome };
            await _repository.Create(entity);
            return Ok("Cadastrado!");
        }
    }
}
