using YellowModule.Domain;

namespace YellowModule.ApiService.Queries;

public class GetBookQuery
{
    public Book GetBook()
    {
        return new Book
        {
            Title = "C# in depth.",
            Author = new Author
            {
                Name = "Jon Skeet"
            }
        };
    }
}
