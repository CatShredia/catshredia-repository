using JwtProject.Database;
using JwtProject.Interfaces;
using JwtProject.Security;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// import DatabaseContext file
builder.Services.AddDbContext<ContextDatabase>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionString")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddSingleton<JwtTokensGenerator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(options => { options.SwaggerEndpoint("/openapi/v1.json", "Open API V1"); });

    app.UseReDoc(options => { options.SpecUrl("/openapi/v1.json"); });

    app.MapScalarApiReference();
}

app.MapOpenApi();

app.UseMiddleware<LoggingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();