using PruebaJR.Models;

namespace PruebaJR.Repositories
{
    public interface IAutorRepository
    {
        Task<List<AutorViewModel>> GetAll();
        Task Create(AutorViewModel model);
    }
}
