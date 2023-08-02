using WebApplication3.Models.Domain;

namespace WebApplication3.Repository.Abstrack
{
    public interface IPublisherService
    {
        bool Add(Publisher Publisher);
        bool Update(Publisher Publisher);
        bool Delete(int id);
        Publisher FindByID(int id);
        IEnumerable<Publisher> GetAll();
    }
}
