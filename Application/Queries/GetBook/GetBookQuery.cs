using MediatR;

public class GetBookQuery :IRequest<IEnumerable<Book>>{
    public string Category{get;set;}
    public string SortBy{get;set;}
    public Guid Id{get;set;}
}