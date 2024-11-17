using MediatR;

public class AddBookCommandHandler :IRequestHandler<AddBookCommand, Guid>{

    public AddBookCommandHandler(IBookRepository repo)
    {
        _repo = repo;
    }

    private readonly IBookRepository _repo;

    public async Task<Guid> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        
        var book = new Book(){Id = request.Id,Name = request.Name, Category = request.Category, PublishedAt = DateTime.Now};
        _repo.AddBook(book);
        return book.Id;
    }
}