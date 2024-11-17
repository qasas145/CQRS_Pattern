using MediatR;

public class GetBookQueryHandler : IRequestHandler<GetBookQuery, IEnumerable<Book>>{
    public GetBookQueryHandler(IBookRepository _repository) {
        this._repository = _repository;
    }

    public IBookRepository _repository;

    public async Task<IEnumerable<Book>> Handle(GetBookQuery request, CancellationToken cancellationToken)
    {
        
        var allBooks = _repository.GetAll();
        
        if (request.Id != Guid.Empty) {
            return allBooks.Where(b=>b.Id == request.Id);
        }
        if(!string.IsNullOrEmpty(request.Category)) {

            allBooks = allBooks.Where(b=>b.Category == request.Category).AsEnumerable();

        }
        
        if (request.SortBy == "asc") 
            return allBooks.OrderBy(b=>b.PublishedAt);
        else if (request.SortBy == "desc")
            return allBooks.OrderByDescending(b=>b.PublishedAt);

        return allBooks;
    }
}