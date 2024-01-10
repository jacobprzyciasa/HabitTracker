using HabitTracker.Api;
using HabitTracker.Api.Entities;
using HabitTracker.Api.Repositories;
using HabitTracker.Api.Repositories.HabitListRepositories;
using HabitTracker.Api.Repositories.HabitRepositories;
using HabitTracker.Api.Repositories.HabitRepsitories;
using HabitTracker.Api.Repositories.UserRepositories;
using HabitTracker.Api.Services;
using HabitTracker.Api.Services.AuthenticationServices;
using HabitTracker.Api.Services.AuthenticationServices;
using HabitTracker.Api.Services.Logger;
using HabitTracker.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NLog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),
"/nlog.config"));

builder.Services.AddSingleton<ILoggerManager, LoggerManager>();

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
builder.Services.AddIdentity<User, IdentityRole<int>>(o =>
{
    o.Password.RequireDigit = true;
    o.Password.RequiredLength = 8;
    o.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();


//jwt auth
var jwtConfiguration = new JwtConfiguration();
builder.Configuration.Bind(jwtConfiguration.Section, jwtConfiguration);
var secretKey = Environment.GetEnvironmentVariable("SECRET");

//auth
builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtConfiguration.ValidIssuer,
        ValidAudience = jwtConfiguration.ValidAudience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
    };
});



builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();

//Mapper
builder.Services.AddAutoMapper(typeof(Program));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
