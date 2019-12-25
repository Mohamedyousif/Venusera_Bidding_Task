using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiddingWebAPI.ApiModels.Requests
{
    public class CreateRequestCommentsModel
    {
        public string Comment { get; set; }
        public int RequestID { get; set; }
        public int ServiceProviderID { get; set; }

    }
}
