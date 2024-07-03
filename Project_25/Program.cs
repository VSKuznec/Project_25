using Microsoft.Identity.Client;

namespace Project_25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppContext())
            {
                var user1 = new User { Name = "Arthur", Email = "seva@gmail.com" };
                var book1 = new Book { Title = "Think and get rich", Year = "1937" };
                var author1 = new Author { FirstName = "УГУ", LastName = "ГУГУ" };
                var genre1 = new Genre { Name = "Экшен" };

                db.Users.Add(user1);
                db.Books.Add(book1);
                db.SaveChanges();
            }
        }
    }
}
