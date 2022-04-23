using CommonLayer;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Entity;
using RepositoryLayer.FundooNoteContext;
using RepositoryLayer.Interfaces;

using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.UserClass
{
    public class UserRL : IUserRL
    {
        FundooContext fundoo;
        private readonly IConfiguration configuration;
        public UserRL(FundooContext fundoo, IConfiguration configuration)
        {
            this.fundoo = fundoo;
            this.configuration = configuration;
        }
        public User AddUser(UserPostModel user)
        {
            try
            {
                User user1 = new User();
                user1.UserID = new User().UserID;
                user1.FirstName = user.FirstName;
                user1.LastName = user.LastName;
                user1.Email = user.Email;
                user1.Password = user.Password;
                user1.RegisterDate = DateTime.Now;
                user1.Address = user.Address;
                fundoo.Users.Add(user1);
                fundoo.SaveChanges();
                return user1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
