using LibraryAPI.Interfaces;
using LibraryAPI.Requests;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenresController
{
    private readonly ILibraryService _service;

    public GenresController(ILibraryService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll() => await _service.GetAllGenresAsync();

    [HttpPost]
    public async Task<IActionResult> Create(GenreQuery genre) => await _service.CreateGenreAsync(genre);

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, GenreQuery genre) => await _service.UpdateGenreAsync(id, genre);

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) => await _service.DeleteGenreAsync(id);
}