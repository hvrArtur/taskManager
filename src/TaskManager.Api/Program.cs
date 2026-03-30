using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Configuration;
using TaskManager.Api.Middleware;
using TaskManager.Application;
using TaskManager.Infrastructure;
using TaskManager.Infrastructure.Persistence;

EnvFileLoader.LoadFromCurrentDirectoryTree();

var rootDirectory = Directory.GetCurrentDirectory();
EnvFileLoader.Load(
    Path.Combine(rootDirectory, ".env"),
    Path.Combine(rootDirectory, "src", "TaskManager.Api", ".env"));

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication()
                .AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<TaskManagerDbContext>();
    await dbContext.Database.EnsureCreatedAsync();
}

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
