using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using prueba2.Data;
var url = Environment.GetEnvironmentVariable("DATABASE_URL");
Console.Write($"La coneccion es esta {url}");
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<prueba2Context>(options =>
    options.UseNpgsql(url));

builder.WebHost.UseUrls("http://0.0.0.0:8080");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<prueba2Context>();
    db.Database.Migrate();
}

    app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
