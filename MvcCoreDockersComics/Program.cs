using Microsoft.EntityFrameworkCore;
using MvcCoreDockersComics.Data;
using MvcCoreDockersComics.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString =
    builder.Configuration.GetConnectionString("MySqlComics");
builder.Services.AddTransient<RepositoryComics>();
//MYSQL UTILIZA AddDbContextPool<>
builder.Services.AddDbContextPool<ComicsContext>
    (options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Comics}/{action=Index}/{id?}");

app.Run();
