using GraphQL.API.Server.Models;

namespace GraphQL.API.Server.GraphQL.Types
{
    public class AuthorType : ObjectType<Author>
    {
        protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
        {
            descriptor.Description("Represents a book author.");
            
            descriptor
                .Field(a => a.Id)
                .Description("The unique identifier for the author.");
            
            descriptor
                .Field(a => a.Name)
                .Description("Author name.");
            
            descriptor
                .Field(a => a.BirthDate)
                .Description("Birth date.");
        }
    }
}
