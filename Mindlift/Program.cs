using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Mindlift.Data;
using Microsoft.Extensions.DependencyInjection;
using Mindlift.Models; // Ensure you include the correct namespace for ChatGPTClient

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                       ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

// Add IHttpClientFactory for HttpClient management
builder.Services.AddHttpClient();

// Register ChatGPTClient as a singleton and pass IConfiguration and IHttpClientFactory to the constructor
builder.Services.AddSingleton<ChatGPTClient>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();  // Get IConfiguration instance from DI container
    var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();  // Get IHttpClientFactory instance from DI container
    return new ChatGPTClient(configuration, httpClientFactory);  // Pass IConfiguration and IHttpClientFactory to ChatGPTClient constructor
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts(); // Use HSTS in production
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
