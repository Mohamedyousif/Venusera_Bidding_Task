using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BiddingWebAPI.EFCore.Model
{
    public class Request : BaseModel
    {
        [Required(ErrorMessage = "Request Name is required")]
        [StringLength(150, ErrorMessage = "Request Name can't be longer than 150 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Request Date is required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string Description { get; set; }

        public int ClientID { get; set; }
        
        [ForeignKey("ClientID")]
        public Client Client { get; set; }

        public IList<RequestAttachement> RequestAttachements { get; set; }

        public IList<RequestComment> RequestComments { get; set; }
    }
}
