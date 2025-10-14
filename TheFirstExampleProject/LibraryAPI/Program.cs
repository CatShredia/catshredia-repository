using Microsoft.EntityFrameworkCore;
using LibraryAPI.DatabaseContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// import DatabaseContext file
builder.Services.AddDbContext<ContextDatabase>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("TestDBString")), ServiceLifetime.Scoped);

// builder.Services.AddScoped<IUsersLoginsService, UserLoginService>();

var app = builder.Build();

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