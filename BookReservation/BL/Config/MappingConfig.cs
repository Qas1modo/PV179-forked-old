using AutoMapper;
using BL.DTOs.QueryObjects;
using System;
using Infrastructure.Query;
using DAL.Models;
using BL.DTOs;
using BL.DTOs.BasicDtos;

namespace BL.Config
{
	public class MappingConfig
	{
		public static void ConfigureMapping(IMapperConfigurationExpression config)
		{
            config.CreateMap<EFQueryResult<BaseEntity>, QueryResultDto<BaseEntity>>().ReverseMap();
			config.CreateMap<RegistrationDto, User>().ReverseMap();
			config.CreateMap<BookAvailabilityDto, Book>().ReverseMap();
            config.CreateMap<CartItemDetailDto, Book>().ReverseMap();
            config.CreateMap<CartItemDetailDto, CartItem>().ReverseMap();
            config.CreateMap<PersonalInfoDto, User>().ReverseMap();
            config.CreateMap<RentDetailDto, Rent>().ReverseMap();
            config.CreateMap<ReviewDetailDto, Review>().ReverseMap();
            config.CreateMap<AuthorDto, Author>().ReverseMap();
            config.CreateMap<BookDto, Book>().ReverseMap();
            config.CreateMap<CartItemDto, CartItem>().ReverseMap();
            config.CreateMap<GenreDto, Genre>().ReverseMap();
            config.CreateMap<RentDto, Rent>().ReverseMap();
            config.CreateMap<ReviewDto, Review>().ReverseMap();
            config.CreateMap<UserDto, User>().ReverseMap();
        }
	}
}

