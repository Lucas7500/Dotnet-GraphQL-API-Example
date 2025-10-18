using GraphQL.API.Server.Data;
using GraphQL.API.Server.GraphQL;
using GraphQL.API.Server.GraphQL.Types;
using GraphQL.API.Server.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryDB"));

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddType<BookType>()
    .AddType<AuthorType>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

SeedDatabase(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapGraphQL();

app.Run();

static void SeedDatabase(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    using var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!db.Authors.Any())
    {
        var author1 = new Author(1, "Robert C. Martin", new DateTime(1952, 12, 5));
        var author2 = new Author(2, "Eric Evans", new DateTime(1965, 1, 1));

        db.Authors.AddRange(author1, author2);

        db.Books.AddRange(
            new Book(1, "Clean Code", author1, 120.00m),
            new Book(2, "Domain-Driven Design", author2, 150.00m)
        );

        db.SaveChanges();
    }
}