
using Entities.Models.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Base;
using Services.Exceptions;

const string myAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        policy  =>
        {
            policy.WithOrigins("http://localhost:3000", "http://localhost:5194")
                .AllowAnyHeader()
                .AllowCredentials()
                .AllowAnyMethod();
        });
});

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

builder.Services.AddDbContext<DailyQuestionContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<DailyQuestionService>();
builder.Services.AddTransient<UserService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

var app = builder.Build();

app.Use(async (context, next) =>
{
    try
    {
        Console.WriteLine(context.Response.Body);
        await next.Invoke();
    }
    catch (IdNotFoundException e)
    {
        context.Response.StatusCode = 404;
        await context.Response.WriteAsync(e.Message);
    }
    catch (EmailAlreadyInUseException e)
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync(e.Message);
    }
    catch (UnsuccessfulLoginException e)
    {
        context.Response.StatusCode = 401;
        await context.Response.WriteAsync(e.Message);
    }
});

app.UseCors(myAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();