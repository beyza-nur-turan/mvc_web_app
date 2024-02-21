using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;
using StoreApp.Models;
using StoreApp.Services;
using StoreApp.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();//controller olmadanda razer pageleri kullanabilecek bir servisi uygulamaya dahil ettik
builder.Services.AddDbContext<RepositoryContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"),
    b => b.MigrationsAssembly("StoreApp"));
});
//session için aşağıdaki kaydı konteynıra yapmamız lazım
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options=>
{
    options.Cookie.Name="StoreApp.Session";
    options.IdleTimeout=TimeSpan.FromMinutes(10);//10 dk bu bilgileri tut.10dk sonra yeni istek gelmediyse oturumu kapat dedik
});
//IHttpContextAccessor arayüzünü uygulayan HttpContextAccessor sınıfını, uygulamanın servis
// koleksiyonuna ekler. Bu, uygulama içinde HttpContext nesnesine erişim sağlamak için kullanılır.
//IHttpContextAccessor, HTTP istekleri ve yanıtları ile ilgili bilgilere erişim sağlar ve
// genellikle middleware veya servis sınıfları tarafından kullanılır. Bu nesne, örneğin kullanıcının
// IP adresi, tarayıcı bilgileri ve diğer HTTP bağlam bilgilerine erişim sağlar.
builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IOrderService, OrderManager>();


builder.Services.AddScoped<Cart>(c=>SessionCart.GetCart(c)); //buraya addsingleton deseydim o zaman sepet her yerde aynı olacaktı.
//bu ne demek yani atıyorum chromede sepete bir şey eklediğimizde bunu edge de açan kullanıcıda görecekti halbuki bu kullanıcı farklı
//yani addscoped ile her kullanıcı için ayrı bir cart nesnesi oluşturulacak

builder.Services.AddAutoMapper(typeof(Program));//automapper service kaydı gerçekleştirildi. böylece automapper kullanılabilecek
var app = builder.Build();
app.UseStaticFiles();//wwwroot klasörünü kullanılabilir hale getirdik
app.UseHttpsRedirection();
app.UseRouting();
app.UseSession();
app.UseEndpoints(endpoints =>
{   
    endpoints.MapAreaControllerRoute("Admin","Admin","Admin/{controller=Dashboard}/{action=Index}/{id?}");
    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});


app.Run();
