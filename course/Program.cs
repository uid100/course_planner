global using course.Models;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5215); // to listen for incoming http connection on port 5215
    options.ListenAnyIP(7215, configure => configure.UseHttps()); // to listen for incoming https connection on port 7215
});

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddTransient<ICollegeRepository, TestCollegeRepo>();
builder.Services.AddTransient<ICollegeRepository, JsonCollegeRepo>();
//builder.Services.AddTransient<ICourseRepository, TestCourseRepo>();
builder.Services.AddTransient<ICourseRepository, JsonCourseRepo>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
