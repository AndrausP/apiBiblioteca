using Biblioteca.Models;

namespace Biblioteca.Services
{
    public interface IServicesLivros
    {

        public IEnumerable<Livro> ObterTodos();
        public Livro? ObterPorId(int id);
        public void Criar(Livro livro);
        public void Atualizar(int id, Livro livro);
        public void Deletar(int id);
    }
}
