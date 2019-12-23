using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BiddingWebAPI.EFCore.Model
{
    public class User : BaseModel
    {
        
        [Required(ErrorMessage = "Name is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public int RoleID { get; set; }

        public Role Role { get; set; }

    }
}
