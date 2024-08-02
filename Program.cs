using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Google.Api;

var builder = WebApplication.CreateBuilder(args);

// Configuration
builder.Configuration.AddJsonFile("appsettings.json");

// Add services to the container.
builder.Services.AddControllers();

// Add Swagger/OpenAPI services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder =>
        {
            builder.WithOrigins("https://stageradhibenafia.azurewebsites.net")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

// MongoDB configuration
var connectionString = builder.Configuration.GetConnectionString("MongoDB");
builder.Services.AddSingleton<IMongoClient>(new MongoClient(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.


    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseRouting();

// Enable CORS
app.UseCors("AllowReactApp");
app.UseCors("AllowLocalhost3000");

app.UseAuthorization();

app.MapControllers();

app.Run();
