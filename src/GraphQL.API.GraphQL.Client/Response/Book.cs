namespace GraphQL.API.GraphQL.Client.Response
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public Author Author { get; set; } = new();
    }
}