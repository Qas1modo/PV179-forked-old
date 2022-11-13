using AutoMapper;
using BL.Config;
using BL.Services.CRUD;
using DAL;
using DAL.Models;
using Infrastructure.EFCore.Query;
using Infrastructure.EFCore.Repository;
using Infrastructure.Query;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

using (var db = new BookReservationDbContext())
{
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();
}

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<ICRUDService<BaseEntity>, CRUDService<BaseEntity>>();
builder.Services.AddSingleton<IMapper>(new Mapper(new MapperConfiguration(MappingConfig.ConfigureMapping)));
builder.Services.AddTransient<IQuery<Address>, EFQuery<Address>>();
builder.Services.AddTransient<IQuery<Author>, EFQuery<Author>>();
builder.Services.AddTransient<IQuery<Book>, EFQuery<Book>>();
builder.Services.AddTransient<IQuery<CartItem>, EFQuery<CartItem>>();
builder.Services.AddTransient<IQuery<Genre>, EFQuery<Genre>>();
builder.Services.AddTransient<IQuery<Rent>, EFQuery<Rent>>();
builder.Services.AddTransient<IQuery<Review>, EFQuery<Review>>();
builder.Services.AddTransient<IQuery<ReviewPoint>, EFQuery<ReviewPoint>>();
builder.Services.AddTransient<IQuery<User>, EFQuery<User>>();
builder.Services.AddSingleton<BookReservationDbContext, BookReservationDbContext>();
builder.Services.AddSingleton<IRepository<BaseEntity>, EFGenericRepository<BaseEntity>>();

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
