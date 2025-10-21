using LibraryAPI.DatabaseContext;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Interfaces;
using LibraryAPI.Requests;

namespace LibraryAPI.Services;

public class LibraryService : ILibraryService
{
    private readonly ContextDatabase _contextDatabase;

    public LibraryService(ContextDatabase contextDatabase)
    {
        _contextDatabase = contextDatabase;
    }

    public async Task<IActionResult> GetAllUsersAsync()
    {
        var users = _contextDatabase.Users.ToListAsync();

        return new OkObjectResult(new
        {
            data = new { users = users },
            status = true
        });
    }

    public async Task<IActionResult> GetUserByIdAsync(int id)
    {
        var user = await _contextDatabase.Users
            .FirstOrDefaultAsync(u => u.id_user == id); // assuming your User has Id

        if (user == null)
        {
            return new NotFoundObjectResult(new { status = false, message = "User not found." });
        }

        return new OkObjectResult(new
        {
            status = true,
            data = user
        });
    }

    public async Task<IActionResult> CreateNewUserAndLoginAsync(UserQuery newUser)
    {
        var login = new Login()
        {
            User = new User()
            {
                description = newUser.Description,
                name = newUser.Name,
            },
            password = newUser.Password,
            login = newUser.Login
        };

        await _contextDatabase.AddAsync(login);
        await _contextDatabase.SaveChangesAsync();

        return new OkObjectResult(new
        {
            status = true,
            message = "User and login created successfully."
        });
    }

    public async Task<IActionResult> EditUserAndLoginAsync(int id, UserQuery selectedUser)
    {
        var existingLogin = await _contextDatabase.Logins
            .Include(l => l.User)
            .FirstOrDefaultAsync(l => l.id_user == id);

        if (existingLogin == null)
        {
            return new NotFoundObjectResult(new { status = false, message = "Login not found." });
        }

        existingLogin.login = selectedUser.Login;
        existingLogin.password = selectedUser.Password;

        existingLogin.User.name = selectedUser.Name;
        existingLogin.User.description = selectedUser.Description;

        await _contextDatabase.SaveChangesAsync();

        return new OkObjectResult(new
        {
            status = true,
            message = "User and login edited successfully."
        });
    }

    public async Task<IActionResult> DeleteUserAndLoginAsync(int id)
    {
        var existingLogin = await _contextDatabase.Logins
            .Include(l => l.User)
            .FirstOrDefaultAsync(l => l.id_user == id);

        if (existingLogin == null)
        {
            return new NotFoundObjectResult(new { status = false, message = "Login not found." });
        }

        _contextDatabase.Logins.Remove(existingLogin);

        if (existingLogin.User != null)
        {
            _contextDatabase.Users.Remove(existingLogin.User);
        }

        await _contextDatabase.SaveChangesAsync();

        return new OkObjectResult(new
        {
            status = true,
            message = "User and login deleted successfully."
        });
    }

    public async Task<IActionResult> GetAllBooksAsync()
    {
        var books = _contextDatabase.Books.ToListAsync();

        return new OkObjectResult(new
        {
            data = new { books = books },
            status = true
        });
    }

    public async Task<IActionResult> GetBookByIdAsync(int id)
    {
        var book = await _contextDatabase.Books.Include(b => b.Genre).FirstOrDefaultAsync(b => b.id_book == id);
        if (book == null) return new NotFoundObjectResult(new { status = false, message = "Book not found." });
        return new OkObjectResult(new { status = true, data = book });
    }

    public async Task<IActionResult> CreateBookAsync(BookQuery book)
    {
        var genre = await _contextDatabase.Genres.FirstOrDefaultAsync(g => g.name == book.genre_name);
        if (genre == null) return new BadRequestObjectResult(new { status = false, message = "Genre not found." });

        var newBook = new Book
        {
            title = book.title,
            author = book.author,
            cost = book.cost,
            description = book.description,
            id_genre = genre.id_genre
        };

        await _contextDatabase.Books.AddAsync(newBook);
        await _contextDatabase.SaveChangesAsync();

        return new OkObjectResult(new { status = true, message = "Book created." });
    }

    public async Task<IActionResult> UpdateBookAsync(int id, BookQuery book)
    {
        var existing = await _contextDatabase.Books.FindAsync(id);
        if (existing == null) return new NotFoundObjectResult(new { status = false, message = "Book not found." });

        var genre = await _contextDatabase.Genres.FirstOrDefaultAsync(g => g.name == book.genre_name);
        if (genre == null) return new BadRequestObjectResult(new { status = false, message = "Genre not found." });

        existing.cost = book.cost;
        existing.description = book.description;
        existing.id_genre = genre.id_genre;

        await _contextDatabase.SaveChangesAsync();
        return new OkObjectResult(new { status = true, message = "Book updated." });
    }

    public async Task<IActionResult> DeleteBookAsync(int id)
    {
        var book = await _contextDatabase.Books.FindAsync(id);
        if (book == null) return new NotFoundObjectResult(new { status = false, message = "Book not found." });

        _contextDatabase.Books.Remove(book);
        await _contextDatabase.SaveChangesAsync();
        return new OkObjectResult(new { status = true, message = "Book deleted." });
    }

