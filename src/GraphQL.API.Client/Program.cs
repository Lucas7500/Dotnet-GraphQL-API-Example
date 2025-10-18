using GraphQL.API.Client;
using Microsoft.Extensions.DependencyInjection;
using StrawberryShake;

var serviceCollection = new ServiceCollection();

serviceCollection
    .AddBooksClient()
    .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://localhost:7040/graphql"));

var services = serviceCollection.BuildServiceProvider();

var client = services.GetRequiredService<IBooksClient>();

var result = await client.GetBooks.ExecuteAsync();
result.EnsureNoErrors();

if (result.Data is null)
{
    throw new GraphQLClientException("No Data was Received from the Client!");
}

foreach (var book in result.Data.Books)
{
    Console.WriteLine($"" +
        $"ID: {book.Id}, " +
        $"Title: {book.Title}, " +
        $"Author ID: {book.Author.Id}, " +
        $"Author Name: {book.Author.Name}");
}