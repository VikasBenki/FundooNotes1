using BusinessLayer.Interfaces;
using CommonLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.FundooNoteContext;
using System;
using System.Linq;

namespace FundooNotes1.Controllers
{
    [ApiController]
    [Route("[controller]")]
   
    public class UserController : ControllerBase
    {
        IUserBL userBL;
        FundooContext fundoo;
        public UserController(IUserBL userBL, FundooContext fundoo)
        {
            this.fundoo = fundoo;
            this.userBL = userBL;
        }

        [HttpPost("register")]
        public ActionResult RegisterUser(UserPostModel user)
        {
            try
            {
               
                var result = this.userBL.AddUser(user);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = $"Register Successful {result}" });

                }
                return this.BadRequest(new { success = false, message = $"Register Failed" });


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
