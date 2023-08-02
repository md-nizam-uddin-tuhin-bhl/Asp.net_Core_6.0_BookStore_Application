using WebApplication3.Data;
using WebApplication3.Models.Domain;
using WebApplication3.Repository.Abstrack;

namespace WebApplication3.Repository.Implimentaiton
{
    public class AuthorService : IAuthorServicecs
    {
        private readonly DatabaseContext _context;
        public AuthorService(DatabaseContext context)
        {
            _context = context;
        }

        public bool Add(Author author)
        {
            try
            {
                _context.author.Add(author);
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
            _context.author.Remove(data);
            _context.SaveChanges();
            return true;
        }

        public Author FindByID(int id)
        {
            return _context.author.Find(id);
        }

        public IEnumerable<Author> GetAll()
        {
            return _context.author.ToList();
        }

        public bool Update(Author author)
        {
            try
            {
                _context.author.Update(author);
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
