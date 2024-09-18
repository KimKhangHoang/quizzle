using Microsoft.EntityFrameworkCore;
using Quizzle.Data;
using Quizzle.Services;
using dotenv.net;

var builder = WebApplication.CreateBuilder(args);

// Load environment variables from .env file in development environment
DotEnv.Load();

// Configure database context with SQL Server
builder.Services.AddDbContext<QuizzleContext>(options =>
    options.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionStrings__QuizzleContext")));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<QuestionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();
