using Biblioteca.DATA;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Biblioteca.Services
{
    public class ServicesLivros : IServicesLivros
    {
        private readonly DataFile _dataFile;
        public ServicesLivros(DataFile dataFile) { 
            _dataFile = dataFile;
        }
        void IServicesLivros.Atualizar(int id, Livro livro)
        {
            var existente = _dataFile.Livro.Find(id);
            if (existente == null) return;
            existente.Autor = livro.Autor;
            existente.Titulo = livro.Titulo;
            existente.Ano = livro.Ano;
            existente.Genero = livro.Genero;
        }

        void IServicesLivros.Criar(Livro livro)
        {
            _dataFile.Livro.Add(livro); 
            _dataFile.SaveChanges();

        }

        void IServicesLivros.Deletar(int id)
        {
            var livro = _dataFile.Livro.Find(id);
            if (livro == null) return;

            _dataFile.Livro.Remove(livro);
            _dataFile.SaveChanges();
        }

        Livro? IServicesLivros.ObterPorId(int id)
        {
           return _dataFile.Livro.Find(id);
        }

        IEnumerable<Livro> IServicesLivros.ObterTodos()
        {
            return _dataFile.Livro.AsNoTracking().ToList();
        }
    }
}
