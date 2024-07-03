using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Project_25
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public Author Author { get; set; }
        public Genre Genre { get; set; }
    }

    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public List<Book> Books { get; set; } = new List<Book>();

    }

    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
