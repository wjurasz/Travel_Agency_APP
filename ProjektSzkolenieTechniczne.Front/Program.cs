using Microsoft.EntityFrameworkCore;
using SzkolenieTechniczneStorage.Repository;
using SzkolenieTechniczneStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register the TourRepository
builder.Services.AddScoped<ITourRepository, TourRepository>();

// Add DbContext
builder.Services.AddDbContext<TravelAgencyTicketDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

app.MapControllers(); // Add this line if you are using attribute routing

app.Run();
