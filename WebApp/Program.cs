using Microsoft.EntityFrameworkCore;
using Web.Data.Data;
using Web.Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using WebApp.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);


//This - part is get updated to add the role for the identity users
//builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<ApplicationDbContext>();

//                                                                                                          AddDefaultTokenProviders -IMP **
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddRazorPages(); // This is added for running of the identity pages which are razor pages
builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddScoped<IEmailSender,EmailSender>();  // This line is added to avoid error comes - after seeding the role in OnGetAsync method in D:\Learning\Asp.Net Mvc\WebApp\WebApp\Areas\Identity\Pages\Account\Register.cshtml.cs 


var app = builder.Build();

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
app.UseAuthentication(); // Always add this before authorization.
app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();
