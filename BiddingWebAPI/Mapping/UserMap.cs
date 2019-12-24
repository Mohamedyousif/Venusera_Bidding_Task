using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BiddingWebAPI.ApiModels.Users;
using BiddingWebAPI.EFCore.Model;

namespace BiddingWebAPI.Mapping
{
    public class UserMap : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression configuration)
        {
            var map = configuration.CreateMap<User, UserModel>();
            map.ForMember(x => x.UserType, x => x.MapFrom(u => u.Role.Name));

            var map2 = configuration.CreateMap<User, UserWithToken>();
            map2.ForMember(x => x.Token, x => x.MapFrom(u => u.Token))
                .ForMember(a => a.UserType, a => a.MapFrom(u => u.Role.Name));
                
        }
    }
}
