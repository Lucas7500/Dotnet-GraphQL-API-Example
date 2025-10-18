namespace GraphQL.API.Server.Models
{
    public class Book
    {
        public int Id { get; private set;  }
        public string Title { get; private set; }
        public Author Author { get; private set; }
        public decimal Price { get; private set; }

        // Parameterless constructor for EF Core
        public Book() 
        { 
            Id = default;
            Title = string.Empty;
            Author = null!;
            Price = default;
        }

        public Book(int id, string title, Author author, decimal price)
        {
            Id = id;
            Title = title;
            Author = author;
            Price = price;
        }

        public Book(string title, Author author, decimal price)
        {
            Id = default;
            Title = title;
            Author = author;
            Price = price;
        }
    }
}
