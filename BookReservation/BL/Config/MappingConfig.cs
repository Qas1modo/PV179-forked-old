using AutoMapper;
using BL.DTOs.QueryObjects;
using System;
using Infrastructure.Query;
using DAL.Models;
using BL.DTOs;
using BL.DTOs.BasicDtos;
using AutoMapper.Configuration.Conventions;
using DAL.Enums;

namespace BL.Config
{
	public class MappingConfig
	{
		public static void ConfigureMapping(IMapperConfigurationExpression config)
		{
            config.CreateMap<EFQueryResult<BaseEntity>, QueryResultDto<BaseEntity>>().ReverseMap();
			config.CreateMap<RegistrationDto, User>().ReverseMap();
			config.CreateMap<BookAvailabilityDto, Book>().ReverseMap();
            config.CreateMap<CartItem, CartItemDetailDto>()
                .ForMember(dest => dest.Genre, cfg => cfg.MapFrom(src => src.Book.Genre.Name))
                .ForMember(dest => dest.Name, cfg => cfg.MapFrom(src => src.Book.Name))
                .ForMember(dest => dest.Author, cfg => cfg.MapFrom(src => src.Book.Author.Name))
                .ForMember(dest => dest.Price, cfg => cfg.MapFrom(src => src.Book.Price));
            config.CreateMap<IEnumerable<CartItem>, IEnumerable<CartItemDetailDto>>().ReverseMap();
            config.CreateMap<PersonalInfoDto, User>().ReverseMap();
            config.CreateMap<ReservationDetailDto, Reservation>().ReverseMap();
            config.CreateMap<ReviewDetailDto, Review>().ReverseMap();
            config.CreateMap<Review, ReviewDetailDto>()
                .ForMember(dest => dest.Name, cfg => cfg.MapFrom(src => src.User.Name));
            config.CreateMap<IEnumerable<Review>, IEnumerable<ReviewDetailDto>>().ReverseMap();
            config.CreateMap<AuthorDto, Author>().ReverseMap();
            config.CreateMap<BookDto, Book>()
                .ForMember(dest => dest.Deleted, cfg => cfg.MapFrom(src => false))
                .ReverseMap();
            config.CreateMap<CartItemDto, CartItem>().ReverseMap();
            config.CreateMap<GenreDto, Genre>().ReverseMap();
            config.CreateMap<ReservationDto, Reservation>()
                .ForMember(dest => dest.State, cfg => cfg.MapFrom(src => RentState.Reserved));
            config.CreateMap<Reservation, ReservationDetailDto>()
                .ForMember(dest => dest.Name, cfg => cfg.MapFrom(src => src.Book.Name));
            config.CreateMap<IEnumerable<Reservation>, IEnumerable<ReservationDetailDto>>().ReverseMap();
            config.CreateMap<ReviewDto, Review>().ReverseMap();
            config.CreateMap<UserDto, User>().ReverseMap();
            config.CreateMap<CartItem, ReservationDto>().ReverseMap();
        }
	}
}

