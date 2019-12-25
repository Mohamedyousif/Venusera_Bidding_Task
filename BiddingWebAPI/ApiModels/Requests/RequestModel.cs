using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiddingWebAPI.ApiModels.Requests
{
    public class RequestModel
    {
        public RequestModel()
        {
            Images = new List<RequestAttachmentModel>();
        }
        public int ID { get; set; }
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public int ClientID { get; set; }

        public IList<RequestAttachmentModel> Images { get; set; }
        public IList<RequestCommentsModel> Comments { get; set; }

    }
}
