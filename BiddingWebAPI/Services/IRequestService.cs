using BiddingWebAPI.ApiModels.Requests;
using BiddingWebAPI.ApiModels.Users;
using BiddingWebAPI.EFCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiddingWebAPI.Services
{
    public interface IRequestService
    {
        IQueryable<Request> Get();
        IQueryable<Request> Get(int id);
        Task<Request> Create(CreateRequestModel model);
        IQueryable<Request> GetByClientID(int clientID);
    }
}
