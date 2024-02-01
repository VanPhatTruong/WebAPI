using Microsoft.EntityFrameworkCore;
using WebAPI.Models.Entity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TruongVanPhatContext>(
c => c.UseSqlServer(builder.Configuration.GetConnectionString("WebAPI")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.DefaultModelExpandDepth(-1));
}

app.UseAuthorization();

app.MapControllers();
app.m
app.Run();
