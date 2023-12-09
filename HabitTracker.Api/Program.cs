using HabitTracker.Api;
using HabitTracker.Api.Repositories.HabitListRepositories;
using HabitTracker.Api.Repositories.HabitRepositories;
using HabitTracker.Api.Repositories.HabitRepsitories;
using HabitTracker.Api.Repositories.UserRepositories;
using HabitTracker.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//server db base
//builder.Services.AddDbContext<AppDbContext>(options => options.UseMySQL("Server=localhost;Database=habit_tracker;Uid=root;Pwd=;"));

// in memory db
builder.Services.AddDbContext<AppDbContext>();

//identity user conf
builder.Services.AddIdentity<User, IdentityRole>(o =>
{
    o.Password.RequireDigit = true;
    o.Password.RequiredLength = 8;
    o.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();


//Repositiories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IHabitRepository, HabitRepository>();
builder.Services.AddScoped<IHabitListRepository, HabitListRepository>();



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
