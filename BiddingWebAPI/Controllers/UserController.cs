using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiddingWebAPI.EFCore.Model;
using Microsoft.AspNetCore.Mvc;

namespace BiddingWebAPI.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult GetUser()
        {
            return Ok(new User() { ID = 1, Email="asd@sdsd.com" , RoleID= 1});
            //return BadRequest();
        }
    }
}