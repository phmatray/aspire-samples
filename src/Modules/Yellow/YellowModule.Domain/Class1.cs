namespace YellowModule.Domain
{
    public record Book
    {
        public required string Title { get; init; }

        public required Author Author { get; init; }
    }

    public record Author
    {
        public required string Name { get; init; }
    }
}
