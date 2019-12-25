using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiddingWebAPI.ApiModels.Requests
{
    public class RequestCommentsModel
    {
        public int ID { get; set; }
        public string Comment { get; set; }
        public int ServiceProviderID { get; set; }
        public string ServiceProviderName { get; set; }
    }
}
