using MediatR;

public class AddBookCommand : IRequest<Guid>{
    public Guid Id{get;set;}
    public string Name{get;set;}
    public string Category{get;set;}
    public DateTime PublishedAt{get;set;}
}