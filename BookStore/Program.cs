using BookStore.Data;
using BookStore.Middleware;
using BookStore.Services;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using FluentValidation;
using BookStore.Models;
using BookStore.Models.Validators;
using FluentValidation.AspNetCore;
using BookStore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using BookStore.Mappings;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init Main");
try
{

    var builder = WebApplication.CreateBuilder(args);

    var aths = new AuthenticationSettings();





    // Add services to the container.

    builder.Services.AddControllers();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddDbContext<BookStoreDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    builder.Services.AddScoped<IBookStoreService, BookStoreService>(); //rejestracja do interfejsu
    builder.Services.AddScoped<IReviewService, ReviewService>();
    builder.Services.AddScoped<ErrorHandlingMiddleware>();
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();
    builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
    builder.Services.AddAutoMapper(typeof(BookStoreMappingProfile).Assembly);
    builder.Services.AddScoped<IAccountService, AccountService>();
    builder.Services.AddControllers().AddFluentValidation();
    builder.Services.AddScoped<IValidator<UserDto>, RegisterUserValidator>();
    builder.Services.AddScoped<IValidator<CreateBookDto>, CreateBookValidator>();
    builder.Configuration.GetSection("Authentication").Bind(aths);
    builder.Services.AddSingleton(aths);
    builder.Services.AddAuthentication(option =>
    {
        option.DefaultAuthenticateScheme = "Bearer";
        option.DefaultScheme = "Bearer";
        option.DefaultChallengeScheme = "Bearer";
    }).AddJwtBearer(cfg =>
    {
        cfg.RequireHttpsMetadata = false;
        cfg.SaveToken = true;
        cfg.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidIssuer = aths.JwtIssuer,
            ValidAudience = aths.JwtIssuer,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(aths.JwtKey)),
        };
    });

    var app = builder.Build();
    //app.UseMiddleware<ErrorHandlingMiddleware>();



    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseMiddleware<ErrorHandlingMiddleware>(); //przed wys³aniem zapytania middleware, wtedy ogarnia np. jak sie nie po³¹czy z baz¹ danych
    app.UseAuthentication();
    app.UseHttpsRedirection();

    app.UseAuthorization();


    app.MapControllers();

    app.Run();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    logger.Error(e);
}
finally
{
    LogManager.Shutdown();
}
