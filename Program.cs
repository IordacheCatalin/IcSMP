using IcSMP.DataContext;
using IcSMP.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Auth0.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<IcSMPDataContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));


builder.Services.AddTransient<IcSMPDataContext, IcSMPDataContext>();
builder.Services.AddTransient<CategoriesRepository, CategoriesRepository>();
builder.Services.AddTransient<ClientsRepository, ClientsRepository>();
builder.Services.AddTransient<SuppliersRepository, SuppliersRepository>();
builder.Services.AddTransient<CouriersRepository, CouriersRepository>();
builder.Services.AddTransient<ProductsRepository, ProductsRepository>();

// Auth0 configuration
builder.Services.AddAuth0WebAppAuthentication(options =>
     {
         options.Domain = builder.Configuration["Auth0:Domain"];
         options.ClientId = builder.Configuration["Auth0:ClientId"];
     });

var app = builder.Build();

app.UseAuthentication();

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
