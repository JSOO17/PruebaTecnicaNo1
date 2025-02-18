using Microsoft.EntityFrameworkCore;
using PruebaJR.Data;
using PruebaJR.Models;

namespace PruebaJR.Repositories.Imp
{
    public class AutorRepository : IAutorRepository
    {
        private readonly ApplicationDbContext _context;

        public AutorRepository(ApplicationDbContext context) => _context = context;

        public async Task Create(AutorViewModel model)
        {
            var autor = new Autor
            {
                Id = model.Id,
                Nombre = model.Name
            };

            await _context.Autors.AddAsync(autor);
            await _context.SaveChangesAsync();
        }

        public async Task<List<AutorViewModel>> GetAll()
        {
            var authors = await _context.Autors.ToListAsync();

            return authors.ConvertAll<AutorViewModel>(autor => new AutorViewModel
            {
                Id = autor.Id,
                Name = autor.Nombre ?? string.Empty
            });
        }
    }
}
