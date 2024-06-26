﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication3.Data;
using WebApplication3.Admin.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WebApplication3Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApplication3Context") ?? throw new InvalidOperationException("Connection string 'WebApplication3Context' not found.")));


var builder2 = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WebApplication3Context2>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApplication3Context") ?? throw new InvalidOperationException("Connection string 'WebApplication3Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    name: "Admin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
