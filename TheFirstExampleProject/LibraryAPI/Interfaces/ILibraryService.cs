using Microsoft.AspNetCore.Mvc;
using LibraryAPI.Requests;

namespace LibraryAPI.Interfaces;

public interface ILibraryService
{
    // Users/Login
    Task<IActionResult> GetAllUsersAsync();
    Task<IActionResult> GetUserByIdAsync(int id);
    Task<IActionResult> CreateNewUserAndLoginAsync(UserQuery newUser);
    Task<IActionResult> EditUserAndLoginAsync(int id, UserQuery selectedUser);
    Task<IActionResult> DeleteUserAndLoginAsync(int id);

    // Books
    Task<IActionResult> GetAllBooksAsync();
    Task<IActionResult> GetBookByIdAsync(int id);
    Task<IActionResult> CreateBookAsync(BookQuery book);
    Task<IActionResult> UpdateBookAsync(int id, BookQuery book);
    Task<IActionResult> DeleteBookAsync(int id);
    Task<IActionResult> GetBooksByGenreAsync(string genreName);
    Task<IActionResult> SearchBooksAsync(string? author, string? title);

    // Users
    Task<IActionResult> CreateUserAsync(UserQuery User);
    Task<IActionResult> UpdateUserAsync(int id, UserQuery User);
    Task<IActionResult> DeleteUserAsync(int id);

    // Genres
    Task<IActionResult> GetAllGenresAsync();
    Task<IActionResult> CreateGenreAsync(GenreQuery genre);
    Task<IActionResult> UpdateGenreAsync(int id, GenreQuery genre);
    Task<IActionResult> DeleteGenreAsync(int id);

    // Rentals
    Task<IActionResult> RentBookAsync(RentalStartQuery rentalStart);
    Task<IActionResult> ReturnBookAsync(int rentalId);
    Task<IActionResult> GetRentalHistoryByUserAsync(int UserId);
    Task<IActionResult> GetRentalHistoryByBookAsync(int bookId);
    Task<IActionResult> GetCurrentRentalsAsync();
}