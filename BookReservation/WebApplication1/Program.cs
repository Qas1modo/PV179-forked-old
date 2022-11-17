using AutoMapper;
using BL.Config;
using DAL;
using DAL.Models;
using Infrastructure.EFCore.Query;
using Infrastructure.EFCore.Repository;
using Infrastructure.EFCore.UnitOfWork;
using Infrastructure.Query;
using Infrastructure.Repository;
using Infrastructure.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

using (var db = new BookReservationDbContext())
{
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();
}

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IMapper>(new Mapper(new MapperConfiguration(MappingConfig.ConfigureMapping)));

// Queries
builder.Services.AddTransient<IQuery<Author>, EFQuery<Author>>();
builder.Services.AddTransient<IQuery<Book>, EFQuery<Book>>();
builder.Services.AddTransient<IQuery<CartItem>, EFQuery<CartItem>>();
builder.Services.AddTransient<IQuery<Genre>, EFQuery<Genre>>();
builder.Services.AddTransient<IQuery<Rent>, EFQuery<Rent>>();
builder.Services.AddTransient<IQuery<Review>, EFQuery<Review>>();
builder.Services.AddTransient<IQuery<User>, EFQuery<User>>();

// Context
builder.Services.AddTransient<BookReservationDbContext, BookReservationDbContext>();

// Repositories DI Setup
builder.Services.AddSingleton<IRepository<BaseEntity>, EFGenericRepository<BaseEntity>>();
builder.Services.AddScoped<IRepository<Book>, EFGenericRepository<Book>>();
builder.Services.AddScoped<IRepository<Author>, EFGenericRepository<Author>>();
builder.Services.AddScoped<IRepository<Genre>, EFGenericRepository<Genre>>();
builder.Services.AddScoped<IRepository<CartItem>, EFGenericRepository<CartItem>>();

// UnitOfWork DI Setup
builder.Services.AddScoped<IUoWBook, EFUoWBook>();
builder.Services.AddScoped<IUoWCartItem, EFUoWCartItem>();
builder.Services.AddScoped<IUoWCartItems, EFUoWCartItems>();
builder.Services.AddScoped<IUoWGenre, EFUoWGenre>();
builder.Services.AddScoped<IUoWReservation, EFUoWReservation>();
builder.Services.AddScoped<IUoWReview, EFUoWReview>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
