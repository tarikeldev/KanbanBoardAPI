using KanbanBoard.Application;
using KanbanBoard.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
var app = builder.Build();
await DependencyInjectionInfrastructure.EnsureSeedDataAsync(app.Services);
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(app =>
{
    app.WithOrigins("http://localhost:5173")
           .AllowAnyMethod()
           .AllowAnyHeader();
});
app.UseAuthorization();

app.MapControllers();

app.Run();
