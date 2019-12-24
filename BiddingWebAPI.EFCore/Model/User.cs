using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BiddingWebAPI.EFCore.Model
{
    public class User : BaseModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name can't be longer than 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Token { get; set; }

        public bool IsActive { get; set; }

        public string ActivationCode { get; set; }
        
        public int RoleID { get; set; }

        public Role Role { get; set; }

        public IList<RequestComment> RequestComments { get; set; }

        public IList<Request> Requests { get; set; }
    }
}
