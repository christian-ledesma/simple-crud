using Microsoft.EntityFrameworkCore;
using SimpleCrud.Application.Queries;
using SimpleCrud.Domain.Repositories;
using SimpleCrud.Infrastructure.Data;
using SimpleCrud.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var sqlserver = builder.Configuration.GetConnectionString("Sql-Server");

builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(sqlserver);
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
