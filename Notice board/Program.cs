using Microsoft.EntityFrameworkCore;
using Data;
using Microsoft.AspNetCore.Identity;
using Notice_board.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Notice_board.Services;

var builder = WebApplication.CreateBuilder(args);

string connStr = builder.Configuration.GetConnectionString("LocalDb");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AdvertDbContext>(x => x.UseSqlServer(connStr));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<AdvertDbContext>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
               .AddDefaultTokenProviders()
               .AddDefaultUI()
               .AddEntityFrameworkStores<AdvertDbContext>();

builder.Services.AddHttpContextAccessor();

// add custom services
builder.Services.AddScoped<ILikeService, LikeSevice>();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(1);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    // seed roles
    var serviceProvider = scope.ServiceProvider;

    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    foreach (var role in Enum.GetNames(typeof(Roles)))
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    // seed admin
    var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

    const string USERNAME = "sergiy@gmail.com";
    const string PASSWORD = "Qwerty123!";

    var existingUser = userManager.FindByNameAsync(USERNAME).Result;

if (existingUser == null)
{
    var user = new IdentityUser
    {
        UserName = USERNAME,
        Email = USERNAME,
    };

    var result = userManager.CreateAsync(user, PASSWORD).Result;
    if (result.Succeeded)
    {
        userManager.AddToRoleAsync(user, "Admin").Wait();
    }
}
}





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

app.UseSession();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
