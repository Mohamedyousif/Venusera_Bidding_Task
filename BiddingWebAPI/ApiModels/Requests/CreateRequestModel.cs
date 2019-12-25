using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BiddingWebAPI.ApiModels.Requests
{
    public class CreateRequestModel
    {
        [Required(ErrorMessage = "Request Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Request Date is required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string Description { get; set; }

        public int ClientID { get; set; }



    }
}
