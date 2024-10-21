var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllerRoute(
    name: "library",
    pattern: "Library",
    defaults: new { controller = "Library", action = "Greet" }
);

app.MapControllerRoute(
    name: "libraryBooks",
    pattern: "Library/Books",
    defaults: new { controller = "Library", action = "Books" }
);

app.MapControllerRoute(
    name: "libraryProfile",
    pattern: "Library/Profile/{id?}",
    defaults: new { controller = "Library", action = "Profile" }
);

app.Run();

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}
