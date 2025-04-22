using Biblioteca.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    [ApiController]
    [Route("api/Biblioteca")]
    public class LivroController : ControllerBase
    {
        private readonly IServicesLivros _servicesLivros;

       
        public LivroController(IServicesLivros servicesLivros)
        {
            _servicesLivros = servicesLivros;
        }

       

        [HttpGet("ObterTodos")]
        public IActionResult ObterTodos()
        {
            var livros = _servicesLivros.ObterTodos();
            return Ok(new
            {
                mensagem = "Sucesso",
                quantidade = livros.Count(),
                livros = livros
            });
        }

        [HttpGet("ObterPorId/{id}")]
        public IActionResult ObterPorId(int id)
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
        public IActionResult Criar([FromBody] Models.Livro livro)
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
        public IActionResult Atualizar(int id, [FromBody] Models.Livro livro)
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
        public IActionResult Deletar(int id)
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
