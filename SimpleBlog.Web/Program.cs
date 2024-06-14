using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SimpleBlog.Business.Service.Abstract;
using SimpleBlog.Business.Service.Concrete;
using SimpleBlog.DAL;
using SimpleBlog.DAL.DTO;
using SimpleBlog.DAL.Repository.Abstract;
using SimpleBlog.DAL.Repository.Concrete;
using SimpleBlog.Web.Mapper;
using SimpleBlog.Web.Validations;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BlogDbContext>(configure => configure.UseSqlServer("Data Source=localhost;Initial Catalog=SimpleBlog;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True"));
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IPostService, PostService>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IPostRepository, PostRepository>();   
builder.Services.AddScoped<IValidator<AddPostDTO>, AddPostDTOValidator>();
builder.Services.AddScoped<IValidator<AddPostCategoryDTO>, AddPostCategoryDTOValidator>();
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
