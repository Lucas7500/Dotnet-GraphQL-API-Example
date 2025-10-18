using GraphQL.API.Server.Data;
using GraphQL.API.Server.Models;

namespace GraphQL.API.Server.GraphQL
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Book> GetBooks([Service] AppDbContext context) => context.Books;

        public Book? GetBookById(AppDbContext context, int id) =>
            context.Books.FirstOrDefault(b => b.Id == id);

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Author> GetAuthors([Service] AppDbContext context) => context.Authors;
    }
}
