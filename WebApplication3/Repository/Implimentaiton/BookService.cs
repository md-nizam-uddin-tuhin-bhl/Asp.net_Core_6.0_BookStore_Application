using WebApplication3.Data;
using WebApplication3.Models.Domain;
using WebApplication3.Repository.Abstrack;

namespace WebApplication3.Repository.Implimentaiton
{
    public class BookService : IBookService
    {

    
        private readonly DatabaseContext _context;
        public BookService(DatabaseContext context)
        {
            _context = context;
        }

        public bool Add(Book Book)
        {
            try
            {
                _context.books.Add(Book);
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
            _context.books.Remove(data);
            _context.SaveChanges();
            return true;
        }

        public Book FindByID(int id)
        {
            return _context.books.Find(id);
        }

        public IEnumerable<Book> GetAll()
        {
            var data = (from book in _context.books
                        join author in _context.author on book.AuthorId equals author.Id
                        join publisher in _context.publishers on book.PublisherId equals publisher.Id
                        join genre in _context.genres on book.GenreId equals genre.Id
                        select new Book
                        {
                            Id = book.Id,
                            AuthorId = book.AuthorId,
                            PublisherId = book.PublisherId,
                            GenreId = book.GenreId,
                            Title = book.Title,
                            TotalPage = book.TotalPage,
                            GenreName = genre.Name,
                            AuthorName = author.AuthorName,
                            PublisherName = publisher.PubliserName
                        }).ToList();

            return data;
        }

        public bool Update(Book Book)
        {
            try
            {
                _context.books.Update(Book);
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
