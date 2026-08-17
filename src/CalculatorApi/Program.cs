using CalculatorApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<ICalculatorService, CalculatorService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorUI", policy =>
        policy.WithOrigins(
                builder.Configuration["AllowedOrigins"] ?? "http://localhost:5001",
                "https://localhost:7001")
              .AllowAnyHeader()
              .AllowAnyMethod());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowBlazorUI");
app.UseAuthorization();
app.MapControllers();

app.Run();

public partial class Program { }