    public async Task<IActionResult> GetBooksByGenreAsync(string genreName)
    {
        var books = await _contextDatabase.Books
            .Include(b => b.Genre)
            .Where(b => b.Genre.name == genreName)
            .ToListAsync();

        return new OkObjectResult(new { status = true, data = new { books } });
    }

    public async Task<IActionResult> SearchBooksAsync(string? author, string? title)
    {
        var query = _contextDatabase.Books.AsQueryable();

        if (!string.IsNullOrEmpty(author))
            query = query.Where(b => EF.Functions.Like(b.author, $"%{author}%"));
        if (!string.IsNullOrEmpty(title))
            query = query.Where(b => EF.Functions.Like(b.title, $"%{title}%"));

        var books = await query.Include(b => b.Genre).ToListAsync();
        return new OkObjectResult(new { status = true, data = new { books } });
    }
    
    // ============ GENRES ============
    public async Task<IActionResult> GetAllGenresAsync() =>
        new OkObjectResult(new { data = new { genres = await _contextDatabase.Genres.ToListAsync() }, status = true });

    public async Task<IActionResult> CreateGenreAsync(GenreQuery genre)
    {
        if (await _contextDatabase.Genres.AnyAsync(g => g.name == genre.name))
            return new BadRequestObjectResult(new { status = false, message = "Genre already exists." });

        await _contextDatabase.Genres.AddAsync(new Genre { name = genre.name });
        await _contextDatabase.SaveChangesAsync();
        return new OkObjectResult(new { status = true, message = "Genre created." });
    }

    public async Task<IActionResult> UpdateGenreAsync(int id, GenreQuery genre)
    {
        var existing = await _contextDatabase.Genres.FindAsync(id);
        if (existing == null) return new NotFoundObjectResult(new { status = false, message = "Genre not found." });

        existing.name = genre.name;
        await _contextDatabase.SaveChangesAsync();
        return new OkObjectResult(new { status = true, message = "Genre updated." });
    }

    public async Task<IActionResult> DeleteGenreAsync(int id)
    {
        var genre = await _contextDatabase.Genres.FindAsync(id);
        if (genre == null) return new NotFoundObjectResult(new { status = false, message = "Genre not found." });

        // Проверка: есть ли книги с этим жанром?
        if (await _contextDatabase.Books.AnyAsync(b => b.id_genre == id))
            return new BadRequestObjectResult(new
                { status = false, message = "Cannot delete genre with assigned books." });

        _contextDatabase.Genres.Remove(genre);
        await _contextDatabase.SaveChangesAsync();
        return new OkObjectResult(new { status = true, message = "Genre deleted." });
    }

    public async Task<IActionResult> RentBookAsync(RentalStartQuery rentalStart)
    {
        var User = await _contextDatabase.Users.FindAsync(rentalStart.id_user);
        var book = await _contextDatabase.Books.FindAsync(rentalStart.id_book);

        if (User == null) return new NotFoundObjectResult(new { status = false, message = "User not found." });
        if (book == null) return new NotFoundObjectResult(new { status = false, message = "Book not found." });
        
        bool alreadyRented = await _contextDatabase.RentLists
            .AnyAsync(r => r.id_user == rentalStart.id_user && r.id_book == rentalStart.id_book);

        if (alreadyRented)
        {
            return new NotFoundObjectResult(new { status = false, message = "This book already rented by this user." });
        }
        
        var newRental = new RentList()
        {
            id_user = rentalStart.id_user,
            id_book = rentalStart.id_book,
            date_start = rentalStart.date_start
        };

        await _contextDatabase.RentLists.AddAsync(newRental);
        await _contextDatabase.SaveChangesAsync();

        return new OkObjectResult(new { status = true, message = "Book rented successfully." });
    }

    public async Task<IActionResult> ReturnBookAsync(int rentalId)
    {
        var rental = await _contextDatabase.RentLists.FindAsync(rentalId);

        rental.date_end = DateOnly.FromDateTime(DateTime.Now);
        var book = await _contextDatabase.Books.FindAsync(rental.id_book);
        
        await _contextDatabase.SaveChangesAsync();
        return new OkObjectResult(new { status = true, message = "Book returned." });
    }

    public async Task<IActionResult> GetRentalHistoryByUserAsync(int UserId)
    {
        var rentals = await _contextDatabase.RentLists
            .Include(r => r.Book)
            .Include(r => r.User)
            .Where(r => r.id_user == UserId)
            .ToListAsync();

        return new OkObjectResult(new { status = true, data = new { rentals } });
    }

    public async Task<IActionResult> GetRentalHistoryByBookAsync(int bookId)
    {
        var rentals = await _contextDatabase.RentLists
            .Include(r => r.Book)
            .Include(r => r.User)
            .Where(r => r.id_book == bookId)
            .ToListAsync();

        return new OkObjectResult(new { status = true, data = new { rentals } });
    }

    public async Task<IActionResult> GetCurrentRentalsAsync()
    {
        var current = await _contextDatabase.RentLists
            .Include(r => r.Book)
            .Include(r => r.User)
            .Where(r => r.date_end == null)
            .ToListAsync();

        return new OkObjectResult(new { status = true, data = new { currentRentals = current } });
    }
}