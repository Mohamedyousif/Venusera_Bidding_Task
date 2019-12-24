using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BiddingWebAPI.EFCore.Model
{
    public class Role 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        //public int RoleID { get; set; }
        public string Name { get; set; }
    }
}
