public interface IBookRepository {
    IEnumerable<Book> GetAll();
    void AddBook(Book book);
}