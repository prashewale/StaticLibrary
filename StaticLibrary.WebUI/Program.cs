using Microsoft.EntityFrameworkCore;
using StaticLibrary.WebUI.Services.Repository.AuthorRepository;
using StaticLibrary.WebUI.Services.Repository.BookRepository;
using StaticLibrary.WebUI.Services.Repository.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRouting((options) =>
{
    options.LowercaseQueryStrings = false; // /book/get-list?name=Harry
    options.AppendTrailingSlash = true; 
    options.LowercaseUrls = true; // /book/list/
});

builder.Services.AddTransient<IAuthorRepo, AuthorRepo>();
builder.Services.AddTransient<IBookRepo, BookRepo>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("AppDbConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
