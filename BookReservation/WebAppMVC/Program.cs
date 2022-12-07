using AutoMapper;
using BL.Config;
using BL.Services.CartItemServ;
using BL.Services.ReservationServ;
using BL.Services.StockServ;
using BL.Services.ReviewServ;
using BL.Services.BookServ;
using DAL;
using DAL.Models;
using Infrastructure.EFCore.Query;
using Infrastructure.EFCore.Repository;
using Infrastructure.EFCore.UnitOfWork;
using Infrastructure.Query;
using Infrastructure.Repository;
using Infrastructure.UnitOfWork;


var builder = WebApplication.CreateBuilder(args);


using (var db = new BookReservationDbContext())
{
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();
}

// Add services to the container.
builder.Services.AddSingleton<IMapper>(new Mapper(new MapperConfiguration(MappingConfig.ConfigureMapping)));

// Queries
builder.Services.AddTransient<IQuery<Author>, EFQuery<Author>>();
builder.Services.AddTransient<IQuery<Book>, EFQuery<Book>>();
builder.Services.AddTransient<IQuery<CartItem>, EFQuery<CartItem>>();
builder.Services.AddTransient<IQuery<Genre>, EFQuery<Genre>>();
builder.Services.AddTransient<IQuery<Reservation>, EFQuery<Reservation>>();
builder.Services.AddTransient<IQuery<Review>, EFQuery<Review>>();
builder.Services.AddTransient<IQuery<User>, EFQuery<User>>();

// Context
builder.Services.AddScoped<BookReservationDbContext, BookReservationDbContext>();

// Repositories DI Setup
builder.Services.AddScoped<IRepository<Book>, EFGenericRepository<Book>>();
builder.Services.AddScoped<IRepository<Author>, EFGenericRepository<Author>>();
builder.Services.AddScoped<IRepository<Genre>, EFGenericRepository<Genre>>();
builder.Services.AddScoped<IRepository<CartItem>, EFGenericRepository<CartItem>>();
builder.Services.AddScoped<IRepository<Reservation>, EFGenericRepository<Reservation>>();
builder.Services.AddScoped<IRepository<Review>, EFGenericRepository<Review>>();
builder.Services.AddScoped<IRepository<User>, EFGenericRepository<User>>();

// UnitOfWork DI Setup
builder.Services.AddScoped<IUoWBook, EFUoWBook>();
builder.Services.AddScoped<IUoWAuthor, EFUoWAuthor>();
builder.Services.AddScoped<IUoWCartItem, EFUoWCartItem>();
builder.Services.AddScoped<IUoWCartItem, EFUoWCartItem>();
builder.Services.AddScoped<IUoWGenre, EFUoWGenre>();
builder.Services.AddScoped<IUoWReservation, EFUoWReservation>();
builder.Services.AddScoped<IUoWReview, EFUoWReview>();
builder.Services.AddScoped<IUoWUserInfo, EFUoWUserInfo>();

// Services DI Setup
builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<ICartItemService, CartItemService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IBookService, BookService>();


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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
