using CityInfo.API.Services;
using Microsoft.AspNetCore.StaticFiles;

var builder = WebApplication.CreateBuilder(args);
// builder.Logging.ClearProviders(); // Nothing to log
builder.Logging.AddConsole(); // Logs to console
// Add services to the container.

builder.Services.AddControllers(
    options =>
    {
        options.ReturnHttpNotAcceptable = true;
    }
    )
    .AddNewtonsoftJson()
    .AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();
builder.Services.AddTransient<ILocalMailService, LocalMailService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllers();

app.Run();

/*
 CLI:
    $ dotnet

    $ dotnet run -h #help

    $ dotnet run # Donde este el .csproj
 
 
 */