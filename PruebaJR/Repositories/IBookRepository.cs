using PruebaJR.Models;

namespace PruebaJR.Repositories
{
    public interface IBookRepository
    {
        Task<List<BookViewModel>> GetAll();
        Task Create(BookViewModelCreating model);
    }
}
