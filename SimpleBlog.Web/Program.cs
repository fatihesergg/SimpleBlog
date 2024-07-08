using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using SimpleBlog.Business;
using SimpleBlog.Business.Service.Abstract;
using SimpleBlog.Business.Service.Concrete;
using SimpleBlog.DAL;
using SimpleBlog.DAL.DTO;
using SimpleBlog.DAL.Repository.Abstract;
using SimpleBlog.DAL.Repository.Concrete;
using SimpleBlog.Entity;
using SimpleBlog.Web;
using SimpleBlog.Web.Mapper;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication();
builder.Services.AddDbContext<BlogDbContext>(configure => configure.UseSqlServer("Data Source=localhost;Initial Catalog=SimpleBlog;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True"), contextLifetime: ServiceLifetime.Singleton);
builder.Services.AddIdentity<User, IdentityRole>()
        .AddEntityFrameworkStores<BlogDbContext>();
builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(PostProfile), typeof(CategoryProfile));

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Post}/{action=Index}/{id?}");

app.Run();
