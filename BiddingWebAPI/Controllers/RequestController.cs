using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiddingWebAPI.ApiModels.Requests;
using BiddingWebAPI.EFCore.Enum;
using BiddingWebAPI.EFCore.Model;
using BiddingWebAPI.Filters;
using BiddingWebAPI.Mapping;
using BiddingWebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BiddingWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestService _service;
        private readonly IAutoMapper _mapper;

        public RequestsController(IRequestService service, IAutoMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        [Authorize(Roles = "Client")]
        [ValidateModel]
        public async Task<RequestModel> Post([FromBody]CreateRequestModel requestModel)
        {
            var item = await _service.Create(requestModel);
            var model = _mapper.Map<RequestModel>(item);

            return model;
        }

        [Authorize(Roles = "ServiceProvider")]
        [HttpGet]
        public IQueryable<RequestModel> Get()
        {
            var result = _service.Get();
            var models = _mapper.Map<Request, RequestModel>(result);
            return models;
        }

        [Authorize(Roles = "Client")]
        [HttpGet]
        [Route("client/{Clientid}")]
        public IQueryable<RequestModel> GetByClientID(int Clientid)
        {
            var result = _service.GetByClientID(Clientid);
            var models = _mapper.Map<Request, RequestModel>(result);
            return models;
        }

        [Authorize(Roles = "Client")]
        [HttpGet]
        [Route("{id}")]
        public RequestModel GetByID(int id)
        {
            var result = _service.Get(id);
            RequestModel requestModel = new RequestModel();
            var models = _mapper.Map<Request, RequestModel>(result);
            return models.FirstOrDefault();
        }
    }
}