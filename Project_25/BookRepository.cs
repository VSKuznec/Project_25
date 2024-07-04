using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_25;

namespace Project_25
{
    public class BookRepository
    {
        private readonly AppContext _context;

        private readonly List<Book> _books = new List<Book>();

        public BookRepository(AppContext context)
        {
            _context = context;
        }

        public Book GetById(int id)
        {
            return _context.Books.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }

        public void Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public void UpdateYear(int id, string newYear)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                book.Year = newYear;
                _context.SaveChanges();
            }
        }

        public List<Book> BooksByGenreAndYear(string genre, int startYear, int endYear)
        {
            var query = _books.Where(u => u.Genre == genre && u.Year >= startYear && u.Year <= endYear); 
            return query.ToList();
        }

        public int BooksCountByAuthor(string author)
        {
            var query = _books.Where(u => u.Author == author);
            return query.Count();
        }

        public int BooksCountByGenre(string genre)
        {
            var query = _books.Where(u => u.Genre == genre);
            return query.Count();
        }

        public bool BooksExists(string author, string title)
        {
            var query = _books.Where(u => u.Author == author && u.Title == title);
            return query.Any();
        }

        public bool BooksCheckedOut(int bookId, int userId)
        {
            var query = _books.Where(u => u.Id == bookId && u.Id == userId);
            return query.Any();
        }

        public int BooksCountByUser(int userId)
        {
            var query = _books.Where(u => u.Id == userId);
            return query.Count();
        }

        public Book BooksLast()
        {
            var query = _books.OrderByDescending(u => u.Year);
            return query.FirstOrDefault();
        }

        public List<Book> BooksSortedByName()
        {
            var query = _books.OrderBy(u => u.Title);
            return query.ToList();
        }

        public List<Book> BooksSortedByYearDescending()
        {
            var query = _books.OrderByDescending(u => u.Year);
            return query.ToList();
        }
    }
}
