using System;
using Microsoft.EntityFrameworkCore;
using DAL.Models;
using DAL.Enums;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace DAL.Data
{
    public static class DataInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            User user = new()
            {
                Id = 1,
                City = "Breclav",
                Street = "Hlavni",
                StNumber = 15,
                ZipCode = 03605,
                Name = "admin",
                Email = "admin@mail.com",
                Password = "79znGdbjJimGOZQdZVxcYNDAd+mJZjqP76afOyQXGuY=",
                Salt = "tY+cZjt0T9wFwkkBE46bkQ==",
                Phone = "911999111",
                BirthDate = new DateTime(1970, 3, 1),
                Group = Group.Admin,
            };

            User user2 = new()
            {
                Id = 2,
                City = "Brno",
                Street = "Manesova",
                StNumber = 13,
                ZipCode = 03601,
                Name = "Peter Marcin",
                Email = "peter@mail.com",
                Password = "79znGdbjJimGOZQdZVxcYNDAd+mJZjqP76afOyQXGuY=",
                Salt = "tY+cZjt0T9wFwkkBE46bkQ==",
                Phone = "+421911999222",
                BirthDate = new DateTime(1980, 3, 1),
                Group = Group.Employee,
            };

            User user3 = new()
            {
                Id = 3,
                City = "Praha",
                Street = "Prazska",
                StNumber = 9,
                ZipCode = 03602,
                Name = "Ferko Turan",
                Email = "feroslav1@mail.com",
                Password = "79znGdbjJimGOZQdZVxcYNDAd+mJZjqP76afOyQXGuY=",
                Salt = "tY+cZjt0T9wFwkkBE46bkQ==",
                Phone = "+421911999333",
                BirthDate = new DateTime(1983, 3, 1),
                Group = Group.User,
            };

            User user4 = new()
            {
                Id = 4,
                City = "Ostrava",
                Street = "Ostravska",
                StNumber = 1,
                ZipCode = 03603,
                Name = "Patrik Vrbovsky",
                Email = "patrik@mail.com",
                Password = "79znGdbjJimGOZQdZVxcYNDAd+mJZjqP76afOyQXGuY=",
                Salt = "tY+cZjt0T9wFwkkBE46bkQ==",
                Phone = "+421911999540",
                BirthDate = new DateTime(1991, 3, 1),
                Group = Group.User,
            };

            User user5 = new()
            {
                Id = 5,
                City = "Brno",
                Street = "Manesova",
                StNumber = 12,
                ZipCode = 03601,
                Name = "Maurice Richard",
                Email = "strelec32@mail.com",
                Password = "79znGdbjJimGOZQdZVxcYNDAd+mJZjqP76afOyQXGuY=",
                Salt = "tY+cZjt0T9wFwkkBE46bkQ==",
                Phone = "+421911999489",
                BirthDate = new DateTime(2010, 3, 1),
                Group = Group.User,
            };

            modelBuilder.Entity<User>().HasData(user);
            modelBuilder.Entity<User>().HasData(user2);
            modelBuilder.Entity<User>().HasData(user3);
            modelBuilder.Entity<User>().HasData(user4);
            modelBuilder.Entity<User>().HasData(user5);
            ///////////////////////////////////////////////////


            ///////////////////////////////////////////////////
            // ENTITY => Author Initialization

            Author author1 = new()
            {
                Id = 1,
                Name = "Joanne Rowling",
            };

            Author author2 = new()
            {
                Id = 2,
                Name = "George Martin",
            };

            Author author3 = new()
            {
                Id = 3,
                Name = "Robert Merle",
            };

            Author author4 = new()
            {
                Id = 4,
                Name = "Andrzej Sapkowski",
            };

            Author author5 = new()
            {
                Id = 5,
                Name = "Karel Hynek Mácha",
            };

            modelBuilder.Entity<Author>().HasData(author1);
            modelBuilder.Entity<Author>().HasData(author2);
            modelBuilder.Entity<Author>().HasData(author3);
            modelBuilder.Entity<Author>().HasData(author4);
            modelBuilder.Entity<Author>().HasData(author5);
            ///////////////////////////////////////////////////


            ///////////////////////////////////////////////////
            // ENTITY => Genre Initialization

            Genre genre1 = new()
            {
                Id = 1,
                Name = "Action",
            };

            Genre genre2 = new()
            {
                Id = 2,
                Name = "Horror",
            };

            Genre genre3 = new()
            {
                Id = 3,
                Name = "Thriller",
            };

            Genre genre4 = new()
            {
                Id = 4,
                Name = "Comedy",
            };

            Genre genre5 = new()
            {
                Id = 5,
                Name = "Detective",
            };

            Genre genre6 = new()
            {
                Id = 6,
                Name = "Fantasy",
            };

            Genre genre7 = new()
            {
                Id = 7,
                Name = "SciFi",
            };

            Genre genre8 = new()
            {
                Id = 8,
                Name = "Romance",
            };

            Genre genre9 = new()
            {
                Id = 9,
                Name = "Western",
            };

            Genre genre10 = new()
            {
                Id = 10,
                Name = "Dystopian",
            };

            Genre genre11 = new()
            {
                Id = 11,
                Name = "Contemporary",
            };
            modelBuilder.Entity<Genre>().HasData(genre1);
            modelBuilder.Entity<Genre>().HasData(genre2);
            modelBuilder.Entity<Genre>().HasData(genre3);
            modelBuilder.Entity<Genre>().HasData(genre4);
            modelBuilder.Entity<Genre>().HasData(genre5);
            modelBuilder.Entity<Genre>().HasData(genre6);
            modelBuilder.Entity<Genre>().HasData(genre7);
            modelBuilder.Entity<Genre>().HasData(genre8);
            modelBuilder.Entity<Genre>().HasData(genre9);
            modelBuilder.Entity<Genre>().HasData(genre10);
            modelBuilder.Entity<Genre>().HasData(genre11);
            ///////////////////////////////////////////////////


            ///////////////////////////////////////////////////
            // ENTITY => Book, Data Initializaton

            Book harryPotter1 = new()
            {
                Id = 1,
                Name = "Harry Potter and the Philosopher's Stone",
                AuthorId = 1,
                GenreId = 6,
                Stock = 63,
                Total = 100,
                Price = 16,
                Description = "d",
                Photo = "www.harrrypotterphotos.com",
            };

            Book harryPotter2 = new()
            {
                Id = 2,
                Name = "Harry Potter and the Chamber of Secrets",
                AuthorId = 1,
                Stock = 72,
                GenreId = 7,
                Total = 100,
                Price = 30,
                Description = "djosfjsdopj",
                Photo = "www.jupijupijej.com",
            };

            Book harryPotter3 = new()
            {
                Id = 3,
                Name = "Harry Potter and the Prisoner of Azkaban",
                AuthorId = 1,
                GenreId = 6,
                Stock = 900,
                Total = 1000,
                Price = 17,
                Description = "djosfjsdopj",
                Photo = "wwww.someweb.com",
            };

            Book harryPotter4 = new()
            {
                Id = 4,
                Name = "Harry Potter and the Goblet of Fire",
                AuthorId = 1,
                GenreId = 7,
                Stock = 150,
                Total = 200,
                Price = 27,
                Description = "djosfjsdopj",
                Photo = "www.uzneviemuz.com",
            };

            Book harryPotter5 = new()
            {
                Id = 5,
                Name = "Harry Potter and the Order of the Phoenix",
                AuthorId = 1,
                GenreId = 6,
                Stock = 7,
                Total = 50,
                Price = 50,
                Description = "djosfjsdopj",
                Photo = "www.harrymaguire.com",
            };

            Book harryPotter6 = new()
            {
                Id = 6,
                Name = "Harry Potter and the Half-Blood Prince",
                AuthorId = 1,
                GenreId = 8,
                Stock = 15,
                Total = 40,
                Price = 30,
                Description = "djosfjsdopj",
                Photo = "www.slafgoalsky.com",
            };

            Book gameOfThrones1 = new()
            {
                Id = 7,
                Name = "Fire & Blood",
                AuthorId = 2,
                GenreId = 6,
                Stock = 90,
                Total = 100,
                Price = 23,
                Description = "djosfjsdopj",
                Photo = "www.cobra11istheworstseries.com",
            };

            Book gameOfThrones2 = new()
            {
                Id = 8,
                Name = "A Game of Thrones",
                AuthorId = 2,
                GenreId = 6,
                Stock = 79,
                Total = 100,
                Price = 35,
                Description = "djosfjsdopj",
                Photo = "www.gameofthronesphotos.com",
            };

            Book gameOfThrones3 = new()
            {
                Id = 9,
                Name = "A Clash of Kings ",
                AuthorId = 2,
                GenreId = 6,
                Stock = 13,
                Total = 100,
                Price = 46,
                Description = "djosfjsdopj",
                Photo = "www.myphoto.com",
            };

            Book gameOfThrones4 = new()
            {
                Id = 10,
                Name = "A Storm of Swords ",
                AuthorId = 2,
                GenreId = 6,
                Stock = 50,
                Total = 100,
                Price = 25,
                Description = "djosfjsdopj",
                Photo = "www.yourphoto.com",
            };

            Book gameOfThrones5 = new()
            {
                Id = 11,
                Name = "A Feast for Crows",
                AuthorId = 2,
                GenreId = 6,
                Stock = 1,
                Total = 100,
                Price = 9000,
                Description = "djosfjsdopj",
                Photo = "www.amazingphoto.com",
            };


            modelBuilder.Entity<Book>().HasData(harryPotter1);
            modelBuilder.Entity<Book>().HasData(harryPotter2);
            modelBuilder.Entity<Book>().HasData(harryPotter3);
            modelBuilder.Entity<Book>().HasData(harryPotter4);
            modelBuilder.Entity<Book>().HasData(harryPotter5);
            modelBuilder.Entity<Book>().HasData(harryPotter6);
            modelBuilder.Entity<Book>().HasData(gameOfThrones1);
            modelBuilder.Entity<Book>().HasData(gameOfThrones2);
            modelBuilder.Entity<Book>().HasData(gameOfThrones3);
            modelBuilder.Entity<Book>().HasData(gameOfThrones4);
            modelBuilder.Entity<Book>().HasData(gameOfThrones5);
            ///////////////////////////////////////////////////

            ///////////////////////////////////////////////////
            // ENTITY => Review, Data Initializaton

            Review review1 = new()
            {
                Id = 1,
                Score = 9,
                UserId = 5,
                BookId = 5,
            };

            Review review2 = new()
            {
                Id = 2,
                Score = 5,
                UserId = 5,
                BookId = 4,
            };

            Review review3 = new()
            {
                Id = 3,
                Score = 7,
                UserId = 4,
                BookId = 5,
            };

            Review review4 = new()
            {
                Id = 4,
                Score = 3,
                UserId = 4,
                BookId = 4,
            };

            Review review5 = new()
            {
                Id = 5,
                Score = 8,
                UserId = 3,
                BookId = 5,
            };

            Review review6 = new()
            {
                Id = 6,
                Score = 9,
                UserId = 2,
                BookId = 4,
            };

            Review review7 = new()
            {
                Id = 7,
                Score = 7,
                UserId = 4,
                BookId = 3,
            };

            Review review8 = new()
            {
                Id = 8,
                Score = 9,
                UserId = 4,
                BookId = 6,
            };

            Review review9 = new()
            {
                Id = 9,
                Score = 7,
                UserId = 3,
                BookId = 3,
                Description = "Better than average",
            };

            Review review10 = new()
            {
                Id = 10,
                Score = 4,
                UserId = 4,
                BookId = 8,
                Description = "Not very good",
            };

            modelBuilder.Entity<Review>().HasData(review1);
            modelBuilder.Entity<Review>().HasData(review2);
            modelBuilder.Entity<Review>().HasData(review3);
            modelBuilder.Entity<Review>().HasData(review4);
            modelBuilder.Entity<Review>().HasData(review5);
            modelBuilder.Entity<Review>().HasData(review6);
            modelBuilder.Entity<Review>().HasData(review7);
            modelBuilder.Entity<Review>().HasData(review8);
            modelBuilder.Entity<Review>().HasData(review9);
            modelBuilder.Entity<Review>().HasData(review10);
            ///////////////////////////////////////////////////


            ///////////////////////////////////////////////////
            // ENTITY => Rent, Data Initializaton

            Reservation rent = new()
            {
                Id = 1,
                UserId = 1,
                BookId = 11,
                ReservedAt = new DateTime(2022, 9, 1),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 20,
                TotalPrice = 200,
                State = RentState.Reserved,
            };

            Reservation rent1 = new()
            {
                Id = 2,
                UserId = 1,
                BookId = 6,
                ReservedAt = new DateTime(2022, 9, 1),
                RentedAt = new DateTime(2022, 9, 5),
                ReturnedAt = null,
                LoanPeriod = 1,
                TotalPrice = 30,
                State = RentState.Active,
            };

            Reservation rent2 = new()
            {
                Id = 3,
                UserId = 1,
                BookId = 7,
                ReservedAt = new DateTime(2021, 9, 1),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 20,
                TotalPrice = 50,
                State = RentState.Expired,
            };

            Reservation rent3 = new()
            {
                Id = 4,
                UserId = 1,
                BookId = 2,
                ReservedAt = new DateTime(2021, 10, 1),
                RentedAt = new DateTime(2021, 10, 3),
                ReturnedAt = new DateTime(2021, 10, 15),
                LoanPeriod = 20,
                TotalPrice = 200,
                State = RentState.Returned,
            };

            Reservation rent4 = new()
            {
                Id = 5,
                UserId = 1,
                BookId = 1,
                ReservedAt = new DateTime(2020, 12, 5),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 120,
                TotalPrice = 150,
                State = RentState.Canceled,
            };

            Reservation rent5 = new()
            {
                Id = 6,
                UserId = 1,
                BookId = 1,
                ReservedAt = new DateTime(2020, 9, 2),
                RentedAt = new DateTime(2020, 9, 6),
                ReturnedAt = null,
                LoanPeriod = 10,
                TotalPrice = 150,
                State = RentState.Overdue,
            };

            Reservation rent6 = new()
            {
                Id = 7,
                UserId = 1,
                BookId = 2,
                ReservedAt = new DateTime(2021, 9, 2),
                RentedAt = new DateTime(2021, 9, 5),
                ReturnedAt = new DateTime(2021, 9, 29),
                LoanPeriod = 30,
                TotalPrice = 150,
                State = RentState.Returned,
            };

            Reservation rent7 = new()
            {
                Id = 8,
                UserId = 1,
                BookId = 3,
                ReservedAt = new DateTime(2022, 10, 1),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 3,
                TotalPrice = 150,
                State = RentState.Reserved,
            };

            Reservation rent8 = new()
            {
                Id = 9,
                UserId = 1,
                BookId = 2,
                ReservedAt = new DateTime(2021, 10, 1),
                RentedAt = new DateTime(2021, 10, 3),
                ReturnedAt = new DateTime(2021, 10, 15),
                LoanPeriod = 5,
                TotalPrice = 200,
                State = RentState.Returned,
            };

            Reservation rent9 = new()
            {
                Id = 10,
                UserId = 1,
                BookId = 1,
                ReservedAt = new DateTime(2020, 12, 5),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 1,
                TotalPrice = 16,
                State = RentState.Canceled,
            };

            Reservation rent10 = new()
            {
                Id = 11,
                UserId = 1,
                BookId = 1,
                ReservedAt = new DateTime(2020, 12, 5),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 1,
                TotalPrice = 16,
                State = RentState.Canceled,
            };

            Reservation rent11 = new()
            {
                Id = 12,
                UserId = 1,
                BookId = 1,
                ReservedAt = new DateTime(2020, 12, 5),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 1,
                TotalPrice = 16,
                State = RentState.Canceled,
            };

            Reservation rent12 = new()
            {
                Id = 13,
                UserId = 1,
                BookId = 1,
                ReservedAt = new DateTime(2020, 12, 5),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 1,
                TotalPrice = 16,
                State = RentState.Canceled,
            };

            Reservation rent13 = new()
            {
                Id = 14,
                UserId = 1,
                BookId = 1,
                ReservedAt = new DateTime(2020, 12, 5),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 1,
                TotalPrice = 16,
                State = RentState.Canceled,
            };
            Reservation rent14 = new()
            {
                Id = 15,
                UserId = 1,
                BookId = 1,
                ReservedAt = new DateTime(2020, 12, 5),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 1,
                TotalPrice = 16,
                State = RentState.Canceled,
            };

            Reservation rent15 = new()
            {
                Id = 16,
                UserId = 1,
                BookId = 1,
                ReservedAt = new DateTime(2020, 12, 5),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 1,
                TotalPrice = 16,
                State = RentState.Canceled,
            };

            Reservation rent16 = new()
            {
                Id = 17,
                UserId = 1,
                BookId = 1,
                ReservedAt = new DateTime(2020, 12, 5),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 1,
                TotalPrice = 16,
                State = RentState.Canceled,
            };

            Reservation rent17 = new()
            {
                Id = 18,
                UserId = 1,
                BookId = 1,
                ReservedAt = new DateTime(2020, 12, 5),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 1,
                TotalPrice = 16,
                State = RentState.Canceled,
            };

            Reservation rent18 = new()
            {
                Id = 19,
                UserId = 1,
                BookId = 1,
                ReservedAt = new DateTime(2020, 12, 5),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 1,
                TotalPrice = 16,
                State = RentState.Canceled,
            };

            Reservation rent19 = new()
            {
                Id = 20,
                UserId = 1,
                BookId = 1,
                ReservedAt = new DateTime(2020, 12, 5),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 1,
                TotalPrice = 16,
                State = RentState.Canceled,
            };

            Reservation rent20 = new()
            {
                Id = 21,
                UserId = 1,
                BookId = 1,
                ReservedAt = new DateTime(2020, 12, 5),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 1,
                TotalPrice = 16,
                State = RentState.Canceled,
            };

            Reservation rent21 = new()
            {
                Id = 22,
                UserId = 1,
                BookId = 1,
                ReservedAt = new DateTime(2020, 12, 5),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 1,
                TotalPrice = 16,
                State = RentState.Canceled,
            };

            Reservation rent22 = new()
            {
                Id = 23,
                UserId = 1,
                BookId = 1,
                ReservedAt = new DateTime(2020, 12, 5),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 1,
                TotalPrice = 16,
                State = RentState.Canceled,
            };

            Reservation rent23 = new()
            {
                Id = 24,
                UserId = 1,
                BookId = 1,
                ReservedAt = new DateTime(2020, 12, 5),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 1,
                TotalPrice = 16,
                State = RentState.Canceled,
            };

            Reservation rent24 = new()
            {
                Id = 25,
                UserId = 1,
                BookId = 1,
                ReservedAt = new DateTime(2020, 12, 5),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 1,
                TotalPrice = 16,
                State = RentState.Canceled,
            };

            Reservation rent25 = new()
            {
                Id = 26,
                UserId = 1,
                BookId = 1,
                ReservedAt = new DateTime(2020, 12, 5),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 1,
                TotalPrice = 16,
                State = RentState.Canceled,
            };

            Reservation rent26 = new()
            {
                Id = 27,
                UserId = 1,
                BookId = 1,
                ReservedAt = new DateTime(2020, 12, 5),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 1,
                TotalPrice = 16,
                State = RentState.Canceled,
            };

            Reservation rent27 = new()
            {
                Id = 28,
                UserId = 1,
                BookId = 1,
                ReservedAt = new DateTime(2020, 12, 5),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 1,
                TotalPrice = 16,
                State = RentState.Canceled,
            };

            Reservation rent28 = new()
            {
                Id = 29,
                UserId = 1,
                BookId = 1,
                ReservedAt = new DateTime(2020, 12, 5),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 1,
                TotalPrice = 16,
                State = RentState.Canceled,
            };

            Reservation rent29 = new()
            {
                Id = 30,
                UserId = 1,
                BookId = 1,
                ReservedAt = new DateTime(2020, 12, 5),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 1,
                TotalPrice = 16,
                State = RentState.Canceled,
            };

            Reservation rent30 = new()
            {
                Id = 31,
                UserId = 1,
                BookId = 1,
                ReservedAt = new DateTime(2020, 12, 5),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 1,
                TotalPrice = 16,
                State = RentState.Canceled,
            };

            Reservation rent31 = new()
            {
                Id = 32,
                UserId = 1,
                BookId = 1,
                ReservedAt = new DateTime(2020, 12, 5),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 1,
                TotalPrice = 16,
                State = RentState.Canceled,
            };

            Reservation rent32 = new()
            {
                Id = 33,
                UserId = 1,
                BookId = 2,
                ReservedAt = new DateTime(2020, 12, 5),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 1,
                TotalPrice = 16,
                State = RentState.Canceled,
            };

            Reservation rent33 = new()
            {
                Id = 34,
                UserId = 1,
                BookId = 2,
                ReservedAt = new DateTime(2020, 12, 5),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 1,
                TotalPrice = 16,
                State = RentState.Canceled,
            };

            Reservation rent34 = new()
            {
                Id = 35,
                UserId = 1,
                BookId = 1,
                ReservedAt = new DateTime(2020, 12, 5),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 1,
                TotalPrice = 16,
                State = RentState.Canceled,
            };

            Reservation rent35 = new()
            {
                Id = 36,
                UserId = 1,
                BookId = 1,
                ReservedAt = new DateTime(2020, 12, 5),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 1,
                TotalPrice = 16,
                State = RentState.Canceled,
            };

            Reservation rent36 = new()
            {
                Id = 37,
                UserId = 1,
                BookId = 1,
                ReservedAt = new DateTime(2020, 12, 5),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 1,
                TotalPrice = 16,
                State = RentState.Canceled,
            };

            Reservation rent37 = new()
            {
                Id = 38,
                UserId = 1,
                BookId = 1,
                ReservedAt = new DateTime(2020, 12, 5),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 1,
                TotalPrice = 16,
                State = RentState.Canceled,
            };

            Reservation rent38 = new()
            {
                Id = 39,
                UserId = 4,
                BookId = 11,
                ReservedAt = new DateTime(2022, 9, 1),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 20,
                TotalPrice = 200,
                State = RentState.Reserved,
            };
            modelBuilder.Entity<Reservation>().HasData(rent);
            modelBuilder.Entity<Reservation>().HasData(rent1);
            modelBuilder.Entity<Reservation>().HasData(rent2);
            modelBuilder.Entity<Reservation>().HasData(rent3);
            modelBuilder.Entity<Reservation>().HasData(rent4);
            modelBuilder.Entity<Reservation>().HasData(rent5);
            modelBuilder.Entity<Reservation>().HasData(rent6);
            modelBuilder.Entity<Reservation>().HasData(rent7);
            modelBuilder.Entity<Reservation>().HasData(rent8);
            modelBuilder.Entity<Reservation>().HasData(rent9);
            modelBuilder.Entity<Reservation>().HasData(rent10);
            modelBuilder.Entity<Reservation>().HasData(rent11);
            modelBuilder.Entity<Reservation>().HasData(rent12);
            modelBuilder.Entity<Reservation>().HasData(rent13);
            modelBuilder.Entity<Reservation>().HasData(rent14);
            modelBuilder.Entity<Reservation>().HasData(rent15);
            modelBuilder.Entity<Reservation>().HasData(rent16);
            modelBuilder.Entity<Reservation>().HasData(rent17);
            modelBuilder.Entity<Reservation>().HasData(rent18);
            modelBuilder.Entity<Reservation>().HasData(rent19);
            modelBuilder.Entity<Reservation>().HasData(rent20);
            modelBuilder.Entity<Reservation>().HasData(rent21);
            modelBuilder.Entity<Reservation>().HasData(rent22);
            modelBuilder.Entity<Reservation>().HasData(rent23);
            modelBuilder.Entity<Reservation>().HasData(rent24);
            modelBuilder.Entity<Reservation>().HasData(rent25);
            modelBuilder.Entity<Reservation>().HasData(rent26);
            modelBuilder.Entity<Reservation>().HasData(rent27);
            modelBuilder.Entity<Reservation>().HasData(rent28);
            modelBuilder.Entity<Reservation>().HasData(rent29);
            modelBuilder.Entity<Reservation>().HasData(rent30);
            modelBuilder.Entity<Reservation>().HasData(rent31);
            modelBuilder.Entity<Reservation>().HasData(rent32);
            modelBuilder.Entity<Reservation>().HasData(rent33);
            modelBuilder.Entity<Reservation>().HasData(rent34);
            modelBuilder.Entity<Reservation>().HasData(rent35);
            modelBuilder.Entity<Reservation>().HasData(rent36);
            modelBuilder.Entity<Reservation>().HasData(rent37);
            modelBuilder.Entity<Reservation>().HasData(rent38);
            ///////////////////////////////////////////////////

            ///////////////////////////////////////////////////
            // ENTITY => ReservationItem, Data Initializaton

            CartItem resItem = new()
            {
                Id = 1,
                UserId = 5,
                BookId = 6,
                LoanPeriod = 7,
            };

            CartItem resItem2 = new()
            {
                Id = 2,
                UserId = 5,
                BookId = 7,
                LoanPeriod = 10,
            };

            CartItem resItem3 = new()
            {
                Id = 3,
                UserId = 5,
                BookId = 8,
                LoanPeriod = 5,
            };

            CartItem resItem4 = new()
            {
                Id = 4,
                UserId = 5,
                BookId = 9,
                LoanPeriod = 3,
            };

            CartItem resItem5 = new()
            {
                Id = 5,
                UserId = 5,
                BookId = 10,
                LoanPeriod = 1,
            };

            modelBuilder.Entity<CartItem>().HasData(resItem);
            modelBuilder.Entity<CartItem>().HasData(resItem2);
            modelBuilder.Entity<CartItem>().HasData(resItem3);
            modelBuilder.Entity<CartItem>().HasData(resItem4);
            modelBuilder.Entity<CartItem>().HasData(resItem5);
            ///////////////////////////////////////////////////

        }
    }
}
