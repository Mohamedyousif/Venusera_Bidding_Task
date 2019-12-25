using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiddingWebAPI.ApiModels.Requests;
using BiddingWebAPI.EFCore.DAL;
using BiddingWebAPI.EFCore.Model;
using BiddingWebAPI.Exceptions;
using BiddingWebAPI.Helpers;

namespace BiddingWebAPI.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _uow;
        
        public CommentService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<RequestComment> Create(CreateRequestCommentsModel model)
        {
            var requestComment = new RequestComment
            {
                Comment = model.Comment.Trim(),
                ServiceProviderID= model.ServiceProviderID,
                RequestID = model.RequestID
            };

            _uow.Add(requestComment);
            await _uow.CommitAsync();
           
            return requestComment;
        }

        private IQueryable<RequestComment> GetQuery()
        {   
            return _uow.Query<RequestComment>();
               
        }

        public IQueryable<RequestComment> Get(int id)
        {
            var request = GetQuery().Where(x => x.ID == id);

            if (request == null)
            {
                throw new NotFoundException("Request Comments is not found");
            }

            return request; 
        }

        public IQueryable<RequestComment> GetByRequestID(int requestID)
        {
            var request = GetQuery().Where(x => x.RequestID == requestID);

            if (request == null)
            {
                throw new NotFoundException("Request Comments is not found");
            }

            return request;
        }

        public IQueryable<RequestComment> GetByServiceProviderID(int ServiceProviderID)
        {
            var request = GetQuery().Where(x => x.ServiceProviderID == ServiceProviderID);

            if (request == null)
            {
                throw new NotFoundException("Request Comments is not found");
            }

            return request;
        }
    }
}
