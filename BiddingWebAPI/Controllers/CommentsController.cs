using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiddingWebAPI.ApiModels.Requests;
using BiddingWebAPI.EFCore.Model;
using BiddingWebAPI.Filters;
using BiddingWebAPI.Mapping;
using BiddingWebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BiddingWebAPI.Controllers
{
    [Route("api/Requests/{Requestid}/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _service;
        private readonly IAutoMapper _mapper;

        public CommentsController(ICommentService service, IAutoMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        [Authorize(Roles = "ServiceProvider")]
        [ValidateModel]
        public async Task<RequestCommentsModel> Post([FromBody]CreateRequestCommentsModel requestModel)
        {
            var item = await _service.Create(requestModel);
            var model = _mapper.Map<RequestCommentsModel>(item);

            return model;
        }

        [Authorize(Roles = "ServiceProvider")]
        [HttpGet]
        [Route("ServiceProvider/{ServiceProviderID}")]
        public IQueryable<RequestCommentsModel> GetByServiceProviderID(int ServiceProviderID)
        {
            var result = _service.GetByServiceProviderID(ServiceProviderID);
            var models = _mapper.Map<RequestComment, RequestCommentsModel>(result);
            return models;
        }

        [Authorize(Roles = "Client,ServiceProvider")]
        [HttpGet]
        [Route("")]
        public IQueryable<RequestCommentsModel> GetByRequestID(int RequestID)
        {
            var result = _service.GetByRequestID(RequestID);
            var models = _mapper.Map<RequestComment, RequestCommentsModel>(result);
            return models;
        }
    }
}