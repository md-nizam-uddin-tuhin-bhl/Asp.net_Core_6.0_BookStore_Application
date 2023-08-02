using WebApplication3.Models.Domain;

namespace WebApplication3.Repository.Abstrack
{
    public interface IGenreService
    {
        bool Add(Genre genre);
        bool Update(Genre genre);
        bool Delete(int id);
        Genre FindByID(int id);
        IEnumerable<Genre> GetAll();
    }
}
