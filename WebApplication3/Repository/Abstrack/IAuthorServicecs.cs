using WebApplication3.Models.Domain;

namespace WebApplication3.Repository.Abstrack
{
    public interface IAuthorServicecs 
    {
        bool Add(Author author);
        bool Update(Author author);
        bool Delete(int id);
        Author FindByID(int id);
        IEnumerable<Author> GetAll();
    }
}
