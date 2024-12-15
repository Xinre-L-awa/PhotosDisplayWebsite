using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PhotosDisplayWebsite.Data;
using PhotosDisplayWebsite.Models;
using System.Configuration;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

Console.WriteLine($"Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename={Directory.GetCurrentDirectory()}\\PhotosDisplayWebsiteContext-Manager.mdf; Integrated Security=true;Trusted_Connection=True;");

var host = builder.Configuration.GetSection("Host");

builder.WebHost.UseUrls(
    "http://*:7017",
    "http://localhost:7017",
    String.Join(':', host.GetValue<string>("Address"), host.GetValue<int>("Port")
));
builder.Services.AddDbContext<PhotosDisplayWebsiteContext>(options =>
    options.UseSqlServer($"Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename={Directory.GetCurrentDirectory()}\\PhotosDisplayWebsiteContext-Manager.mdf; Integrated Security=true;Trusted_Connection=True;"));
    //options.UseSqlServer(builder.Configuration.GetConnectionString("PhotosDisplayWebsiteContext") ?? throw new InvalidOperationException("Connection string 'PhotosDisplayWebsiteContext' not found.")));
// "PhotosDisplayWebsiteContext": "Server=(localdb)\\mssqllocaldb;Database=PhotosDisplayWebsiteContext-Manager;Trusted_Connection=True;MultipleActiveResultSets=true"
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

// app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
