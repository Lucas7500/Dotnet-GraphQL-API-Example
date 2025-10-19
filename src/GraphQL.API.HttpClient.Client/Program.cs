using GraphQL.API.HttpClient.Client.Response;
using System.Text;
using System.Text.Json;

var http = new HttpClient { BaseAddress = new Uri("https://localhost:7040/graphql") };

var query = new
{
    query = @"query { books { id title author { name } } }"
};

var content = new StringContent(JsonSerializer.Serialize(query), Encoding.UTF8, "application/json");

var response = await http.PostAsync(string.Empty, content);
var json = await response.Content.ReadAsStringAsync();

var options = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true
};

var booksReponse = JsonSerializer.Deserialize<BooksResponse>(json, options);

if (booksReponse is null)
{
    Console.WriteLine("No data received.");
    return;
}

foreach (var book in booksReponse.Books)
{
    Console.WriteLine($"" +
        $"ID: {book.Id}, " +
        $"Title: {book.Title}, " +
        $"Author ID: {book.Author.Id}, " +
        $"Author Name: {book.Author.Name}");
}