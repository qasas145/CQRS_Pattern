using Microsoft.AspNetCore.Mvc;
using MediatR;

[ApiController]
public class BookController :ControllerBase{
    public BookController(IBookRepository bookRepository, IMediator mediator)
    {
        _bookRepository = bookRepository;
        _mediator = mediator;
    }

    private readonly IMediator _mediator;
    private readonly IBookRepository _bookRepository;

    [HttpGet]
    
    [Route("/api/[controller]/books")]
    public async Task<IActionResult>  GetBooks() {
        var query = new GetBookQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }
    [HttpPost]
    [Route("/api/[controller]/add")]
    public async Task<IActionResult> AddBook([FromBody] AddBookCommand command) {
        command.Id = Guid.NewGuid();
        var bookId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetBook), new { id = bookId }, bookId);
    }
    [HttpGet]
    [Route("/api/[controller]/book")]
    public async Task<IActionResult> GetBook([FromQuery]string id) {
        var query = new GetBookQuery(){Id = Guid.Parse(id)};
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}