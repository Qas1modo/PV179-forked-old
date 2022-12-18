using AutoMapper;
using BL.Services.CartItemServ;
using BL.Services.ReservationServ;
using BL.Services.StockServ;
using BL.Services.ReviewServ;
using BL.Services.BookServ;
using BL.Facades.OrderFac;
using BL.Facades.BookFac;
using DAL;
using DAL.Models;
using Infrastructure.EFCore.Query;
using Infrastructure.EFCore.Repository;
using Infrastructure.EFCore.UnitOfWork;
using Infrastructure.Query;
using Infrastructure.Repository;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using BL.Services.AuthServ;
using BL.QueryObjects;
using BL.Services.UserServ;
using BL.Services.GenreServ;
using BL.Services.AuthorServ;
using WebAppMVC.Config;
using BL.Facades.UserFac;
using BL.Services.WishListItemService;
using BL.Services.WishListItemServ;

var builder = WebApplication.CreateBuilder();

using (var db = new BookReservationDbContext())
{
    //db.Database.EnsureDeleted();
    db.Database.EnsureCreated();
}

builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<BookReservationDbContext>();

// Add services to the container.
builder.Services.AddSingleton<IMapper>(new Mapper(new MapperConfiguration(MappingConfig.ConfigureMapping)));

// Queries DI Setup
builder.Services.AddTransient<IQuery<Author>, EFQuery<Author>>();
builder.Services.AddTransient<IQuery<Book>, EFQuery<Book>>();
builder.Services.AddTransient<IQuery<CartItem>, EFQuery<CartItem>>();
builder.Services.AddTransient<IQuery<Genre>, EFQuery<Genre>>();
builder.Services.AddTransient<IQuery<Reservation>, EFQuery<Reservation>>();
builder.Services.AddTransient<IQuery<Review>, EFQuery<Review>>();
builder.Services.AddTransient<IQuery<User>, EFQuery<User>>();
builder.Services.AddTransient<IQuery<WishListItem>, EFQuery<WishListItem>>();


// Context DI Setup
builder.Services.AddScoped<BookReservationDbContext, BookReservationDbContext>();

// Repositories DI Setup
builder.Services.AddScoped<IRepository<Book>, EFGenericRepository<Book>>();
builder.Services.AddScoped<IRepository<Author>, EFGenericRepository<Author>>();
builder.Services.AddScoped<IRepository<Genre>, EFGenericRepository<Genre>>();
builder.Services.AddScoped<IRepository<CartItem>, EFGenericRepository<CartItem>>();
builder.Services.AddScoped<IRepository<Reservation>, EFGenericRepository<Reservation>>();
builder.Services.AddScoped<IRepository<Review>, EFGenericRepository<Review>>();
builder.Services.AddScoped<IRepository<User>, EFGenericRepository<User>>();
builder.Services.AddScoped<IRepository<WishListItem>, EFGenericRepository<WishListItem>>();

// UnitOfWork DI Setup
builder.Services.AddScoped<IUoWBook, EFUoWBook>();
builder.Services.AddScoped<IUoWAuthor, EFUoWAuthor>();
builder.Services.AddScoped<IUoWCartItem, EFUoWCartItem>();
builder.Services.AddScoped<IUoWCartItem, EFUoWCartItem>();
builder.Services.AddScoped<IUoWGenre, EFUoWGenre>();
builder.Services.AddScoped<IUoWReservation, EFUoWReservation>();
builder.Services.AddScoped<IUoWReview, EFUoWReview>();
builder.Services.AddScoped<IUoWUserInfo, EFUoWUserInfo>();
builder.Services.AddScoped<IUoWUser, EFUoWUser>();
builder.Services.AddScoped<IUoWWishList, EFUoWWishList>();

// Services DI Setup
builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<ICartItemService, CartItemService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IWishListItemService, WishListItemService>();

// Facades and QO DI Setup
builder.Services.AddScoped<IOrderFacade, OrderFacade>();
builder.Services.AddScoped<UserQueryObject, UserQueryObject>();
builder.Services.AddScoped<AuthorQueryObject, AuthorQueryObject>();
builder.Services.AddScoped<GenreQueryObject, GenreQueryObject>();
builder.Services.AddScoped<IBookFacade, BookFacade>();
builder.Services.AddScoped<IUserFacade, UserFacade>();


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(o =>
        {
            o.LoginPath = new PathString("/Auth/Login");
            o.AccessDeniedPath = new PathString("/MainPage/AceessDenied");
        });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/MainPage/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=MainPage}/{action=Index}/{id?}");

app.MapControllers();

app.Run();
