using Integrativa.Domain.Entities;
using Integrativa.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Integrativa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : Controller
    {
        private readonly IFornecedorRepository _repository;

        public FornecedorController(IFornecedorRepository repository)
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
        public async Task<IActionResult> RegistrarFornecedor([FromBody] Fornecedor fornecedor)
        {
            await _repository.Create(fornecedor);
            return Ok("Cadastrado!");
        }
    }
}
