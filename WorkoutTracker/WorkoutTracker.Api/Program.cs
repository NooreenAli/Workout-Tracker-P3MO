using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;
using WorkoutTracker.Api.Security;
using WorkoutTracker.Api.Services;
using WorkoutTracker.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// EF
builder.Services.AddDbContext<WorkoutDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// Services
builder.Services.AddScoped<SessionService>();
builder.Services.AddScoped<ExerciseService>();
builder.Services.AddScoped<PdfService>();
builder.Services.AddScoped<AnalyticsService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ApiKeyMiddleware>();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.MapControllers();
app.Run();