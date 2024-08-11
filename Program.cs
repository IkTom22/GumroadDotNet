using GumroadDotNet.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<GumroadDotNetContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("GumroadDotNetContext") ?? throw new InvalidOperationException("Connection string 'DotNetMVCContext' not found.")));
}
else
{
    builder.Services.AddDbContext<GumroadDotNetContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("GumroadDotNetContext") ?? throw new InvalidOperationException("Connection string 'DotNetMVCContext' not found.")));
}
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
Console.WriteLine("Testing git push");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
