using Microsoft.EntityFrameworkCore;
using PruebaJR.Data;
using PruebaJR.Models;

namespace PruebaJR.Repositories.Imp
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context) => _context = context;

        public async Task Create(BookViewModelCreating model)
        {
            var book = new Libro
            {
                Id = model.Id,
                AutorId = model.AutorId,
                Titulo = model.Title ?? string.Empty,
            };

            await _context.Libros.AddAsync(book);

            await _context.SaveChangesAsync();
        }

        public async Task<List<BookViewModel>> GetAll()
        {
            var books = await _context.Libros.Include("Autor").ToListAsync();

            return books.ConvertAll<BookViewModel>(book => new BookViewModel
            {
                Id = book.Id,
                AutorId = book.AutorId,
                AutorName = book.Autor.Nombre ?? string.Empty,
                Title = book.Titulo ?? string.Empty,
            });
        }
    }
}
