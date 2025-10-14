using Microsoft.AspNetCore.Mvc;

namespace TestFirstWedAPIProject.Interfaces;

public interface IUsersLoginsService
{
    Task<IActionResult> GetAllUsersAsync();
}