using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<DictionaryContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DictionaryDatabase")));
builder.Services.AddScoped<DictionaryService>();

builder.Services.AddOpenApi();
var app = builder.Build();
app.UseCors(x => x
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin()
);

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();