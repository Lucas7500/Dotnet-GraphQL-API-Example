using GraphQL.API.Server.Models;

namespace GraphQL.API.Server.GraphQL.Types
{
    public class BookType : ObjectType<Book>
    {
        protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
        {
            descriptor.Description("Represents a book in the catalog.");

            descriptor
                .Field(b => b.Id)
                .Description("The unique identifier of the book.");
            
            descriptor
                .Field(b => b.Title)
                .Description("The title of the book.");
            
            descriptor
                .Field(b => b.Author)
                .Description("The author of the book.");
            
            descriptor
                .Field(b => b.Price)
                .Description("The price of the book.");
        }
    }
}
