using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

[ApiController]
[Route("[controller]")]
public class LibraryController : ControllerBase
{
    [HttpGet]
    [Route("/Library")]
    public IActionResult Greet()
    {
        return Ok("Вітаємо в бібліотеці!");
    }

    [HttpGet]
    [Route("/Library/Books")]
    public IActionResult Books()
    {
        var booksFilePath = Path.Combine(Directory.GetCurrentDirectory(), "books.json");
        var booksJson = System.IO.File.ReadAllText(booksFilePath);
        var books = JsonSerializer.Deserialize<List<string>>(booksJson);

        return Ok(books);
    }

    [HttpGet]
    [Route("/Library/Profile/{id?}")]
    public IActionResult Profile(int? id)
    {
        var usersFilePath = Path.Combine(Directory.GetCurrentDirectory(), "user.json");
        var usersJson = System.IO.File.ReadAllText(usersFilePath);
        var users = JsonSerializer.Deserialize<List<User>>(usersJson);

        if (id.HasValue && id.Value >= 0 && id.Value <= 5)
        {
            var user = users.FirstOrDefault(u => u.Id == id.Value);
            if (user != null)
            {
                return Ok($"Користувач: {user.Name}, Вік: {user.Age}");
            }
            else
            {
                return NotFound("Користувача з таким ID не знайдено");
            }
        }
        else
        {
            return Ok("Інформація про користувача: Default User");
        }
    }
}
