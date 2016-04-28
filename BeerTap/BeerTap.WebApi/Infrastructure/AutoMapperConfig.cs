using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeerTap.Model;
using BeerTap.Data;

namespace BeerTap.WebApi.Infrastructure
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.CreateMap<Data.Entities.Office, Office>();
            AutoMapper.Mapper.CreateMap<Data.Entities.Keg, Keg>();
            AutoMapper.Mapper.CreateMap<Data.Entities.Tap, Tap>()
                .ForMember(dest => dest.KegState, opts => opts.Ignore());
        }
    }
}