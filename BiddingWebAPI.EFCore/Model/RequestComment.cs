using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BiddingWebAPI.EFCore.Model
{
    public class RequestComment : BaseModel
    {
        public int RequestID { get; set; }

        public int ServiceProviderID { get; set; }

        public string Comment { get; set; }

        [ForeignKey("ServiceProviderID")]
        public ServiceProvider ServiceProvider { get; set; }

        [ForeignKey("RequestID")]
        public Request Request { get; set; }
    }
}
