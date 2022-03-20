global using Microsoft.EntityFrameworkCore;
global using MinimalApiVsWebApi.Data;
using MinimalApiVsWebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("videogamedb"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.MapGet("/videogame", async (DataContext context) => await context.VideoGames.ToListAsync());

app.MapGet("/videogame/{id}", async (DataContext context, int id) =>
    await context.VideoGames.FindAsync(id) is VideoGame game ?
        Results.Ok(game) :
        Results.NotFound("No game here. :/"));

app.MapPost("/videogame", async (DataContext context, VideoGame game) =>
{
    context.VideoGames.Add(game);
    await context.SaveChangesAsync();
    return Results.Ok(await context.VideoGames.ToListAsync());
});

app.MapPut("/videogame/{id}", async (DataContext context, VideoGame game, int id) =>
{
    var dbGame = await context.VideoGames.FindAsync(id);
    if (dbGame == null) return Results.NotFound("Nope.");

    dbGame.Name = game.Name;
    dbGame.Developer = game.Developer;
    dbGame.Release = game.Release;
    await context.SaveChangesAsync();

    return Results.Ok(await context.VideoGames.ToListAsync());
});

app.MapDelete("/videogame/{id}", async (DataContext context, int id) =>
{
    var dbGame = await context.VideoGames.FindAsync(id);
    if (dbGame == null) return Results.NotFound("No game to delete here. :)");

    context.VideoGames.Remove(dbGame);
    await context.SaveChangesAsync();

    return Results.Ok(await context.VideoGames.ToListAsync());
});

app.Run();
