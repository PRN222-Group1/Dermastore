﻿using Dermastore.Domain.Entities;
using Dermastore.Domain.Interfaces;
using Dermastore.Infrastructure.Data;
using Dermastore.Infrastructure.Services;
using Dermastore.Infrastructure.Services.Firebase;
using Dermastore.Web.Components;
using Dermastore.Web.Extensions;
using Dermastore.Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddScoped<IFirebaseService, FirebaseService>();
builder.Services.AddScoped<IPromotionService, PromotionService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapHub<SignalRServer>(builder.Configuration["SignalRUrl"]);

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

try
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DermastoreContext>();
    var userManager = services.GetRequiredService<UserManager<User>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole<int>>>();
    await context.Database.MigrateAsync();
    await DermastoreContextSeed.SeedAsync(context, userManager, roleManager);
}
catch (Exception ex)
{
    Console.WriteLine(ex);
    throw;
}

app.Run();
