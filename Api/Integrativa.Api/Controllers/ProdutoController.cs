using Integrativa.Domain.Entities;
using Integrativa.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Integrativa.Api.Controllers
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
        public async Task<IActionResult> RegistrarProduto([FromBody] Produto produto)
        {
            await _repository.Create(produto);
            return Ok("Cadastrado!");
        }
    }
}
