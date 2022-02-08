using DL;
using BL;
//using Serilog;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
        });
});

// Add services to the container.

builder.Services.AddMemoryCache();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//A lot of stuff goes here

//To use ef repo or something and point to new connection string
builder.Services.AddDbContext<DbContext, DDDBContext>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("PostgreDDDB")
));

//Registering our deps here for dependency injection
//Different ways to add: Add, AddScoped, Singleton (for whole life of app), Transient (every time called creates new instance)

//ORM code
builder.Services.AddScoped<IScoreRepo, EFScoreRepo>();
builder.Services.AddScoped<IScoreBL, EFScoreBL>();
builder.Services.AddScoped<IUserRepo, EFUserRepo>();
builder.Services.AddScoped<IUserBL, EFUserBL>();
builder.Services.AddScoped<IGameRepo, EFGameRepo>();
builder.Services.AddScoped<IGameBL, EFGameBL>();
//If anymore models are added, we need Dl & BL Repos, Controllers and lines added here

//


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
