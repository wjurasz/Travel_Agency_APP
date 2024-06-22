using Microsoft.EntityFrameworkCore;
using SzkolenieTechniczneStorage.Repository;
using SzkolenieTechniczneStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register the DbContext with the correct connection string
builder.Services.AddDbContext<TravelAgencyTicketDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the repositories
builder.Services.AddScoped<ITourRepository, TourRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Set the default route to the Tour controller's Index action
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Tour}/{action=Index}/{id?}");

app.Run();
