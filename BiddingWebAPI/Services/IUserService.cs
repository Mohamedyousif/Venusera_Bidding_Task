using BiddingWebAPI.ApiModels.Users;
using BiddingWebAPI.EFCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiddingWebAPI.Services
{
    public interface IUserService
    {
        IQueryable<User> Get();
        User Get(int id);
        Task<User> Create(CreateUserModel model);

        Task<User> ActivateUser(string code);
        User Authenticate(AuthenticateModel model);
    }
}
