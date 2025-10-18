namespace GraphQL.API.Server.Models
{
    public class Author
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }

        //Parameterless constructor for EF Core
        public Author() 
        { 
            Id = default;
            Name = string.Empty;
            BirthDate = default;
        }
        
        public Author(int id, string name, DateTime birthDate)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
        }
        
        public Author(string name, DateTime birthDate)
        {
            Id = default;
            Name = name;
            BirthDate = birthDate;
        }
    }
}
