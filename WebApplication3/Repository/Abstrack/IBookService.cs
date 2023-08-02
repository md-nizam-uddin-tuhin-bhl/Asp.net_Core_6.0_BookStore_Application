using WebApplication3.Models.Domain;

namespace WebApplication3.Repository.Abstrack
{
    public interface IBookService 
    {
        bool Add(Book Book);
        bool Update(Book Book);
        bool Delete(int id);
        Book FindByID(int id);
        IEnumerable<Book> GetAll();
    }
}
