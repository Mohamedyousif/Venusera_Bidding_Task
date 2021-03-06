﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiddingWebAPI.ApiModels.Users;
using BiddingWebAPI.EFCore.Model;
using BiddingWebAPI.Filters;
using BiddingWebAPI.Helpers;
using BiddingWebAPI.Mapping;
using BiddingWebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BiddingWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService _service;
        private readonly IAutoMapper _mapper;
        private readonly IMailService _mailService;
        private readonly AppSettings _appSettings;


        public UsersController(IUserService service, IMailService mailService, IAutoMapper mapper, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
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

            _mailService.SendVerificationLinkEmail(item.Name, item.Email, item.ActivationCode, _appSettings.ActivationUrl);

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