using WebApplication3.Data;
using WebApplication3.Models.Domain;
using WebApplication3.Repository.Abstrack;

namespace WebApplication3.Repository.Implimentaiton
{
    public class PublisherService : IPublisherService
    {
        private readonly DatabaseContext _context;
        public PublisherService(DatabaseContext context)
        {
            _context = context;
        }

        public bool Add(Publisher Publisher)
        {
            try
            {
                _context.publishers.Add(Publisher);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            var data = this.FindByID(id);
            if (data == null)
            {
                return false;
            }
            _context.publishers.Remove(data);
            _context.SaveChanges();
            return true;
        }

        public Publisher FindByID(int id)
        {
            return _context.publishers.Find(id);
        }

        public IEnumerable<Publisher> GetAll()
        {
            return _context.publishers.ToList();
        }

        public bool Update(Publisher Publisher)
        {
            try
            {
                _context.publishers.Update(Publisher);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
