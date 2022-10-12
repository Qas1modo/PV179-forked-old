using System;
using Microsoft.EntityFrameworkCore;
using DAL.Models;
using DAL.Enums;
using System.ComponentModel.DataAnnotations;

namespace DAL.Data
{
    public static class DataInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            ///////////////////////////////////////////////////
            // ENTITY => User, Data Initializaton

            User user = new()
            {
                Id = 1,
                AddressId = 1,
                Name = "admin",
                Email = "matkokukucko@mail.com",
                Password = "admin",
                Salt = "jfpajfafjaps",
                Phone = "+421911999111",
                BirthDate = new DateTime(1970, 3, 1),
                Group = Group.Admin,
                Picture = "www.nejakycuteobrazok.com",
            };

            User user2 = new ()
            {
                Id = 2,
                AddressId = 2,
                Name = "Peter Marcin",
                Email = "peter123@mail.com",
                Password = "jjpjpkf",
                Salt = "dkpafjapfjpak",
                Phone = "+421911999222",
                BirthDate = new DateTime(1980, 3, 1),
                Group = Group.Employee,
                Picture = "www.pictureofemployee.com",
            };

            User user3 = new ()
            {
                Id = 3,
                AddressId = 3,
                Name = "Ferko Turan",
                Email = "feroslav1@mail.com",
                Password = "mojeultraheslo",
                Salt = "dkpafjnpfjpak",
                Phone = "+421911999333",
                BirthDate = new DateTime(1983, 3, 1),
                Group = Group.User,
                Picture = "www.pictureofuser.com",
            };

            User user4 = new ()
            {
                Id = 4,
                AddressId = 4,
                Name = "Patrik Vrbovsky",
                Email = "uzanineviem@mail.com",
                Password = "JaMamLepsieHeslo",
                Salt = "dkyafjapfjpak",
                Phone = "+421911999540",
                BirthDate = new DateTime(1991, 3, 1),
                Group = Group.User,
                Picture = "www.pictureofdogs.com",
            };

            User user5 = new ()
            {
                Id = 5,
                AddressId = 5,
                Name = "Maurice Richard",
                Email = "strelec32@mail.com",
                Password = "bestPasswordEver123",
                Salt = "dkpafjgbpfjpak",
                Phone = "+421911999489",
                BirthDate = new DateTime(2010, 3, 1),
                Group = Group.User,
                Picture = "www.pictureofcat.com",
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
            // ENTITY => Address, Data Initializaton

            Address address1 = new()
            {
                Id = 1,
                City = "Brno",
                Street = "Manesova",
                StNumber = 12,
                ZipCode = 03601,
            };

            Address address2 = new()
            {
                Id = 2,
                City = "Brno",
                Street = "Manesova",
                StNumber = 13,
                ZipCode = 03601,
            };

            Address address3 = new()
            {
                Id = 3,
                City = "Praha",
                Street = "Prazska",
                StNumber = 9,
                ZipCode = 03602,
            };

            Address address4 = new()
            {
                Id = 4,
                City = "Ostrava",
                Street = "Ostravska",
                StNumber = 1,
                ZipCode = 03603,
            };

            Address address5 = new()
            {
                Id = 5,
                City = "Breclav",
                Street = "Hlavni",
                StNumber = 15,
                ZipCode = 03605,
            };

            modelBuilder.Entity<Address>().HasData(address1);
            modelBuilder.Entity<Address>().HasData(address2);
            modelBuilder.Entity<Address>().HasData(address3);
            modelBuilder.Entity<Address>().HasData(address4);
            modelBuilder.Entity<Address>().HasData(address5);
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
            };

