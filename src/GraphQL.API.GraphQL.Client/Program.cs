using GraphQL;
using GraphQL.API.GraphQL.Client.Response;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;

var client = new GraphQLHttpClient("https://localhost:7040/graphql", new SystemTextJsonSerializer());

var request = new GraphQLRequest
{
    Query = @"
        query {
          books {
            id
            title
            author {
              id
              name
            }
          }
        }"
};

var response = await client.SendQueryAsync<BooksResponse>(request);

foreach (var book in response.Data.Books)
{
    Console.WriteLine($"" +
        $"ID: {book.Id}, " +
        $"Title: {book.Title}, " +
        $"Author ID: {book.Author.Id}, " +
        $"Author Name: {book.Author.Name}");
}
