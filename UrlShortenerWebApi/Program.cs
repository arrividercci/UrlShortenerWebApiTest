using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Service.Contract;
using Service;
using UrlShortenerWebApi;
using UrlShortenerWebApi.ConfigurationExtensions;
using Contracts;
using Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.ConfigureIdentity(builder.Configuration);

builder.Services.AddControllers();

builder.Services.ConfigureRepositoryManager();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.ConfigureCors();

builder.Services.ConfigureServices();

builder.Services.ConfigureDb(builder.Configuration);

var app = builder.Build();

app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
