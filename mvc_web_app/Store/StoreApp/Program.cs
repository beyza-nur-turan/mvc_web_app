using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();//controller olmadanda razer pageleri kullanabilecek bir servisi uygulamaya dahil ettik
builder.Services.AddDbContext<RepositoryContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"),
    b => b.MigrationsAssembly("StoreApp"));
});
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddSingleton<Cart>(); //bir cart nesnesi newlenecek ve herkes aynı sepeti kullanacak
builder.Services.AddAutoMapper(typeof(Program));//automapper service kaydı gerçekleştirildi. böylece automapper kullanılabilecek
var app = builder.Build();
app.UseStaticFiles();//wwwroot klasörünü kullanılabilir hale getirdik
app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints =>
{   
    endpoints.MapAreaControllerRoute("Admin","Admin","Admin/{controller=Dashboard}/{action=Index}/{id?}");
    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});


app.Run();
