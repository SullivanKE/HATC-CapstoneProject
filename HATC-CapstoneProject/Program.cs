var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("MySqlConnection");
builder.Services.AddDbContext<HavenDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.Parse("mysql-8.0")));

builder.Services.AddIdentity<Player, IdentityRole>()
    .AddEntityFrameworkStores<HavenDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddTransient<IHavenRepo, HavenRepo>();
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    await SeedUsers.CreateAdminUserAsync(scope.ServiceProvider);
    var context = scope.ServiceProvider.GetRequiredService<HavenDbContext>();
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
