using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiddingWebAPI.ApiModels.Users;
using BiddingWebAPI.EFCore.Model;
using BiddingWebAPI.Filters;
using BiddingWebAPI.Mapping;
using BiddingWebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BiddingWebAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _service;
        private readonly IAutoMapper _mapper;
        private readonly IMailService _mailService;

        public UserController(IUserService service, IMailService mailService, IAutoMapper mapper)
        {
            _mailService = mailService;
            _mapper = mapper;
            _service = service;
        }

        [Authorize]
        [HttpGet]
        public IQueryable<UserModel> Get()
        {
            var result = _service.Get();
            var models = _mapper.Map<User, UserModel>(result);
            return models;
            
        }

        [HttpPost("Register")]
        [ValidateModel]
        public async Task<UserModel> Post([FromBody]CreateUserModel requestModel)
        {
            var item = await _service.Create(requestModel);
            var model = _mapper.Map<UserModel>(item);

            _mailService.SendVerificationLinkEmail(item.Name, item.Email, item.ActivationCode, "http", "localhost", "5000");

            return model;
        }

        [HttpGet("ActivateAccount/{code}")]
        public async Task<string> ActivateAccount(string code)
        {
            var item = await _service.ActivateUser(code);
            var model = _mapper.Map<UserModel>(item);
            if (model != null)
            {
                return "User Activated Successfully";
            }
            else
                return "Error Occured";
        }

        [HttpPost("Authenticate")]
        [ValidateModel]
        public UserWithToken Authenticate([FromBody]AuthenticateModel requestModel)
        {
            var item = _service.Authenticate(requestModel);
            var model = _mapper.Map<UserWithToken>(item);
            return model;
        }
    }
}