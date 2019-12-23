using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BiddingWebAPI.EFCore.Model
{
    public class RequestAttachement : BaseModel
    {
        public int RequestID { get; set; }

        public string ImagePath { get; set; }

        [ForeignKey("RequestID")]
        public Request Request { get; set; }
    }
}
