
public class BookRepository : IBookRepository
{
    private List<Book> books = new(){
        new Book(){Id = Guid.NewGuid(),Name = "Book 1", Category="food", PublishedAt = DateTime.Now.AddDays(2)},
        new Book(){Id = Guid.NewGuid(),Name = "Book 2", Category="food", PublishedAt = DateTime.Now.AddHours(3)},
        new Book(){Id = Guid.NewGuid(),Name = "Book 3", Category="science", PublishedAt = DateTime.Now.AddMonths(2)},
        new Book(){Id = Guid.NewGuid(),Name = "Book 4", Category="football", PublishedAt = DateTime.Now.AddDays(5)},
        new Book(){Id = Guid.NewGuid(),Name = "Book 5", Category="basketball", PublishedAt = DateTime.Now.AddYears(2).AddDays(2)},
        new Book(){Id = Guid.NewGuid(),Name = "Book 8", Category="basketball", PublishedAt = DateTime.Now.AddSeconds(120)},
    };

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public IEnumerable<Book> GetAll()
    {
        return books.AsEnumerable();
    }
    
}