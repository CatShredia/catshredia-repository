using LibraryAPI.Interfaces;
using LibraryAPI.Requests;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RentalsController
{
    private readonly ILibraryService _service;

    public RentalsController(ILibraryService service) => _service = service;

    [HttpPost]
    public async Task<IActionResult> Rent(RentalStartQuery rentalStart) => await _service.RentBookAsync(rentalStart);

    [HttpPut("return/{rentalId}")]
    public async Task<IActionResult> Return(int rentalId) => await _service.ReturnBookAsync(rentalId);

    [HttpGet("history/reader/{readerId}")]
    public async Task<IActionResult> HistoryByReader(int readerId) =>
        await _service.GetRentalHistoryByUserAsync(readerId);

    [HttpGet("history/book/{bookId}")]
    public async Task<IActionResult> HistoryByBook(int bookId) => await _service.GetRentalHistoryByBookAsync(bookId);

    [HttpGet("current")]
    public async Task<IActionResult> Current() => await _service.GetCurrentRentalsAsync();
}