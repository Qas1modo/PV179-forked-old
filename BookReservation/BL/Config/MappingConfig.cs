using AutoMapper;
using BL.DTOs.QueryObjects;
using System;
using Infrastructure.Query;
using DAL.Models;

namespace BL.Config
{
	public class MappingConfig
	{
		public static void ConfigureMapping(IMapperConfigurationExpression config)
		{
            config.CreateMap<EFQueryResult<BaseEntity>, QueryResultDto<BaseEntity>>().ReverseMap();
        }
	}
}

