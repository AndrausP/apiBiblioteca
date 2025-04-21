namespace Biblioteca.Models
{
    public class Livro
    {
        public int ID { get; set; }
        public string Autor { get; set; } = null!;
        public string Titulo { get; set; } = null!;
        public int Ano { get; set; }
        public string Genero { get; set; } = null!;

    }

}
