using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BiddingWebAPI.ApiModels.Requests;
using BiddingWebAPI.EFCore.Model;

namespace BiddingWebAPI.Mapping
{
    public class RequestMap : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression configuration)
        {
            var mapComment = configuration.CreateMap<RequestComment, RequestCommentsModel>();
            mapComment.ForMember(x => x.ServiceProviderName, x => x.MapFrom(u => u.ServiceProvider.Name));

            var mapattach = configuration.CreateMap<RequestAttachement, RequestAttachmentModel>();
            mapattach.ForMember(x => x.Image, x => x.MapFrom(u => u.ImagePath));

            var map = configuration.CreateMap<Request, RequestModel>();
            map.ForMember(x => x.Images, x => x.MapFrom(u => u.RequestAttachements))
                .ForMember(x => x.Comments, x => x.MapFrom(u => u.RequestComments));
        }
    }
}
