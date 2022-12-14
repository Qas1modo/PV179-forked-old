using System;
using AutoMapper;
using BL.DTOs;
using BL.DTOs.BasicDtos;
using BL.Services.BookServ;
using Infrastructure.EFCore.UnitOfWork;
using Infrastructure.UnitOfWork;
using BL.Facades.BookFac;
using BL.QueryObjects;
using DAL.Models;
using BL.Services.AuthorServ;
using BL.Services.GenreServ;

namespace BL.Facades.BookFac
{
    public class BookFacade : IBookFacade
    {
        private readonly IBookService bookService;

        private readonly AuthorQueryObject authorQueryObject;

        private readonly GenreQueryObject genreQueryObject;

        private readonly IAuthorService authorService;

        private readonly IGenreService genreService;

        private readonly IMapper mapper;

        public BookFacade(IBookService bookService,
            AuthorQueryObject authorQueryObject,
            GenreQueryObject genreQueryObject,
            IAuthorService authorService,
            IGenreService genreService,
            IMapper mapper)
        {
            this.bookService = bookService;
            this.authorQueryObject = authorQueryObject;
            this.genreQueryObject = genreQueryObject;
            this.authorService = authorService;
            this.genreService = genreService;
            this.mapper = mapper;
        }

        public async Task<int> addBook(AuthorDto authorDto, BookBasicInfoDto bookDto, GenreDto genreDto)
        {
            BookDto newBook = new BookDto();
            newBook.Description = bookDto.Description;
            newBook.Name = bookDto.Name;
            newBook.Price = bookDto.Price;
            newBook.Stock = bookDto.Stock;
            newBook.Total = bookDto.Stock;


            Author? author = authorQueryObject.GetAuthorByName(authorDto.Name);
            if (author == null)
            {
                var authorId = await authorService.AddAuthor(authorDto);

                //# Workaround
                var checkID = authorQueryObject.GetAuthorByName(authorDto.Name);

                if (checkID != null)
                    authorId = checkID.Id;

                newBook.AuthorId = authorId;
            }
            else
            {
                newBook.AuthorId = author.Id;
            }

            Genre? genre = genreQueryObject.GetGenreByName(genreDto.Name);
            if (genre == null)
            {
                var genreId = await genreService.AddGenre(genreDto);

                //# Workaround
                var checkID = genreQueryObject.GetGenreByName(genreDto.Name);

                if (checkID != null)
                    genreId = checkID.Id;

                newBook.GenreId = genreId;
            }
            else
            {
                newBook.GenreId = genre.Id;
            }


            return await bookService.AddBook(newBook);
        }
    }
}

