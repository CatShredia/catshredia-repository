using LibraryAPI.DatabaseContext;
using LibraryAPI.Interfaces;
using LibraryAPI.Requests;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers;

public class JwtController
{
    private readonly ILibraryService _service;
    public JwtController(ILibraryService service) => _service = service;
    
    // authtorization
    [HttpPost("login")]
    public async Task<IActionResult> Authtorization([FromBody]LoginQuery reader) => await _service.AuthtorizationAsync(reader);
}