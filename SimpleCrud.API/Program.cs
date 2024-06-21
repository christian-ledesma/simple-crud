using Microsoft.EntityFrameworkCore;
using SimpleCrud.Application.Queries;
using SimpleCrud.Domain.Repositories;
using SimpleCrud.Infrastructure.Data;
using SimpleCrud.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Sql-Server"));
});

builder.Services.AddScoped<IToDoRepository, ToDoRepository>();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(ToDoListQuery).Assembly);
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    Context context = scope.ServiceProvider.GetRequiredService<Context>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
