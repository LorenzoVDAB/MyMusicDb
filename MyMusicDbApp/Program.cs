using MyMusicDbServices; 

var builder = WebApplication.CreateBuilder(args);

// Add services to project 
builder.Services.AddScoped<ArtistsService>();

builder.Services.AddControllersWithViews();
//Use the IServiceCollectionExtension to extend Services with a custom method 'ConfigureServices'
builder.Services.ConfigureServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
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
