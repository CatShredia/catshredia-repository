using LibraryAPI.Interfaces;
using LibraryAPI.Requests;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController
{
    private readonly ILibraryService _service;
    public BooksController(ILibraryService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll() => await _service.GetAllBooksAsync();

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id) => await _service.GetBookByIdAsync(id);

    [HttpPost]
    public async Task<IActionResult> Create(BookQuery book) => await _service.CreateBookAsync(book);

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, BookQuery book) => await _service.UpdateBookAsync(id, book);

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) => await _service.DeleteBookAsync(id);

    [HttpGet("genre")]
    public async Task<IActionResult> ByGenre([FromQuery] string genreName) =>
        await _service.GetBooksByGenreAsync(genreName);

    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] string? author, [FromQuery] string? title) =>
        await _service.SearchBooksAsync(author, title);
}