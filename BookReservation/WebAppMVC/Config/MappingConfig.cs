using AutoMapper;
using System;
using Infrastructure.Query;
using DAL.Models;
using BL.DTOs;
using BL.DTOs.BasicDtos;
using AutoMapper.Configuration.Conventions;
using DAL.Enums;
using WebAppMVC.Models;

namespace WebAppMVC.Config
{
    public class MappingConfig
    {
        public static void ConfigureMapping(IMapperConfigurationExpression config)
        {
            config.CreateMap<QueryResult<Book>, QueryResultDto<BookBasicInfoDto>>().ReverseMap();
            config.CreateMap<RegistrationDto, User>().ReverseMap();
            config.CreateMap<BookAvailabilityDto, Book>().ReverseMap();
            config.CreateMap<CartItem, CartItemDetailDto>()
                .ForMember(dest => dest.GenreName, cfg => cfg.MapFrom(src => src.Book.Genre.Name))
                .ForMember(dest => dest.Name, cfg => cfg.MapFrom(src => src.Book.Name))
                .ForMember(dest => dest.AuthorName, cfg => cfg.MapFrom(src => src.Book.Author.Name))
                .ForMember(dest => dest.Price, cfg => cfg.MapFrom(src => src.Book.Price));
            config.CreateMap<PersonalInfoDto, User>().ReverseMap();
            config.CreateMap<AuthorDto, Author>().ReverseMap();
            config.CreateMap<BookDto, Book>()
                .ForMember(dest => dest.Deleted, cfg => cfg.MapFrom(src => false))
                .ReverseMap();
            config.CreateMap<WishListItem, WishListDetailDto>()
                .ForMember(dest => dest.GenreName, cfg => cfg.MapFrom(src => src.Book.Genre.Name))
                .ForMember(dest => dest.Name, cfg => cfg.MapFrom(src => src.Book.Name))
                .ForMember(dest => dest.AuthorName, cfg => cfg.MapFrom(src => src.Book.Author.Name))
                .ForMember(dest => dest.Price, cfg => cfg.MapFrom(src => src.Book.Price))
                .ReverseMap();
            config.CreateMap<Review, ReviewDetailDto>()
                .ForMember(dest => dest.Name, cfg => cfg.MapFrom(src => src.User.Name));
            config.CreateMap<CartItemDto, CartItem>().ReverseMap();
            config.CreateMap<GenreDto, Genre>().ReverseMap();
            config.CreateMap<QueryResult<Reservation>, QueryResultDto<ReservationDetailDto>>();
            config.CreateMap<QueryResult<Review>, QueryResultDto<ReviewDetailDto>>();
            config.CreateMap<QueryResult<User>, QueryResultDto<UserDto>>();
            config.CreateMap<QueryResult<WishListItem>, QueryResultDto<WishListDetailDto>>();
            config.CreateMap<Reservation, ReservationDetailDto>()
                .ForMember(dest => dest.Name, cfg => cfg.MapFrom(src => src.Book.Name))
                .ForMember(dest => dest.Author, cfg => cfg.MapFrom(src => src.Book.Author.Name))
                .ForMember(dest => dest.Genre, cfg => cfg.MapFrom(src => src.Book.Genre.Name))
                .ForMember(dest => dest.Price, cfg => cfg.MapFrom(src => src.Book.Price));
            config.CreateMap<ReservationDto, Reservation>()
                .ForMember(dest => dest.State, cfg => cfg.MapFrom(src => src.State));
            config.CreateMap<ReviewDto, Review>().ReverseMap();
            config.CreateMap<UserDto, User>().ReverseMap();
            config.CreateMap<CartItem, ReservationDto>().ReverseMap();
            config.CreateMap<BookBasicInfoDto, Book>().ReverseMap();
            config.CreateMap<User, UserAuthDto>().ReverseMap();
            config.CreateMap<AdminPageBookModel, BookDto>()
                .ForMember(dest => dest.Stock, cfg => cfg.MapFrom(src => src.Total))
                .ForMember(dest => dest.Deleted, cfg => cfg.MapFrom(src => false))
                .ForMember(dest => dest.Author, cfg => cfg.MapFrom(src => new Author { Name = src.AuthorName }))
                .ForMember(dest => dest.Genre, cfg => cfg.MapFrom(src => new Genre { Name = src.GenreName }))
                .ReverseMap();
            config.CreateMap<BookBasicInfoDto, AdminPageBookModel>().ReverseMap();
            config.CreateMap<WishListItem, WishListItemDto>().ReverseMap();

        }
    }
}
