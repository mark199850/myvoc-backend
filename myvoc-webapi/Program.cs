using myvoc_webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<LinguaRobotNormalizer>();
builder.Services.AddHttpClient("word", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://lingua-robot.p.rapidapi.com/");
    httpClient.Timeout = TimeSpan.FromSeconds(15);
    
    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("x-rapidapi-key", builder.Configuration["HttpClient:APIKey"]);
    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("x-rapidapi-host", builder.Configuration["HttpClient:Host"]); // builder.Configuration["HttpClient:APIKey"]);
}).SetHandlerLifetime(TimeSpan.FromSeconds(15));

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
var app = builder.Build();
app.UseCors(x => x
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin()
);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();