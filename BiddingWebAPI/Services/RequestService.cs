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
    public class RequestService : IRequestService
    {
        private readonly IUnitOfWork _uow;
        private readonly IUploadImageHelper _uploadImageHelper;

        public RequestService(IUnitOfWork uow, IUploadImageHelper uploadImageHelper)
        {
            _uow = uow;
            _uploadImageHelper = uploadImageHelper;
        }
        public async Task<Request> Create(CreateRequestModel model)
        {
            List<RequestAttachement> requestAttachments = new List<RequestAttachement>();
            if (model.Images.Count > 5)
            {
                throw new BadRequestException("Maximum images count is 5");
            }
            
            for (int i = 0; i < model.Images.Count; i++)
            {
                string imagePath = _uploadImageHelper.SaveImage(model.Images[i].Image, model.ClientID.ToString());
                requestAttachments.Add(new RequestAttachement() { ImagePath = imagePath });
            }
            
            var request = new Request
            {
                Name = model.Name.Trim(),
                ClientID = model.ClientID,
                Date = model.Date,
                Description = model.Description,
                RequestAttachements = requestAttachments
            };

            _uow.Add(request);
            await _uow.CommitAsync();
           
            

            return request;
        }

        public IQueryable<Request> Get()
        {
            var query = GetQuery();

            return query;
        }

        private IQueryable<Request> GetQuery()
        {   
            return _uow.Query<Request>();
               
        }

        public IQueryable<Request> Get(int id)
        {
            var request = GetQuery().Where(x => x.ID == id);

            if (request == null)
            {
                throw new NotFoundException("Request is not found");
            }

            return request; 
        }

        public IQueryable<Request> GetByClientID(int clientID)
        {
            var request = GetQuery().Where(x => x.ClientID == clientID);

            if (request == null)
            {
                throw new NotFoundException("Request is not found");
            }

            return request;
        }
    }
}
