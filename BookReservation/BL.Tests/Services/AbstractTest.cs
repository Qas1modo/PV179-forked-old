using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Tests.Services
{
    public class AbstractTest
    {
        protected User user;
        protected Author author;
        protected Genre genre;
        protected Book book;
        protected Reservation rent;
       
        public AbstractTest()
        {
            this.user = new User
            {
                Id = 1,
                Name = "Monahan",
                Email = "monahan@gmail.com",
                Password = "gbvsi",
                Salt = "g823y8g3gewgew",
                Phone = "100131224",
                BirthDate = DateOnly.MaxValue,
                City = "Montreal",
                Street = "St.Patrick",
                StNumber = 123,
                ZipCode = 123,
                Group = DAL.Enums.Group.User
            };
            this.author = new Author
            {
                Id = 1,
                Name = "Fraňo Kráľ"
            };

            this.genre = new Genre
            {
                Id = 1,
                Name = "For Kids"
            };

            this.book = new Book
            {
                Name = "Čenkovej deti",
                Author = author,
                Genre = genre,
                Stock = int.MaxValue,
                Total = int.MaxValue,
                Price = decimal.MaxValue,
                Description = ":((",
                Photo = "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAUDBAQEAwUE"
            };

            this.rent = new Reservation
            {
                User = user,
                Book = book,
                ReservedAt = DateTime.Now.AddMinutes(-600),
                RentedAt = DateTime.Now,
                LoanPeriod = 20,
                TotalPrice = decimal.MaxValue,
                State = DAL.Enums.RentState.Active // change within test if needed
            };
        }
    }
}
