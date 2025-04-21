using Biblioteca.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Biblioteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly IServicesLivros _servicesLivros;
        public LivroController(IServicesLivros servicesLivros)
        {
            _servicesLivros = servicesLivros;

            [HttpGet("ObterTodos")]
            IActionResult ObterTodos()
            {
                var livros = _servicesLivros.ObterTodos();
                return Ok(new
                {
                    mensagem = "Sucesso",
                    quantidade = livros.Count(),
                    livros = livros
                }
                    );
            }
            [HttpGet("ObterPorId/{id}")]
            IActionResult ObterPorId(int id)
            {
                var livro = _servicesLivros.ObterPorId(id);
                if (livro == null)
                {
                    return NotFound(new
                    {
                        mensagem = "Livro não encontrado"
                    });
                }
                return Ok(new
                {
                    mensagem = "Sucesso",
                    livro = livro
                });
            }
            [HttpPost("Criar")]
            IActionResult Criar([FromBody] Models.Livro livro)
            {
                if (livro == null)
                {
                    return BadRequest(new
                    {
                        mensagem = "Livro inválido"
                    });
                }
             
                _servicesLivros.Criar(livro);
                return CreatedAtAction(nameof(ObterPorId), new { id = livro.ID }, livro);
            }
            [HttpPut("Atualizar/{id}")]
            IActionResult Atualizar(int id, [FromBody] Models.Livro livro)
            {
                if (livro == null)
                {
                    return BadRequest(new
                    {
                        mensagem = "Livro inválido"
                    });
                }
                var existente = _servicesLivros.ObterPorId(id);
                if (existente == null)
                {
                    return NotFound(new
                    {
                        mensagem = "Livro não encontrado"
                    });
                }
                _servicesLivros.Atualizar(id, livro);
                return NoContent();
            }
            [HttpDelete("Deletar/{id}")]
            IActionResult Deletar(int id)
            {
                var livro = _servicesLivros.ObterPorId(id);
                if (livro == null)
                {
                    return NotFound(new
                    {
                        mensagem = "Livro não encontrado"
                    });
                }
                _servicesLivros.Deletar(id);
                return NoContent();
            }
        }

    }
}
