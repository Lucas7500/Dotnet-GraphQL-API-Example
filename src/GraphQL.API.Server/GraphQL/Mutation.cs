using GraphQL.API.Server.Data;
using GraphQL.API.Server.Exceptions;
using GraphQL.API.Server.Models;

namespace GraphQL.API.Server.GraphQL
{
    public class Mutation
    {
        public async Task<Book> AddBookAsync(
            string title,
            int authorId,
            decimal price,
            [Service] AppDbContext context)
        {
            var author = await context.Authors.FindAsync(authorId) 
                ?? throw new AuthorNotFoundException(authorId);
            
            var book = new Book(title, author, price);

            context.Books.Add(book);

            await context.SaveChangesAsync();
            
            return book;
        }

        public async Task<Author> AddAuthorAsync(
            string name, 
            DateTime birthDate,
            [Service] AppDbContext context)
        {
            var author = new Author(name, birthDate);

            context.Authors.Add(author);
            
            await context.SaveChangesAsync();
            
            return author;
        }
    }
}
