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

            var user = new User
            {
                Id = 1,
                Name = "Martin Kukucin",
                Email = "matkokukucko@mail.com",
                Password = "jfpsjfapjfapf",
                Salt = "jfpajfafjaps",
                Phone = "+421911999111",
                BirthDate = new DateTime(1970, 3, 1),
                Group = Group.Admin,
                Picture = "www.nejakycuteobrazok.com",
            };

            var user2 = new User
            {
                Id = 2,
                Name = "Peter Marcin",
                Email = "peter123@mail.com",
                Password = "jjpjpkf",
                Salt = "dkpafjapfjpak",
                Phone = "+421911999222",
                BirthDate = new DateTime(1980, 3, 1),
                Group = Group.Employee,
                Picture = "www.pictureofemployee.com",
            };

            var user3 = new User
            {
                Id = 3,
                Name = "Ferko Turan",
                Email = "feroslav1@mail.com",
                Password = "mojeultraheslo",
                Salt = "dkpafjnpfjpak",
                Phone = "+421911999333",
                BirthDate = new DateTime(1983, 3, 1),
                Group = Group.User,
                Picture = "www.pictureofuser.com",
            };

            var user4 = new User
            {
                Id = 4,
                Name = "Patrik Vrbovsky",
                Email = "uzanineviem@mail.com",
                Password = "JaMamLepsieHeslo",
                Salt = "dkyafjapfjpak",
                Phone = "+421911999540",
                BirthDate = new DateTime(1991, 3, 1),
                Group = Group.User,
                Picture = "www.pictureofdogs.com",
            };

            var user5 = new User
            {
                Id = 5,
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
            // ENTITY => Book, Data Initializaton

            var harryPotter1 = new Book
            {
                Id = 1,
                Name = "Harry Potter and the Philosopher's Stone",
                Author = "Joanne Rowling",
                Genre = DAL.Enums.Genre.Action,
                Stock = 63,
                Price = 16,
                Description = "d",
                Photo = "www.harrrypotterphotos.com",
            };

            var harryPotter2 = new Book
            {
                Id = 2,
                Name = "Harry Potter and the Chamber of Secrets",
                Author = "Joanne Rowling",
                Genre = DAL.Enums.Genre.Comedy,
                Stock = 72,
                Price = 30,
                Description = "djosfjsdopj",
                Photo = "www.jupijupijej.com",
            };

            var harryPotter3 = new Book
            {
                Id = 3,
                Name = "Harry Potter and the Prisoner of Azkaban",
                Author = "Joanne Rowling",
                Genre = DAL.Enums.Genre.Contemporary,
                Stock = 900,
                Price = 17,
                Description = "djosfjsdopj",
                Photo = "wwww.someweb.com",
            };

            var harryPotter4 = new Book
            {
                Id = 4,
                Name = "Harry Potter and the Goblet of Fire",
                Author = "Joanne Rowling",
                Genre = DAL.Enums.Genre.Action,
                Stock = 150,
                Price = 27,
                Description = "djosfjsdopj",
                Photo = "www.uzneviemuz.com",
            };

            var harryPotter5 = new Book
            {
                Id = 5,
                Name = "Harry Potter and the Order of the Phoenix",
                Author = "Joanne Rowling",
                Genre = DAL.Enums.Genre.Detective,
                Stock = 7,
                Price = 50,
                Description = "djosfjsdopj",
                Photo = "www.harrymaguire.com",
            };

            var harryPotter6 = new Book
            {
                Id = 6,
                Name = "Harry Potter and the Half-Blood Prince",
                Author = "Joanne Rowling",
                Genre = DAL.Enums.Genre.Detective,
                Stock = 15,
                Price = 30,
                Description = "djosfjsdopj",
                Photo = "www.slafgoalsky.com",
            };

            var gameOfThrones1 = new Book
            {
                Id = 7,
                Name = "Fire & Blood",
                Author = "George Martin",
                Genre = DAL.Enums.Genre.SciFi,
                Stock = 90,
                Price = 23,
                Description = "djosfjsdopj",
                Photo = "www.cobra11istheworstseries.com",
            };

            var gameOfThrones2 = new Book
            {
                Id = 8,
                Name = "A Game of Thrones",
                Author = "George Martin",
                Genre = DAL.Enums.Genre.SciFi,
                Stock = 79,
                Price = 35,
                Description = "djosfjsdopj",
                Photo = "www.gameofthronesphotos.com",
            };

            var gameOfThrones3 = new Book
            {
                Id = 9,
                Name = "A Clash of Kings ",
                Author = "George Martin",
                Genre = DAL.Enums.Genre.SciFi,
                Stock = 13,
                Price = 46,
                Description = "djosfjsdopj",
                Photo = "www.myphoto.com",
            };

            var gameOfThrones4 = new Book
            {
                Id = 10,
                Name = "A Storm of Swords ",
                Author = "George Martin",
                Genre = DAL.Enums.Genre.SciFi,
                Stock = 50,
                Price = 25,
                Description = "djosfjsdopj",
                Photo = "www.yourphoto.com",
            };

            var gameOfThrones5 = new Book
            {
                Id = 11,
                Name = "A Feast for Crows",
                Author = "George Martin",
                Genre = DAL.Enums.Genre.SciFi,
                Stock = 1,
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

            var address1 = new Address
            {
                Id = 1,
                City = "Brno",
                Street = "Manesova",
                StNumber = 12,
                ZipCode = 03601,
                UserId = 1,
            };

            var address2 = new Address
            {
                Id = 2,
                City = "Brno",
                Street = "Manesova",
                StNumber = 13,
                ZipCode = 03601,
                UserId = 2,
            };

            var address3 = new Address
            {
                Id = 3,
                City = "Praha",
                Street = "Prazska",
                StNumber = 9,
                ZipCode = 03602,
                UserId = 3,
            };

            var address4 = new Address
            {
                Id = 4,
                City = "Ostrava",
                Street = "Ostravska",
                StNumber = 1,
                ZipCode = 03603,
                UserId = 4,
            };

            var address5 = new Address
            {
                Id = 5,
                City = "Breclav",
                Street = "Hlavni",
                StNumber = 15,
                ZipCode = 03605,
                UserId = 5,
            };

            modelBuilder.Entity<Address>().HasData(address1);
            modelBuilder.Entity<Address>().HasData(address2);
            modelBuilder.Entity<Address>().HasData(address3);
            modelBuilder.Entity<Address>().HasData(address4);
            modelBuilder.Entity<Address>().HasData(address5);
            ///////////////////////////////////////////////////

            ///////////////////////////////////////////////////
            // ENTITY => Review, Data Initializaton

            var review1 = new Review
            {
                Id = 1,
                Score = 9,
                UserId = 5,
                BookId = 5,
            };

            var review2 = new Review
            {
                Id = 2,
                Score = 5,
                UserId = 5,
                BookId = 4,
            };

            var review3 = new Review
            {
                Id = 3,
                Score = 7,
                UserId = 4,
                BookId = 5,
            };

            var review4 = new Review
            {
                Id = 4,
                Score = 3,
                UserId = 4,
                BookId = 4,
            };

            var review5 = new Review
            {
                Id = 5,
                Score = 8,
                UserId = 3,
                BookId = 5,
            };

            var review6 = new Review
            {
                Id = 6,
                Score = 9,
                UserId = 2,
                BookId = 4,
            };

            var review7 = new Review
            {
                Id = 7,
                Score = 7,
                UserId = 4,
                BookId = 3,
            };

            var review8 = new Review
            {
                Id = 8,
                Score = 9,
                UserId = 4,
                BookId = 6,
            };

            var review9 = new Review
            {
                Id = 9,
                Score = 7,
                UserId = 3,
                BookId = 3,
            };

            var review10 = new Review
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

            var posReview = new PositiveReview
            {
                Id = 1,
                Text = "to je tak super",
                ReviewId = 1,
            };

            var posReview1 = new PositiveReview
            {
                Id = 2,
                Text = "to je tak super tiez",
                ReviewId = 1,
            };

            var posReview2 = new PositiveReview
            {
                Id = 3,
                Text = "to je tak super tiez tiez",
                ReviewId = 1,
            };

            var posReview3 = new PositiveReview
            {
                Id = 4,
                Text = "to je tak super tak isto ako aj to pred tym",
                ReviewId = 1,
            };

            var posReview4 = new PositiveReview
            {
                Id = 5,
                Text = "to je tak super",
                ReviewId = 5,
            };

            var posReview5 = new PositiveReview
            {
                Id = 6,
                Text = "to je tak super tiez",
                ReviewId = 5,
            };

            var posReview6 = new PositiveReview
            {
                Id = 7,
                Text = "to je tak super tiez tiez",
                ReviewId = 5,
            };

            var posReview7 = new PositiveReview
            {
                Id = 8,
                Text = "to je tak super tak isto ako aj to pred tym",
                ReviewId = 5,
            };

            var posReview8 = new PositiveReview
            {
                Id = 9,
                Text = "to je tak super tiez",
                ReviewId = 6,
            };

            var posReview9 = new PositiveReview
            {
                Id = 10,
                Text = "to je tak super tiez tiez",
                ReviewId = 6,
            };

            var posReview10 = new PositiveReview
            {
                Id = 11,
                Text = "to je tak super tiez tiez",
                ReviewId = 6,
            };

            modelBuilder.Entity<PositiveReview>().HasData(posReview);
            modelBuilder.Entity<PositiveReview>().HasData(posReview1);
            modelBuilder.Entity<PositiveReview>().HasData(posReview2);
            modelBuilder.Entity<PositiveReview>().HasData(posReview3);
            modelBuilder.Entity<PositiveReview>().HasData(posReview4);
            modelBuilder.Entity<PositiveReview>().HasData(posReview5);
            modelBuilder.Entity<PositiveReview>().HasData(posReview6);
            modelBuilder.Entity<PositiveReview>().HasData(posReview7);
            modelBuilder.Entity<PositiveReview>().HasData(posReview8);
            modelBuilder.Entity<PositiveReview>().HasData(posReview9);
            modelBuilder.Entity<PositiveReview>().HasData(posReview10);
            ///////////////////////////////////////////////////


            ///////////////////////////////////////////////////
            // ENTITY => Negative Review, Data Initializaton

            var negReview = new NegativeReview
            {
                Id = 1,
                Text = "to je tak zle",
                ReviewId = 2,
            };

            var negReview1 = new NegativeReview
            {
                Id = 2,
                Text = "to je tak zle tiez",
                ReviewId = 2,
            };

            var negReview2 = new NegativeReview
            {
                Id = 3,
                Text = "to je tak zle tiez tiez",
                ReviewId = 1,
            };

            var negReview3 = new NegativeReview
            {
                Id = 4,
                Text = "to je tak zle tak isto ako aj to pred tym",
                ReviewId = 2,
            };

            var negReview4 = new NegativeReview
            {
                Id = 5,
                Text = "to je tak zle",
                ReviewId = 6,
            };

            var negReview5 = new NegativeReview
            {
                Id = 6,
                Text = "to je tak super tiez",
                ReviewId = 6,
            };

            var negReview6 = new NegativeReview
            {
                Id = 7,
                Text = "to je tak super tiez tiez",
                ReviewId = 6,
            };

            var negReview7 = new NegativeReview
            {
                Id = 8,
                Text = "to je tak super tak isto ako aj to pred tym",
                ReviewId = 6,
            };

            var negReview8 = new NegativeReview
            {
                Id = 9,
                Text = "to je tak super tiez",
                ReviewId = 3,
            };

            var negReview9 = new NegativeReview
            {
                Id = 10,
                Text = "to je tak super tiez tiez",
                ReviewId = 3,
            };

            var negReview10 = new NegativeReview
            {
                Id = 11,
                Text = "to je tak super tiez tiez",
                ReviewId = 3,
            };

            modelBuilder.Entity<NegativeReview>().HasData(negReview);
            modelBuilder.Entity<NegativeReview>().HasData(negReview1);
            modelBuilder.Entity<NegativeReview>().HasData(negReview2);
            modelBuilder.Entity<NegativeReview>().HasData(negReview3);
            modelBuilder.Entity<NegativeReview>().HasData(negReview4);
            modelBuilder.Entity<NegativeReview>().HasData(negReview5);
            modelBuilder.Entity<NegativeReview>().HasData(negReview6);
            modelBuilder.Entity<NegativeReview>().HasData(negReview7);
            modelBuilder.Entity<NegativeReview>().HasData(negReview8);
            modelBuilder.Entity<NegativeReview>().HasData(negReview9);
            modelBuilder.Entity<NegativeReview>().HasData(negReview10);
            ///////////////////////////////////////////////////


            ///////////////////////////////////////////////////
            // ENTITY => Rent, Data Initializaton

            var rent = new Rent
            {
                Id = 1,
                UserId = 5,
                BookId = 4,
                RentedAt = new DateTime(2022, 10, 1),
                LoanPeriod = 20,
                Price = 200,
                State = RentState.Active,
            };

            var rent1 = new Rent
            {
                Id = 2,
                UserId = 5,
                BookId = 6,
                RentedAt = new DateTime(2022, 10, 1),
                LoanPeriod = 20,
                Price = 20,
                State = RentState.Active,
            };

            var rent2 = new Rent
            {
                Id = 3,
                UserId = 5,
                BookId = 7,
                RentedAt = new DateTime(2022, 10, 1),
                LoanPeriod = 20,
                Price = 50,
                State = RentState.Active,
            };

            var rent3 = new Rent
            {
                Id = 4,
                UserId = 5,
                BookId = 2,
                RentedAt = new DateTime(2022, 10, 1),
                LoanPeriod = 20,
                Price = 200,
                State = RentState.Active,
            };

            var rent4 = new Rent
            {
                Id = 5,
                UserId = 4,
                BookId = 1,
                RentedAt = new DateTime(2022, 9, 1),
                LoanPeriod = 120,
                Price = 150,
                State = RentState.Active,
            };

            var rent5 = new Rent
            {
                Id = 6,
                UserId = 4,
                BookId = 1,
                RentedAt = new DateTime(2021, 9, 1),
                LoanPeriod = 10,
                Price = 150,
                State = RentState.Returned,
            };

            var rent6 = new Rent
            {
                Id = 7,
                UserId = 4,
                BookId = 2,
                RentedAt = new DateTime(2021, 9, 1),
                LoanPeriod = 30,
                Price = 150,
                State = RentState.Returned,
            };

            var rent7 = new Rent
            {
                Id = 8,
                UserId = 3,
                BookId = 3,
                RentedAt = new DateTime(2022, 9, 1),
                LoanPeriod = 3,
                Price = 150,
                State = RentState.Late,
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
            // ENTITY => Reservation, Data Initializaton

            var res = new Reservation
            {
                Id = 1,
                UserId = 5,
                BookId = 9,
                ReservedAt = new DateTime(2021, 9, 1),
                Duration = 10,
                State = ReservationState.Expired,
            };

            var res2 = new Reservation
            {
                Id = 2,
                UserId = 5,
                BookId = 10,
                ReservedAt = new DateTime(2021, 9, 1),
                Duration = 10,
                State = ReservationState.Canceled,
            };

            var res3 = new Reservation
            {
                Id = 3,
                UserId = 5,
                BookId = 11,
                ReservedAt = new DateTime(2022, 9, 1),
                Duration = 360,
                State = ReservationState.Active,
            };

            var res4 = new Reservation
            {
                Id = 4,
                UserId = 4,
                BookId = 5,
                ReservedAt = new DateTime(2021, 3, 1),
                Duration = 10,
                State = ReservationState.Expired,
            };

            var res5 = new Reservation
            {
                Id = 5,
                UserId = 4,
                BookId = 5,
                ReservedAt = new DateTime(2021, 2, 1),
                Duration = 50,
                State = ReservationState.Canceled,
            };

            var res6 = new Reservation
            {
                Id = 6,
                UserId = 5,
                BookId = 10,
                ReservedAt = new DateTime(2022, 9, 1),
                Duration = 360,
                State = ReservationState.Active,
            };

            modelBuilder.Entity<Reservation>().HasData(res);
            modelBuilder.Entity<Reservation>().HasData(res2);
            modelBuilder.Entity<Reservation>().HasData(res3);
            modelBuilder.Entity<Reservation>().HasData(res4);
            modelBuilder.Entity<Reservation>().HasData(res5);
            modelBuilder.Entity<Reservation>().HasData(res6);
            ///////////////////////////////////////////////////

            ///////////////////////////////////////////////////
            // ENTITY => ReservationItem, Data Initializaton

            var resItem = new ReservationItem
            {
                Id = 1,
                UserId = 5,
                BookId = 6,
            };

            var resItem2 = new ReservationItem
            {
                Id = 2,
                UserId = 5,
                BookId = 7,
            };

            var resItem3 = new ReservationItem
            {
                Id = 3,
                UserId = 5,
                BookId = 8,
            };

            var resItem4 = new ReservationItem
            {
                Id = 4,
                UserId = 5,
                BookId = 9,
            };

            var resItem5 = new ReservationItem
            {
                Id = 5,
                UserId = 5,
                BookId = 10,
            };

            modelBuilder.Entity<ReservationItem>().HasData(resItem);
            modelBuilder.Entity<ReservationItem>().HasData(resItem2);
            modelBuilder.Entity<ReservationItem>().HasData(resItem3);
            modelBuilder.Entity<ReservationItem>().HasData(resItem4);
            modelBuilder.Entity<ReservationItem>().HasData(resItem5);
            ///////////////////////////////////////////////////
            
        }
    }
}

