using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using IdentityTemplate.Data;
using IdentityTemplate.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using IdentityTemplate.Helpers;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ApplicationDBContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDBContextConnection' not found.");

#region servicios locales
builder.Services.AddTransient<ICatalogosHelpers, CatalogosHelpers>();
#endregion


builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => 
     options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDBContext>();

builder.Services.AddRazorPages();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Configuracion de la contraseña.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Configuración del registro de nuevas cuentas
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;

    // Default User settings.
    options.User.AllowedUserNameCharacters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._";
    options.User.RequireUniqueEmail = true;

});

#region Ruta por defecto para usuarios no autenticados
builder.Services.ConfigureApplicationCookie( b => 

    b.LoginPath = "/Cuenta/Login"

);
#endregion

#region Fallback authorization policy
//builder.Services.AddAuthorization(options =>
//{
//    options.FallbackPolicy = new AuthorizationPolicyBuilder()
//        .RequireAuthenticatedUser()
//        .Build();
//});
#endregion

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();


#region Seeder de la base de datos
//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    var context = services.GetRequiredService<ApplicationDBContext>();
//    context.Database.Migrate();

//    //Revisar el archivo appsettings.json para ver la contraseña
//    var testUserPw = builder.Configuration["ConnectionStrings:DefaultPassword"];

//    await SeedData.Initialize(services, testUserPw);
//}
#endregion

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cuenta}/{action=Login}/{id?}");

app.MapRazorPages();

app.Run();
