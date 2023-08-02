

using WebApplication3.Data;
using WebApplication3.Models.Domain;
using WebApplication3.Repository.Abstrack;

namespace WebApplication3.Repository.Implimentaiton
{
    public class GenreService : IGenreService
    {
        private readonly DatabaseContext _context;
        public GenreService(DatabaseContext context)
        {
            _context = context;
        }

        public bool Add(Genre genre)
        {
            try
            {
                _context.genres.Add(genre);
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
            if(data == null)
            {
                return false;
            }
            _context.genres.Remove(data);
            _context.SaveChanges();
            return true;
        }

        public Genre FindByID(int id)
        {
            return _context.genres.Find(id);
        }

        public IEnumerable<Genre> GetAll()
        {
            return _context.genres.ToList();
        }

        public bool Update(Genre genre)
        {
            try
            {
                _context.genres.Update(genre);
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
