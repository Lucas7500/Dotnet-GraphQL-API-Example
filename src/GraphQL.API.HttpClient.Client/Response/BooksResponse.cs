namespace GraphQL.API.HttpClient.Client.Response
{
    public class BooksResponse
    {
        public ResponseData Data { get; set; } = new();

        public List<Book> Books => Data.Books;
    }

    public record ResponseData
    {
        public List<Book> Books { get; set; } = [];
    }
}