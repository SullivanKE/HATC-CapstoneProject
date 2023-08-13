

using AspNetCoreHero.ToastNotification.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string? connectionString = builder.Configuration.GetConnectionString("MySqlConnection");
builder.Services.AddDbContext<HavenDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.Parse("mysql-8.0")));

builder.Services.AddIdentity<Player, IdentityRole>()
    .AddEntityFrameworkStores<HavenDbContext>()
    .AddRoles<IdentityRole>()
    .AddDefaultTokenProviders();

builder.Services.AddTransient<IHavenRepo, HavenRepo>();
builder.Services.AddTransient<Import<HavenDbContext>>();
builder.Services.AddControllersWithViews();
builder.Services.AddNotyf(config =>
{
    config.Position = NotyfPosition.TopCenter;
    config.DurationInSeconds = 4;
    config.IsDismissable = true;
});


WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    _ = app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    _ = app.UseHsts();
}

// app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseNotyf();
using (AsyncServiceScope scope = app.Services.CreateAsyncScope())
{
    await SeedUsers.CreateAdminUserAsync(scope.ServiceProvider);
    HavenDbContext context = scope.ServiceProvider.GetRequiredService<HavenDbContext>();
    SeedData.Seed1(context, scope.ServiceProvider);
    SeedData.Seed2(context, scope.ServiceProvider);
    SeedData.Seed3(context, scope.ServiceProvider);
    SeedData.Seed4(context, scope.ServiceProvider);
    SeedData.Seed5(context, scope.ServiceProvider);
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
