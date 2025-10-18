namespace GraphQL.API.Server.Exceptions
{
    public class AuthorNotFoundException(int authorId) 
        : Exception($"Author with id {authorId} was not found!")
    {
    }
}
