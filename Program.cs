using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CPMS.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CPMSContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CPMSContext") ?? throw new InvalidOperationException("Connection string 'CPMSContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

//the two lines below are used to add sessions and session variables to the app 
//builder.Services.AddDistributedMemoryCache();
//builder.Services.AddSession();
//builder.Services.AddMvc();

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

//added to support session variables
//app.UseSession();
//app.UseCookiePolicy();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
