using BiddingWebAPI.ApiModels.Requests;
using BiddingWebAPI.ApiModels.Users;
using BiddingWebAPI.EFCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiddingWebAPI.Services
{
    public interface ICommentService
    {
        IQueryable<RequestComment> Get(int id);
        Task<RequestComment> Create(CreateRequestCommentsModel model);
        IQueryable<RequestComment> GetByServiceProviderID(int ServiceProviderID);
        IQueryable<RequestComment> GetByRequestID(int requestID);
    }
}
