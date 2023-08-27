using UrlShortenerWebApi.ConfigurationExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureIdentity(builder.Configuration);

builder.Services.ConfigureDb(builder.Configuration);

builder.Services.ConfigureRepositoryManager();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.ConfigureServiceManager();

builder.Services.ConfigureServices();

builder.Services.AddControllers();

var app = builder.Build();

app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
