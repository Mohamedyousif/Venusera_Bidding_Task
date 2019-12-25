using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiddingWebAPI.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string BaseUrl { get; set; }
        public string Port { get; set; }
        public string EmailID { get; set; }
        public string EmailPassword { get; set; }
    }
}
