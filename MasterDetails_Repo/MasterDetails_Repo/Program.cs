using MasterDetails_Repo.DbModel;
using MasterDetails_Repo.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RestaurantDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("db")));
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IFoodRepo, FoodRepo>();

var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.Run();