            Review review10 = new()
            {
                Id = 10,
                Score = 4,
                UserId = 4,
                BookId = 8,
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
            // ENTITY => Positive Review, Data Initializaton

            ReviewPoint posReview = new ReviewPoint
            {
                Id = 1,
                Text = "to je tak super",
                ReviewId = 1,
                Positive = true,
            };

            ReviewPoint posReview1 = new ReviewPoint
            {
                Id = 2,
                Text = "to je tak super tiez",
                ReviewId = 1,
                Positive = true,
            };

            ReviewPoint posReview2 = new ReviewPoint
            {
                Id = 3,
                Text = "to je tak super tiez tiez",
                ReviewId = 1,
                Positive = true,
            };

            ReviewPoint posReview3 = new ReviewPoint
            {
                Id = 4,
                Text = "to je tak super tak isto ako aj to pred tym",
                ReviewId = 1,
                Positive = true,
            };

            ReviewPoint posReview4 = new ReviewPoint
            {
                Id = 5,
                Text = "to je tak super",
                ReviewId = 5,
                Positive = true,
            };

            ReviewPoint posReview5 = new ReviewPoint
            {
                Id = 6,
                Text = "to je tak super tiez",
                ReviewId = 5,
                Positive = true,
            };

            ReviewPoint posReview6 = new ReviewPoint
            {
                Id = 7,
                Text = "to je tak super tiez tiez",
                ReviewId = 5,
                Positive = true,
            };

            ReviewPoint posReview7 = new ReviewPoint
            {
                Id = 8,
                Text = "to je tak super tak isto ako aj to pred tym",
                ReviewId = 5,
                Positive = true,
            };

            ReviewPoint posReview8 = new ReviewPoint
            {
                Id = 9,
                Text = "to je tak super tiez",
                ReviewId = 6,
                Positive = true,
            };

            ReviewPoint posReview9 = new ReviewPoint
            {
                Id = 10,
                Text = "to je tak super tiez tiez",
                ReviewId = 6,
                Positive = true,
            };

            ReviewPoint posReview10 = new ReviewPoint
            {
                Id = 11,
                Text = "to je tak super tiez tiez",
                ReviewId = 6,
                Positive = true,
            };

            modelBuilder.Entity<ReviewPoint>().HasData(posReview);
            modelBuilder.Entity<ReviewPoint>().HasData(posReview1);
            modelBuilder.Entity<ReviewPoint>().HasData(posReview2);
            modelBuilder.Entity<ReviewPoint>().HasData(posReview3);
            modelBuilder.Entity<ReviewPoint>().HasData(posReview4);
            modelBuilder.Entity<ReviewPoint>().HasData(posReview5);
            modelBuilder.Entity<ReviewPoint>().HasData(posReview6);
            modelBuilder.Entity<ReviewPoint>().HasData(posReview7);
            modelBuilder.Entity<ReviewPoint>().HasData(posReview8);
            modelBuilder.Entity<ReviewPoint>().HasData(posReview9);
            modelBuilder.Entity<ReviewPoint>().HasData(posReview10);
            ///////////////////////////////////////////////////


            ///////////////////////////////////////////////////
            // ENTITY => Negative Review, Data Initializaton

            ReviewPoint negReview = new()
            {
                Id = 12,
                Text = "to je tak zle",
                ReviewId = 2,
                Positive = false,
            };

            ReviewPoint negReview1 = new()
            {
                Id = 13,
                Text = "to je tak zle tiez",
                ReviewId = 2,
                Positive = false,
            };

            ReviewPoint negReview2 = new()
            {
                Id = 14,
                Text = "to je tak zle tiez tiez",
                ReviewId = 1,
                Positive = false,
            };

            ReviewPoint negReview3 = new()
            {
                Id = 15,
                Text = "to je tak zle tak isto ako aj to pred tym",
                ReviewId = 2,
                Positive = false,
            };

            ReviewPoint negReview4 = new()
            {
                Id = 16,
                Text = "to je tak zle",
                ReviewId = 6,
                Positive = false,
            };

            ReviewPoint negReview5 = new()
            {
                Id = 17,
                Text = "to je tak super tiez",
                ReviewId = 6,
                Positive = false,
            };

            ReviewPoint negReview6 = new()
            {
                Id = 18,
                Text = "to je tak super tiez tiez",
                ReviewId = 6,
                Positive = false,
            };

            ReviewPoint negReview7 = new()
            {
                Id = 19,
                Text = "to je tak super tak isto ako aj to pred tym",
                ReviewId = 6,
                Positive = false,
            };

            ReviewPoint negReview8 = new()
            {
                Id = 20,
                Text = "to je tak super tiez",
                ReviewId = 3,
                Positive = false,
            };

            ReviewPoint negReview9 = new()
            {
                Id = 21,
                Text = "to je tak super tiez tiez",
                ReviewId = 3,
                Positive = false,
            };

            ReviewPoint negReview10 = new()
            {
                Id = 22,
                Text = "to je tak super tiez tiez",
                ReviewId = 3,
                Positive = false,
            };

            modelBuilder.Entity<ReviewPoint>().HasData(negReview);
            modelBuilder.Entity<ReviewPoint>().HasData(negReview1);
            modelBuilder.Entity<ReviewPoint>().HasData(negReview2);
            modelBuilder.Entity<ReviewPoint>().HasData(negReview3);
            modelBuilder.Entity<ReviewPoint>().HasData(negReview4);
            modelBuilder.Entity<ReviewPoint>().HasData(negReview5);
            modelBuilder.Entity<ReviewPoint>().HasData(negReview6);
            modelBuilder.Entity<ReviewPoint>().HasData(negReview7);
            modelBuilder.Entity<ReviewPoint>().HasData(negReview8);
            modelBuilder.Entity<ReviewPoint>().HasData(negReview9);
            modelBuilder.Entity<ReviewPoint>().HasData(negReview10);
            ///////////////////////////////////////////////////


            ///////////////////////////////////////////////////
            // ENTITY => Rent, Data Initializaton

            Rent rent = new()
            {
                Id = 1,
                UserId = 5,
                BookId = 4,
                ReservedAt = new DateTime(2022, 9, 1),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 20,
                Price = 200,
                State = RentState.Reserved,
            };

            Rent rent1 = new()
            {
                Id = 2,
                UserId = 5,
                BookId = 6,
                ReservedAt = new DateTime(2022, 9, 1),
                RentedAt = new DateTime(2022, 9, 5),
                ReturnedAt = null,
                LoanPeriod = 20,
                Price = 20,
                State = RentState.Active,
            };

            Rent rent2 = new()
            {
                Id = 3,
                UserId = 5,
                BookId = 7,
                ReservedAt = new DateTime(2021, 9, 1),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 20,
                Price = 50,
                State = RentState.Expired,
            };

            Rent rent3 = new()
            {
                Id = 4,
                UserId = 5,
                BookId = 2,
                ReservedAt = new DateTime(2021, 10, 1),
                RentedAt = new DateTime(2021, 10, 3),
                ReturnedAt = new DateTime(2021, 10, 15),
                LoanPeriod = 20,
                Price = 200,
                State = RentState.Returned,
            };

            Rent rent4 = new()
            {
                Id = 5,
                UserId = 4,
                BookId = 1,
                ReservedAt = new DateTime(2020, 12, 5),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 120,
                Price = 150,
                State = RentState.Canceled,
            };

            Rent rent5 = new()
            {
                Id = 6,
                UserId = 2,
                BookId = 1,
                ReservedAt = new DateTime(2020, 9, 2),
                RentedAt = new DateTime(2020, 9, 6),
                ReturnedAt = null,
                LoanPeriod = 10,
                Price = 150,
                State = RentState.Overdue,
            };

            Rent rent6 = new()
            {
                Id = 7,
                UserId = 4,
                BookId = 2,
                ReservedAt = new DateTime(2021, 9, 2),
                RentedAt = new DateTime(2021, 9, 5),
                ReturnedAt = new DateTime(2021, 9, 29),
                LoanPeriod = 30,
                Price = 150,
                State = RentState.Returned,
            };

            Rent rent7 = new()
            {
                Id = 8,
                UserId = 3,
                BookId = 3,
                ReservedAt = new DateTime(2022, 10, 1),
                RentedAt = null,
                ReturnedAt = null,
                LoanPeriod = 3,
                Price = 150,
                State = RentState.Reserved,
            };

            modelBuilder.Entity<Rent>().HasData(rent);
            modelBuilder.Entity<Rent>().HasData(rent1);
            modelBuilder.Entity<Rent>().HasData(rent2);
            modelBuilder.Entity<Rent>().HasData(rent3);
            modelBuilder.Entity<Rent>().HasData(rent4);
            modelBuilder.Entity<Rent>().HasData(rent5);
            modelBuilder.Entity<Rent>().HasData(rent6);
            modelBuilder.Entity<Rent>().HasData(rent7);
            ///////////////////////////////////////////////////

            ///////////////////////////////////////////////////
            // ENTITY => ReservationItem, Data Initializaton

            CartItem resItem = new()
            {
                Id = 1,
                UserId = 5,
                BookId = 6,
            };

            CartItem resItem2 = new()
            {
                Id = 2,
                UserId = 5,
                BookId = 7,
            };

            CartItem resItem3 = new()
            {
                Id = 3,
                UserId = 5,
                BookId = 8,
            };

            CartItem resItem4 = new()
            {
                Id = 4,
                UserId = 5,
                BookId = 9,
            };

            CartItem resItem5 = new()
            {
                Id = 5,
                UserId = 5,
                BookId = 10,
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

