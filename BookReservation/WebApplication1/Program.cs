using AutoMapper;
using BL.Config;
using BL.Services.CRUD;
using DAL;
using DAL.Models;
using Infrastructure.EFCore.Query;
using Infrastructure.Query;
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
builder.Services.AddTransient<IQuery<BaseEntity>>(new EFQuery);
builder.Services.AddSingleton<BookReservationDbContext, BookReservationDbContext>();


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
