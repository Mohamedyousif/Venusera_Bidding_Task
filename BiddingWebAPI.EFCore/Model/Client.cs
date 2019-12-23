using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BiddingWebAPI.EFCore.Model
{
    public class Client : BaseModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name can't be longer than 50 characters")]
        public string Name { get; set; }

        public int UserID { get; set; }

        public User User { get; set; }

        public IList<Request> Requests { get; set; }
    }
}
