using System;
using System.Threading;
using AspNetCoreMvcIdentity.Data;
using AspNetCoreMvcIdentity.Models;
using AspNetCoreMvcIdentity.Services;
using AspNetCoreMvcIdentity.Application.Common.Interfaces;
using AspNetCoreMvcIdentity.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
        }));

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    options.SlidingExpiration = true;
});

// Add application services.
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();
builder.Services.AddScoped<IForum, ForumService>();
builder.Services.AddScoped<IPost, PostService>();
builder.Services.AddScoped<IApplicationUser, ApplicationUserService>();

// Clean Architecture / CQRS Infrastructure
builder.Services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
builder.Services.AddScoped<IUploadService, UploadService>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddAutoMapper(typeof(Program).Assembly);

//Seed Database
builder.Services.AddTransient<DataSeed>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var dataSeed = scope.ServiceProvider.GetRequiredService<DataSeed>();
    await dataSeed.SeedSuperUser();
    await dataSeed.SeedForumsAndPosts();
    await dataSeed.AssignAdminRoleManually();
    await dataSeed.SeedRoles();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Admin}/{action=Index}/{id?}");

app.Run();

public static class DatabaseManagementService
{
    public static void MigrationInitialisation(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            var serviceDb = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            if (serviceDb == null)
            {
                throw new InvalidOperationException("ApplicationDbContext not configured");
            }
            
            // Veritabanı bağlantısını bekle
            WaitForDatabase(serviceDb);
            
            serviceDb.Database.Migrate();
        }
    }

    private static void WaitForDatabase(ApplicationDbContext context)
    {
        var retry = 10;
        while (retry > 0)
        {
            try
            {
                context.Database.CanConnect();
                return;
            }
            catch (Exception)
            {
                retry--;
                if (retry == 0) throw;
                Thread.Sleep(5000);
            }
        }
    }
}
