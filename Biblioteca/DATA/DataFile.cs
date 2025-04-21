using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Biblioteca.DATA
{
    public class DataFile : DbContext
    {
        public DataFile(DbContextOptions<DataFile> options) : base(options) { }

        public DbSet<Livro> Livro { get; set; } = null!;
    }
}
